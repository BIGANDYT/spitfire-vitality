namespace Spitfire.Library.Models.Core.Components.Snippets
{
    using System.Collections.Specialized;

    using Sitecore;
    using Sitecore.Mvc.Presentation;
    using Sitecore.Web;

    /// <summary>
    /// Image Left Component
    /// </summary>
    public class ImageText : RenderingModel
    {
       /// <summary>
       /// Gets Title Color
       /// </summary>
       /// <value>
       /// Title color value
       /// </value>
        public string TitleColor { get; private set; }

        /// <summary>
        /// Gets Tilte Font Size
        /// </summary>
        /// <value>
        /// Title Font size value
        /// </value>
        public string TitleFontSize { get; private set; }

        /// <summary>
        /// Gets Background color value
        /// </summary>
        /// <value>
        /// Background color value
        /// </value>
        public string Background { get; private set; }

        /// <summary>
        /// Gets div height value
        /// </summary>
        /// <value>
        /// Div height value
        /// </value>
        public string DivHeight { get; private set; }

        /// <summary>
        /// Gets Image height value
        /// </summary>
        /// <value>
        /// Image height value
        /// </value>
        public string ImageHeight { get; private set; }

        /// <summary>
        /// Gets Image width value
        /// </summary>
        /// <value>
        /// Image Width value
        /// </value>
        public string ImageWidth { get; private set; }

        /// <summary>
        /// Gets the css class
        /// </summary>
        public string CssClass { get; private set; }

        /// <summary>
        /// Initialize Rendering
        /// </summary>
        /// <param name="rendering">Rendering to intialize
        /// </param>
        public override void Initialize(Rendering rendering)
        {
            base.Initialize(rendering);
            NameValueCollection parameters = null;
            if (!string.IsNullOrEmpty(rendering["Parameters"]))
            {
                parameters = WebUtil.ParseUrlParameters(rendering["Parameters"]);
            }

            if (parameters == null || parameters.Count <= 0)
            {
                return;
            }

            TitleColor = parameters["TitleColor"];
            TitleFontSize = parameters["TitleFontSize"];
            Background = parameters["Background"];
            DivHeight = parameters["CompHeight"];
            ImageHeight = !string.IsNullOrEmpty(parameters["ImageHeight"]) ? parameters["ImageHeight"] : "auto";
            CssClass = MainUtil.GetBool(parameters["Image Left"], false) ? string.Empty : "image-right";

            if (!string.IsNullOrEmpty(parameters["ImageWidth"]))
            {
                ImageWidth = parameters["ImageWidth"];
            }
            else
            {
                ImageHeight = "auto";
            }
        }
    }
}