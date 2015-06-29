namespace Spitfire.Library.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Sitecore;
    using Sitecore.Data.Fields;
    using Sitecore.Data.Items;
    using Sitecore.Mvc.Presentation;
    using Spitfire.Library.Constants;

    /// <summary>
    /// OwlTeaser component model
    /// </summary>
    public class OwlTeaserModel : IRenderingModel
    {
        /// <summary>
        /// Datasource Item
        /// </summary>
        public Item Item { get; private set; }

        /// <summary>
        /// return a list of selected items for owlTeaser component
        /// </summary>
        public IList<Item> OwlTeasers { get; private set; }

        /// <summary>
        /// Users can choose to display or hide the social icons with this parameter
        /// </summary>
        public string SocialDisplay { get; set; }

        /// <summary>
        /// The rendering of the context page
        /// </summary>
        /// <param name="rendering">Rendering to initialize</param>
        public void Initialize(Rendering rendering)
        {
            this.Item = !string.IsNullOrWhiteSpace(rendering.DataSource)
               ? Context.Database.GetItem(rendering.DataSource)
               : Context.Item;

            if (!string.IsNullOrEmpty(this.Item[SpitfireConstants.FieldConstants.TeaserGroup.Source]))
            {
                MultilistField source = this.Item.Fields[SpitfireConstants.FieldConstants.TeaserGroup.Source];

                if (source != null)
                {
                   this.OwlTeasers = source.GetItems().ToList();
                }
            }

            // Findout dispaly social icons or not; this is droplist field
           this.SocialDisplay = this.Item[SpitfireConstants.FieldConstants.TeaserGroup.Display];

            if (string.IsNullOrEmpty(this.SocialDisplay) || string.Equals(this.SocialDisplay, "show", StringComparison.CurrentCultureIgnoreCase))
            {
                this.SocialDisplay = "show";
            }

            if (string.Equals(this.SocialDisplay, "none", StringComparison.CurrentCultureIgnoreCase))
            {
               this.SocialDisplay = "none";
            }
        }
    }
}