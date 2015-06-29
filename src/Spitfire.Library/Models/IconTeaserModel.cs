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
        /// Gets Title color setting
        /// </summary>
        /// <value>
        /// Title Color value
        /// </value>
        public string TitleColor { get; private set; }

        /// <summary>
        /// Gets Title font size
        /// </summary>
        /// <value>
        /// Title Font Size value
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

            if (parameters != null && parameters.Count > 0)
            {
                this.TitleColor = parameters["TitleColor"];
                this.TitleFontSize = parameters["TitleFontSize"];
                this.Background = parameters["Background"];
            }
        }
    }
}