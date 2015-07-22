namespace Spitfire.Library.Models.Core.Layouts.Vitality
{
    using Constants;

    using Sitecore.Mvc.Presentation;

    using Spitfire.SitecoreExtensions.Extensions;

    /// <summary>
    /// Footer component rendering
    /// </summary>
    public class Footer : RenderingModel
    {   
        /// <summary>
        /// Gets Footer background Image Url
        /// </summary>
        /// <value>
        /// Background Image Url
        /// </value>
        public string BackgroundImageUrl { get; private set; }

        /// <summary>
        /// Gets Footer div height
        /// </summary>
        /// <value>
        /// Footer hight value for css style
        /// </value>
        public string FooterHeight { get; private set; }

        /// <summary>
        /// Initalize rendering
        /// </summary>
        /// <param name="rendering">Rendering to intialize
        /// </param>
        public override void Initialize(Rendering rendering)
        {
            base.Initialize(rendering);
            BackgroundImageUrl = Item.ImageUrl(FieldConstants.Footer.BackgroundImage.ToString());
            FooterHeight = Item[FieldConstants.Footer.FooterHeight];
        }
    }
}