namespace Spitfire.Library.Models
{
    using System.Collections.Generic;
    using System.Linq;

    using Sitecore.Data.Fields;
    using Sitecore.Data.Items;
    using Sitecore.Mvc.Presentation;

    using Spitfire.Library.Constants;

    public class TeaserGallery : RenderingModel
    {
        public override void Initialize(Rendering rendering)
        {
            base.Initialize(rendering);
            if (!string.IsNullOrEmpty(Item[SpitfireConstants.FieldConstants.TeaserGroup.Source]))
            {
                MultilistField teasers = Item.Fields[SpitfireConstants.FieldConstants.TeaserGroup.Source];

                if (teasers != null)
                {
                    TeaserItems = teasers.GetItems().ToList();
                }
            }
        }

        public IList<Item> TeaserItems { get; private set; }
    }
}