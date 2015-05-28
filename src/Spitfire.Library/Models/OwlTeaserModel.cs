namespace Spitfire.Library.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Sitecore.Data.Fields;
    using Sitecore.Data.Items;
    using Sitecore.Mvc.Presentation;

    using Spitfire.Library.Constants;

    /// <summary>
    /// OwlTeaser component model
    /// </summary>
    public class OwlTeaserModel : RenderingModel
    {
        /// <summary>
        /// return a list of selected items for owlTeaser component
        /// </summary>
        public IList<Item> OwlTeasers { get; private set; }

        /// <summary>
        /// Users can choose to display or hide the social icons with this parameter
        /// </summary>
        public string SocialDisplay { get; set; }

        /// <summary>
        /// the rendering of the context page
        /// </summary>
        /// <param name="rendering"></param>
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

            // Findout dispaly social icons or not; this is droplist field
            SocialDisplay = Item[SpitfireConstants.FieldConstants.TeaserGroup.Display];

            if (string.IsNullOrEmpty(SocialDisplay) || string.Equals(SocialDisplay, "show", StringComparison.CurrentCultureIgnoreCase))
            {
                SocialDisplay = "show";
            }

            if (string.Equals(SocialDisplay, "none", StringComparison.CurrentCultureIgnoreCase))
            {
                SocialDisplay = "none";
            }
        }
    }
}