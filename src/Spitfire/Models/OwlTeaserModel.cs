﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Sitecore.Data;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.Mvc.Presentation;

namespace Spitfire.Models
{
    public class OwlTeaserModel :RenderingModel
    {
        public IList<Item> OwlTeasers { get; private set; }
        public override void Initialize(Rendering rendering)
        {
            base.Initialize(rendering);
            if (!string.IsNullOrEmpty(this.Item["source"]))
            {
                MultilistField source = this.Item.Fields["source"];

                if (source != null)
                {
                    OwlTeasers = source.GetItems().ToList();
                    //Iterate over all the selected items by using the property TargetIDs
                    foreach (var item in source.GetItems())
                    {
                        Log.Error("item" + item.Name + item["Title"], this);
                    }
                   
                }

            }
           
        }

    }
}