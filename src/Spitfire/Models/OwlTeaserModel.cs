namespace Spitfire.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Constant;
    using Sitecore.Data;
    using Sitecore.Data.Fields;
    using Sitecore.Data.Items;
    using Sitecore.Diagnostics;
    using Sitecore.Mvc.Presentation;

    public class OwlTeaserModel :RenderingModel
    {
        public IList<Item> OwlTeasers { get; private set; }
        public String SocialDisplay { get; set; }

        public override void Initialize(Rendering rendering)
        {
            base.Initialize(rendering);
            if (!string.IsNullOrEmpty(Item[SpitfireConstants.FieldConstants.TeaserGroup.Source]))
            {
                MultilistField source = Item.Fields[SpitfireConstants.FieldConstants.TeaserGroup.Source];

                if (source != null)
                {
                    OwlTeasers = source.GetItems().ToList();
                }
            }

            // Findout dispaly social icons or not
            // TODO: This needs to be fixed. What is this ID pointing to?
            var id = new ID("{D6303669-FBF0-46B9-836A-74AD60DB0913}");
            SocialDisplay = Item[id];
            if (string.IsNullOrEmpty(SocialDisplay))
            {
                SocialDisplay = "show";
            }

            if (string.Equals(SocialDisplay, "yes", StringComparison.CurrentCultureIgnoreCase) || string.Equals(SocialDisplay, "true", StringComparison.CurrentCultureIgnoreCase))
            {
                SocialDisplay = "show";
            }

            if (string.Equals(SocialDisplay, "No", StringComparison.CurrentCultureIgnoreCase) || string.Equals(SocialDisplay, "Hide", StringComparison.CurrentCultureIgnoreCase) || string.Equals(SocialDisplay, "false", StringComparison.CurrentCultureIgnoreCase) || string.Equals(SocialDisplay, "0", StringComparison.CurrentCultureIgnoreCase) || string.Equals(SocialDisplay, "Not", StringComparison.CurrentCultureIgnoreCase))
            {
                SocialDisplay = "none";
            }
        }
    }
}