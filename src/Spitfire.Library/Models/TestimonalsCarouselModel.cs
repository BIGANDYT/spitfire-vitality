namespace Spitfire.Library.Models
{
    using System.Collections.Generic;
    using Sitecore.Data.Items;
    using Sitecore.Mvc.Presentation;
    using Spitfire.Library.Models.Multilists;

    /// <summary>
    /// Model for TestimonalsCarousel rendering
    /// </summary>
    public class TestimonalsCarouselModel : MultiListModel
    {
        /// <summary>
        /// Gets list of teasers selected
        /// </summary>
        /// <value>
        /// Selected list of teasers
        /// </value>
        public IList<Item> Teasers { get; private set; }

        /// <summary>
        /// Override Initialize rendering method
        /// </summary>
        /// <param name="rendering">Rendering to Initialize
        /// </param>
        public override void Initialize(Rendering rendering)
        {
            base.Initialize(rendering);

            Teasers = Items;
        }
    }
}