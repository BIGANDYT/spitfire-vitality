using System;
using System.Collections;
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
        public string socialDisplay { get; set; }
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

            //Findout dispaly social icons or not
            ID id = new ID("{D6303669-FBF0-46B9-836A-74AD60DB0913}");
            socialDisplay = this.Item[id];
            if (string.IsNullOrEmpty(socialDisplay))
            {
                socialDisplay = "show";
            }
            if (string.Equals(socialDisplay, "yes", StringComparison.CurrentCultureIgnoreCase) || string.Equals(socialDisplay, "true", StringComparison.CurrentCultureIgnoreCase))
            {
                socialDisplay = "show";
            }
            if (string.Equals(socialDisplay, "No", StringComparison.CurrentCultureIgnoreCase) || string.Equals(socialDisplay, "Hide", StringComparison.CurrentCultureIgnoreCase) || string.Equals(socialDisplay, "false", StringComparison.CurrentCultureIgnoreCase) || string.Equals(socialDisplay, "0", StringComparison.CurrentCultureIgnoreCase) || string.Equals(socialDisplay, "Not", StringComparison.CurrentCultureIgnoreCase))
            {
                socialDisplay = "none";
            }
            
        }

    }
}