using System.Collections.Generic;
using System.Linq;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Mvc.Presentation;

namespace Spitfire.References.Models
{
    /// <summary>
    /// Model for TestimonalsCarousel rendering
    /// </summary>
    public class TestimonialsCarousel : RenderingModel
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

            if (!string.IsNullOrEmpty(Item[FieldConstants.FieldNames.SourceField]))
            {
                MultilistField source = Item.Fields[FieldConstants.FieldNames.SourceField];

                if (source != null)
                {
                    Teasers = source.GetItems().ToList();
                }
            }
        }
    }
}