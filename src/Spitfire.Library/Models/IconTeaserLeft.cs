namespace Spitfire.Library.Models
{
    using System.Collections.Specialized;
    using Sitecore.Mvc.Presentation;
    using Sitecore.Web;

    /// <summary>
    /// Icon Teaser left component
    /// </summary>
    public class IconTeaserLeft : RenderingModel
    {
        /// <summary>
        /// Gets the Title color setting
        /// </summary>
        /// <value>
        /// Title Color value
        /// </value>
        public string TitleColor { get; private set; }

        /// <summary>
        /// Gets Title font size
        /// </summary>
        /// <value>
        /// Font size of the Title
        /// </value>
        public string TitleFontSize { get; private set; }

        /// <summary>
        /// Gets background color
        /// </summary>
        /// <value>
        /// Background color
        /// </value>
        public string Background { get; private set; }

        /// <summary>
        /// Intalize Rendering
        /// </summary>
        /// <param name="rendering">Rendering to initialize
        /// </param>
        public void Initialize(Rendering rendering)
        {
            NameValueCollection parameters = null;
            if (!string.IsNullOrEmpty(rendering["Parameters"]))
            {
                string rawParameters = rendering["Parameters"];
                parameters = WebUtil.ParseUrlParameters(rawParameters);
            }

            if (parameters != null && parameters.Count > 0)
            {
                this.TitleColor = parameters["TitleColor"];
                this.TitleFontSize = parameters["TitleFontSize"];
                this.Background = parameters["Background"];
            }
        }
    }
}