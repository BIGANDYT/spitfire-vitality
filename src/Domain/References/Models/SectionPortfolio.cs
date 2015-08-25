using System.Collections.Generic;
using System.Linq;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Mvc.Presentation;

namespace Spitfire.References.Models
{
    /// <summary>
    /// Section Portfolio Component
    /// </summary>
    public class SectionPortfolio : RenderingModel
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
        /// <param name="rendering">Rendering to Initialize</param>
        public override void Initialize(Rendering rendering)
        {
            base.Initialize(rendering);

            if (!string.IsNullOrEmpty(Item[FieldConstants.FieldNames.SourceField]))
            {
                MultilistField source = Item.Fields[FieldConstants.FieldNames.SourceField];

                if (source != null)
                {
                    this.PortfolioItems = source.GetItems().ToList();
                }
            }
        }
    }
}