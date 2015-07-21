namespace Spitfire.Library.Models.Core.Components.Portfolio
{
    using System.Collections.Generic;

    using Sitecore.Data.Items;
    using Sitecore.Mvc.Presentation;

    using Spitfire.Library.Models.Core.Components.Multilists;

    /// <summary>
    /// Section Portfolio Component
    /// </summary>
    public class SectionPortfolio : MultiList
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

            PortfolioItems = Items;
        }
    }
}