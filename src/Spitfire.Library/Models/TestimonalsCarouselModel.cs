using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Spitfire.Library.Constants;

namespace Spitfire.Library.Models
{
    using Sitecore.Mvc.Presentation;
    public class TestimonalsCarouselModel : RenderingModel
    {
        public IList<Item> Teasers { get; private set; }
        public override void Initialize(Rendering rendering)
        {
            base.Initialize(rendering);
            if (!string.IsNullOrEmpty(Item[SpitfireConstants.FieldConstants.TeaserGroup.Source]))
            {
                MultilistField source = Item.Fields[SpitfireConstants.FieldConstants.TeaserGroup.Source];

                if (source != null)
                {
                    Teasers = source.GetItems().ToList();
                }
            }

        }
    }
}