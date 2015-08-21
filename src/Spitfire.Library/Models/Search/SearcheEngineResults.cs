namespace Spitfire.Library.Models.Search
{
    using System.Collections.Generic;
    using System.Linq;
    using Sitecore.Data;
    using Sitecore.Data.Items;
    using Sitecore.Mvc.Presentation;

    /// <summary>
    /// Search engine results list model
    /// </summary>
    public class SearcheEngineResults : RenderingModel
    {
        /// <summary>
        /// Gets Promote item from the campaign - our home page
        /// </summary>
        public Item PromoteItem { get; private set; }

        /// <summary>
        /// Gets child items of Google results
        /// </summary>
        public IList<Item> ChildrenItems { get; private set;}

        /// <summary>
        /// Get Ads items excluding promote item
        /// </summary>
        public IList<Item> ChildrenAdsItems { get; private set; }

        public IList<Item> ChildrenNoAdsItems { get; private set; }

        public override Item PageItem
        {
            get
            {
                return base.PageItem;
            }
        }

        public override void Initialize(Rendering rendering)
        {
            base.Initialize(rendering);
            Item item = this.Item;

            if (!item.HasChildren)
            {
                return;
            }

            this.ChildrenItems = item.GetChildren().ToList();
            this.ChildrenAdsItems = item.GetChildren().Where(x => x["Ads"] == "1" && x["Promote"] != "1").ToList();

            this.ChildrenNoAdsItems = item.GetChildren().Where(x => x["Ads"] != "1" && x["Promote"] != "1").ToList();

            this.PromoteItem = item.GetChildren().First(x => x["Promote"] == "1");
        }
    }
}