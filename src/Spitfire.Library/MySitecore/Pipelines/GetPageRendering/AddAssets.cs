namespace Spitfire.Library.MySitecore.Pipelines.GetPageRendering
{
    using Sitecore.Mvc.Pipelines.Response.GetPageRendering;

    /// <summary>
    /// Mvc.BuildPageDefinition pipeline processor to dynamically reference Cassette Bundles
    /// </summary>
    public class AddAssets : GetPageRenderingProcessor
    {
        public override void Process(GetPageRenderingArgs args)
        {
            // Loop through all the renderings which are cacheable and might not have had their code executed
            foreach (var rendering in args.PageContext.PageDefinition.Renderings)
            {
                // Only run in "normal" page mode, otherwise we assume renderings are always executed.
                if (Sitecore.Context.PageMode.IsNormal && rendering.Caching.Cacheable)
                {
                    MyContext.AssetRequirementService.AddFromRenderingCache(rendering.RenderingItem.ID);
                }

                var renderingItem = rendering.RenderingItem.InnerItem;

                var javaScriptAssets = renderingItem["JavaScript assets"];
                foreach (var javaScriptAsset in javaScriptAssets.Split(';', ',', '\n'))
                {
                    MyContext.AssetRequirementService.AddJavaScriptFile(javaScriptAsset, true);
                }

                var javaScriptInline = renderingItem["JavaScript inline"];
                if (!string.IsNullOrEmpty(javaScriptInline))
                {
                    MyContext.AssetRequirementService.AddJavaScriptInline(javaScriptInline, renderingItem.ID.ToString(), true);
                }

                var cssAssets = renderingItem["Css assets"];
                foreach (var cssAsset in cssAssets.Split(';', ',', '\n'))
                {
                    MyContext.AssetRequirementService.AddCssFile(cssAsset, true);
                }

                var cssInline = renderingItem["Css inline"];
                if (!string.IsNullOrEmpty(cssInline))
                {
                    MyContext.AssetRequirementService.AddCssInline(cssInline, renderingItem.ID.ToString(), true);
                }
            }
        }
    }
}