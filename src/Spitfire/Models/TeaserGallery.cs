using System.Linq;

namespace Spitfire.Models
{
    using System.Collections.Generic;
    using Sitecore.Collections;
    using Sitecore.Data.Fields;
    using Sitecore.Data.Items;
    using Sitecore.Syndication;
    using Spitfire.Constant;

    using Sitecore.Mvc.Presentation;

    public class TeaserGallery : RenderingModel
    {
        public override void Initialize(Rendering rendering)
        {
            base.Initialize(rendering);
            if (!string.IsNullOrEmpty(Item[SpitfireConstants.FieldConstants.TeaserGroup.Source]))
            {
                MultilistField Teasers = Item.Fields[SpitfireConstants.FieldConstants.TeaserGroup.Source];

                if (Teasers != null)
                {
                    TeaserItems = Teasers.GetItems().ToList();
                }
            }
        }

        public IList<Item> TeaserItems { get; private set; }
    }
}