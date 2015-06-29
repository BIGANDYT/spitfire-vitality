namespace Spitfire.Library.Models
{
    using System.Collections.Specialized;
    using Sitecore.Mvc.Presentation;
    using Sitecore.Web;

    /// <summary>
    /// Image right component rendering
    /// </summary>
    public class ImageRightModel : RenderingModel
    {
        /// <summary>
        /// Gets Title Color
        /// </summary>
        /// <value>
        /// Title Color value
        /// </value>
        public string TitleColor { get; private set; }

        /// <summary>
        /// Gets Title font size
        /// </summary>
        /// <value>
        /// Title font size value
        /// </value>
        public string TitleFontSize { get; private set; }

        /// <summary>
        /// Gets background color value
        /// </summary>
        /// <value>
        /// Background color value
        /// </value>
        public string Background { get; private set; }

        /// <summary>
        /// Gets Div height value
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
        /// Image width value
        /// </value>
        public string ImageWidth { get; private set; }

        /// <summary>
        /// Initialize rendring
        /// </summary>
        /// <param name="rendering">Rendering to intialize
        /// </param>
        public override void Initialize(Rendering rendering)
        {
            base.Initialize(rendering);
            NameValueCollection parameters = null;
            if (!string.IsNullOrEmpty(rendering["Parameters"]))
            {
                string rawParameters = rendering["Parameters"];
                parameters = WebUtil.ParseUrlParameters(rawParameters);
            }

            if (parameters == null || parameters.Count <= 0)
            {
                return;
            }
            this.TitleColor = parameters["TitleColor"];
            this.TitleFontSize = parameters["TitleFontSize"];
            this.Background = parameters["Background"];
            this.DivHeight = parameters["CompHeight"];
            this.ImageHeight = !string.IsNullOrEmpty(parameters["ImageHeight"]) ? parameters["ImageHeight"] : "auto";

            this.ImageWidth = !string.IsNullOrEmpty(parameters["ImageWidth"]) ? parameters["ImageWidth"] : "auto";
        }
    }
}