namespace Spitfire.Library.Models
{
    using Sitecore;
    using Sitecore.Data.Items;
    using Sitecore.Mvc.Presentation;
    using Spitfire.Library.Constants;
    using Spitfire.SitecoreExtensions.Extensions;

    /// <summary>
    /// Footer component rendering
    /// </summary>
    public class FooterModel : IRenderingModel
    {   
        /// <summary>
        /// Gets Footer datasource item
        /// </summary>
        /// <value>
        /// Footer datasource Item
        /// </value>
        public Item Item { get; private set; }
        
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
        public void Initialize(Rendering rendering)
        {
            this.Item = !string.IsNullOrEmpty(rendering.DataSource)
                            ? Context.Database.GetItem(rendering.DataSource)
                            : Context.Item;
            this.BackgroundImageUrl = this.Item.ImageUrl(SpitfireConstants.FieldConstants.Footer.BackgroundImage);
            this.FooterHeight = this.Item[SpitfireConstants.FieldConstants.Footer.FooterHeight];
        }
    }
}