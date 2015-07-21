namespace Spitfire.Library.Models.Core.Components.Headers
{
    using System.Collections.Specialized;

    using Sitecore;
    using Sitecore.Mvc.Presentation;
    using Sitecore.Web;

    /// <summary>
    /// The model for the section header
    /// </summary>
    public class SectionHeader : RenderingModel
    {
        /// <summary>
        /// Gets a value indicating whether the button should be shown
        /// </summary>
        public bool ShowButton { get; private set; }

        /// <summary>
        /// Initialize the rendering
        /// </summary>
        /// <param name="rendering">The rendering to initialize</param>
        public override void Initialize(Rendering rendering)
        {
            base.Initialize(rendering);

            if (!string.IsNullOrEmpty(rendering["Parameters"]))
            {
                NameValueCollection parameters = WebUtil.ParseUrlParameters(rendering["Parameters"]);
                ShowButton = MainUtil.GetBool(parameters["Show Button"], false);
            }
        }
    }
}