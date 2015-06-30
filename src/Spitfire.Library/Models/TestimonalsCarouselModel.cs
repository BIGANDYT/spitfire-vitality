namespace Spitfire.Library.Models
{
    using System.Collections.Generic;
    using System.Linq;
    using Sitecore.Data.Fields;
    using Sitecore.Data.Items;
    using Sitecore.Mvc.Presentation;
    using Spitfire.Library.Constants;

    /// <summary>
    /// Model for TestimonalsCarousel rendering
    /// </summary>
    public class TestimonalsCarouselModel : RenderingModel
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
            if (!string.IsNullOrEmpty(this.Item[SpitfireConstants.FieldConstants.TeaserGroup.Source]))
            {
                MultilistField source = this.Item.Fields[SpitfireConstants.FieldConstants.TeaserGroup.Source];

                if (source != null)
                {
                    this.Teasers = source.GetItems().ToList();
                }
            }
        }
    }
}