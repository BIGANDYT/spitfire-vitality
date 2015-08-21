namespace Spitfire.Library.Models.Core.Scaffolding
{
    using Sitecore.Mvc.Presentation;

    using Constants;
    using Spitfire.SitecoreExtensions.Extensions;

    /// <summary>
    /// Style definition inhireted IRenderingModel interface
    /// </summary>
    public class Style : IRenderingModel
    {
        /// <summary>
        /// Gets or sets css style value
        /// </summary>
        /// <value>
        /// Css style value
        /// </value>
        public string CssStyle { get; set; }

        /// <summary>
        /// Gets or sets css class value
        /// </summary>
        /// <value>
        /// Css class value
        /// </value>
        public string CssClass { get; set; }

        /// <summary>
        /// Gets or sets background image Url
        /// </summary>
        /// <value>
        /// Background image Url value
        /// </value>
        public string BackgroundImgUrl { get; set; }

        /// <summary>
        /// Initialize the rendering
        /// </summary>
        /// <param name="rendering">Rendering to initialize
        /// </param>
        public virtual void Initialize(Rendering rendering)
        {
            CssStyle = rendering.Parameters[ParameterConstants.Style.CssStyle];
            CssClass = rendering.Parameters[ParameterConstants.Style.CssClass];
            BackgroundImgUrl = rendering.ImageUrl(ParameterConstants.Style.BackgroundImageUrl);
        }
    }
}