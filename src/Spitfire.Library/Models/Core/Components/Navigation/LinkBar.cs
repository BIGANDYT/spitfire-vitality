namespace Spitfire.Library.Models.Core.Components.Navigation
{
    using System.Collections.Specialized;

    using Sitecore.Mvc.Presentation;
    using Sitecore.Web;

    using Constants;

    /// <summary>
    /// Model for Linkbar component redering
    /// </summary>
    public class LinkBar : RenderingModel
    {
        /// <summary>
        /// Gets link text color value.
        /// </summary>
        /// <value>
        /// Link text color value
        /// </value>
        public string Color { get; private set; }

        /// <summary>
        /// Gets Link text color when link is acitve.
        /// </summary>
        /// <value>
        /// Link text color when active.
        /// </value>
        public string ColorActive { get; private set; }

        /// <summary>
        /// Gets Background color value
        /// </summary>
        /// <value>
        /// Background color value
        /// </value>
        public string BackgroundColor { get; private set; }

        /// <summary>
        /// Gets background color value when link bar is active.
        /// </summary>
        /// <value>
        /// Background color value when link bar is active
        /// </value>
        public string BackgroundColorActive { get; private set; }

        /// <summary>
        /// Gets Font size of the link text
        /// </summary>
        /// <value>
        /// Link text font size value
        /// </value>
        public string FontSize { get; private set; }

        /// <summary>
        /// Gets CssClass value of the link bar rendering
        /// </summary>
        /// <value>
        /// Css class value
        /// </value>
        public string CssClass { get; private set; }

        /// <summary>
        /// Initialize rendering
        /// </summary>
        /// <param name="rendering">Rendering to initialize
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
                Color = parameters["Color"];
                ColorActive = parameters["ColorActive"];
                BackgroundColor = parameters["Background"];
                BackgroundColorActive = parameters["BackgroundActive"];
                FontSize = parameters["FontSize"];
                CssClass = parameters[ParameterConstants.Style.CssClass];
            }
        }
    }
}