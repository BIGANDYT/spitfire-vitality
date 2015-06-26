namespace Spitfire.Library.Models
{
    using System.Collections.Generic;
    using System.Linq;

    using Sitecore;
    using Sitecore.Data.Items;
    using Sitecore.Mvc.Presentation;
    using Spitfire.Library.Constants;
    using Sitecore.Data.Fields;

    public class SectionPortfolioModel: RenderingModel
    {
        public List<Item> PortfolioItems { get; set; }

        public override void Initialize(Rendering rendering)
        {
            base.Initialize(rendering);
            if (!string.IsNullOrEmpty(Item[SpitfireConstants.FieldConstants.PortfolioGroup.Source]))
            {
                MultilistField teasers = Item.Fields[SpitfireConstants.FieldConstants.PortfolioGroup.Source];

                if (teasers != null)
                {
                    PortfolioItems = teasers.GetItems().ToList();
                }
            }
        }
    }
}