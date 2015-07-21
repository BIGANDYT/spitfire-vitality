namespace Spitfire.Library.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Web;

    using Sitecore;
    using Sitecore.Data;
    using Sitecore.Mvc.Presentation;

    using Spitfire.Library.Models.AssetRequirements;

    /// <summary>
    /// A service which helps add the required JavaScript at the end of a page, and CSS at the top of a page.
    /// In component based architecture it ensures references and inline scripts are only added once.
    /// </summary>
    public class AssetRequirementService
    {
        /// <summary>Sitecore CustomCache object which holds the requirements for cacheable renderings</summary>
        private static readonly AssetRequirementCache Cache = new AssetRequirementCache(StringUtil.ParseSizeString("10MB"));

        /// <summary>The requirements which have been found in renderings executed on this page request</summary>
        private readonly List<AssetRequirement> items = new List<AssetRequirement>();

        /// <summary>A list of rendering IDs which have been executed on this page request</summary>
        private readonly List<ID> seenRenderings = new List<ID>();

        /// <summary>
        /// Adds an AssetRequirement to the page, checking if it hasn't been added already.
        /// </summary>
        /// <param name="requirement">
        /// The AssetRequirement to be added to the page
        /// </param>
        /// <param name="preventAddToCache">
        /// Do not add requirement to cache
        /// </param>
        public void Add(AssetRequirement requirement, bool preventAddToCache = false)
        {
            // If this code block should only be added once per page, check that now.
            if (requirement.AddOnceToken != null)
            {
                if (items.Any(x => x.AddOnceToken != null && x.AddOnceToken == requirement.AddOnceToken))
                {
                    return;
                }
            }

            // If requirement is a file, check it hasn't been added already.
            if (requirement.File != null)
            {
                if (items.Any(x => x.File != null && x.File == requirement.File))
                {
                    return;
                }
            }

            // If rendering is cacheable it requires special attention. We need to make sure asset references
            // are also cached so we can process them elsewhere in the rendering pipeline.
            if (!preventAddToCache)
            {
                if (RenderingContext.Current != null)
                {
                    var rendering = RenderingContext.Current.Rendering;
                    if (rendering != null && rendering.Caching.Cacheable)
                    {
                        AssetRequirementList cachedRequirements;

                        var renderingID = rendering.RenderingItem.ID;

                        // Check if this is the first time we've seen this rendering during this page request
                        // If so, start from fresh with a new list of requirements
                        if (!seenRenderings.Contains(renderingID))
                        {
                            seenRenderings.Add(renderingID);
                            cachedRequirements = new AssetRequirementList();
                        }
                        else
                        {
                            cachedRequirements = Cache.Get(renderingID) ?? new AssetRequirementList();
                        }

                        cachedRequirements.Add(requirement);
                        Cache.Set(renderingID, cachedRequirements);
                    }
                }
            }

            // Passed the checks, add the requirement.
            items.Add(requirement);
        }

        /// <summary>Add requirements which would otherwise have been missed because of rendering caching</summary>
        /// <param name="renderingID">The Sitecore ID of the rendering</param>
        public void AddFromRenderingCache(ID renderingID)
        {
            // Check if rendering has already been executed in this page request
            // and if so, no need to add it again.
            if (seenRenderings.Contains(renderingID))
            {
                return;
            }

            var list = Cache.Get(renderingID);

            if (list != null)
            {
                foreach (var requirement in list)
                {
                    Add(requirement, true);
                }
            }
        }

        /// <summary>
        /// Renders the JavaScript requirements to the page
        /// </summary>
        /// <returns>The rendered JavaScript code</returns>
        public HtmlString RenderJavaScript()
        {
            var sb = new StringBuilder();
            foreach (var item in items.Where(x => x.Type == AssetType.JavaScript && x.File != null))
            {
                sb.AppendFormat("<script src=\"{0}\"></script>", item.File).AppendLine();
            }

            if (items.Any(x => x.Inline != null))
            {
                sb.AppendLine("<script>\njQuery2(document).ready(function() {");

                foreach (var item in items.Where(x => x.Type == AssetType.JavaScript && x.Inline != null))
                {
                    sb.AppendLine(item.Inline);
                }

                sb.AppendLine("});\n</script>");
            }

            return new HtmlString(sb.ToString());
        }

        /// <summary>
        /// Renders the stylesheet requirements to the page
        /// </summary>
        /// <returns>The rendered style code</returns>
        public HtmlString RenderStyles()
        {
            var sb = new StringBuilder();
            foreach (var item in items.Where(x => x.Type == AssetType.Css && x.File != null))
            {
                sb.AppendFormat("<link href=\"{0}\" rel=\"stylesheet\" />", item.File).AppendLine();
            }

            if (items.Any(x => x.Inline != null))
            {
                sb.AppendLine("<style type=\"text/css\">");

                foreach (var item in items.Where(x => x.Type == AssetType.Css && x.Inline != null))
                {
                    sb.AppendLine(item.Inline);
                }

                sb.AppendLine("</style>");
            }

            return new HtmlString(sb.ToString());
        }

        public void AddJavaScriptFile(string file, bool preventAddToCache = false)
        {
            Add(new AssetRequirement(AssetType.JavaScript, file), preventAddToCache);
        }

        public void AddJavaScriptInline(string inline, string addOnceToken, bool preventAddToCache = false)
        {
            Add(new AssetRequirement(AssetType.JavaScript, null, inline, addOnceToken), preventAddToCache);
        }

        public void AddCssFile(string file, bool preventAddToCache = false)
        {
            Add(new AssetRequirement(AssetType.Css, file), preventAddToCache);
        }

        public void AddCssInline(string inline, string addOnceToken, bool preventAddToCache = false)
        {
            Add(new AssetRequirement(AssetType.Css, null, inline, addOnceToken), preventAddToCache);
        }
    }
}