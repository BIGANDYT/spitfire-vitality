﻿namespace Spitfire.Library.Models.Search
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
        /// Href vaule of link field
        /// </summary>

        public Item PromoteItem { get; private set; }
        public IList<Item> ChildrenItems { get; private set; }

        public IList<Item> ChildrenAdsItems { get; private set; }

        public IList<Item> ChildrenNoAdsItems { get; private set; } 
        
        public override void Initialize(Rendering rendering)
        {
            base.Initialize(rendering);
            Item item = Item;

            ChildrenItems = item.GetChildren().ToList();

            ChildrenAdsItems = item.GetChildren().Where(x => x["Ads"] == "1" && x["Promote"] != "1").ToList();

            ChildrenNoAdsItems = item.GetChildren().Where(x => x["Ads"] != "1" && x["Promote"] !="1").ToList();

            PromoteItem = item.GetChildren().First(x => x["Promote"] == "1");
        }
    }
}