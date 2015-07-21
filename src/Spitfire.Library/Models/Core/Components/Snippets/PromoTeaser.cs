namespace Spitfire.Library.Models.Core.Components.Snippets
{
    using System.Collections.Specialized;

    using Sitecore.Mvc.Presentation;
    using Sitecore.Web;

    using Constants;

    /// <summary>
    /// Promotion Teaser component
    /// </summary>
    public class PromoTeaser : RenderingModel
    {
        /// <summary>
        /// Gets Title color setting
        /// </summary>
        /// <value>
        /// Title color value
        /// </value>
        public string TitleColor { get; private set; }

        /// <summary>
        /// Gets Title font size
        /// </summary>
        /// <value>
        /// Title Font size value
        /// </value>
        public string TitleFontSize { get; private set; }

        /// <summary>
        /// Gets background color
        /// </summary>
        /// <value>
        /// Background color value
        /// </value>
        public string Background { get; private set; }

        /// <summary>
        /// Gets css class
        /// </summary>
        /// <value>
        /// Css class value
        /// </value>
        public string CssClassValue { get; private set; }

        /// <summary>
        /// Initialize rendering
        /// </summary>
        /// <param name="rendering">Rendering to intialze
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

            TitleColor = parameters["TitleColor"];
            TitleFontSize = parameters["TitleFontSize"];
            Background = parameters["Background"];
            CssClassValue = parameters[ParameterConstants.Style.CssClass];
        }
    }
}