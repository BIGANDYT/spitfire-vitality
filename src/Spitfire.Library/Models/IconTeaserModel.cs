namespace Spitfire.Library.Models
{
    using System.Collections.Specialized;
    using Sitecore.Mvc.Presentation;
    using Sitecore.Web;

    /// <summary>
    /// Icon Teaser Model
    /// </summary>
    public class IconTeaserModel : RenderingModel
    {
        /// <summary>
        /// Get Title color setting
        /// </summary>
        /// <value>
        /// </value>
        public string TitleColor { get; private set; }

        /// <summary>
        /// Set Title font size
        /// </summary>
        /// <value>
        /// </value>
        public string TitleFontSize { get; private set; }

        /// <summary>
        /// Gets background color
        /// </summary>
        /// <value>
        /// Background Color value
        /// </value>
        public string Background { get; private set; }

        /// <summary>
        /// Rendering Initialize
        /// </summary>
        /// <param name="rendering">rendering to intialize
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
                TitleColor = parameters["TitleColor"];
                TitleFontSize = parameters["TitleFontSize"];
                Background = parameters["Background"];
            }
        }
    }
}