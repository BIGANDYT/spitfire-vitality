namespace Spitfire.Library.Models
{
    using System.Collections.Generic;
    using System.Linq;

    using Sitecore.Data.Fields;
    using Sitecore.Data.Items;
    using Sitecore.Mvc.Presentation;

    using Spitfire.Library.Constants;

    /// <summary>
    /// Section Portfolio Component
    /// </summary>
    public class SectionPortfolioModel : RenderingModel
    {
        /// <summary>
        /// Gets Seleted Portfoilo items.
        /// </summary>
        /// <value>
        /// Selected Portfoilo items
        /// </value>
        public List<Item> PortfolioItems { get; private set; }

        /// <summary>
        /// Initialize rendering
        /// </summary>
        /// <param name="rendering">Rendering to Initialize
        /// </param>
        public override void Initialize(Rendering rendering)
        {
            base.Initialize(rendering);
            if (string.IsNullOrEmpty(this.Item[SpitfireConstants.FieldConstants.PortfolioGroup.Source]))
            {
                return;
            }

            MultilistField teasers = this.Item.Fields[SpitfireConstants.FieldConstants.PortfolioGroup.Source];

            if (teasers != null)
            {
                this.PortfolioItems = teasers.GetItems().ToList();
            }
        }
    }
}