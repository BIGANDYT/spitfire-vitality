﻿using System;
using System.Collections.Generic;
using System.Linq;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Mvc.Presentation;

namespace Spitfire.Teasers.Models
{
    /// <summary>
    /// OwlTeaser component model
    /// </summary>
    public class OwlCarousel : RenderingModel
    {
        /// <summary>
        /// Gets the list of selected items for owlTeaser component
        /// </summary>
        /// <value>
        /// OwlTeaser Seleted Items
        /// </value>
        public IList<Item> OwlTeasers { get; private set; }

        /// <summary>
        /// Gets display value hide or show: Users can choose to display or hide the social icons with this parameter
        /// </summary>
        /// <value>
        /// Hide or show for Social icons
        /// </value>
        public string SocialDisplay { get; private set; }

        /// <summary>
        /// The rendering of the context page
        /// </summary>
        /// <param name="rendering">Rendering to initialize</param>
        public override void Initialize(Rendering rendering)
        {
            base.Initialize(rendering);

            if (!string.IsNullOrEmpty(Item[FieldConstants.TeaserGroup.Source]))
            {
                MultilistField source = Item.Fields[FieldConstants.TeaserGroup.Source];

                if (source != null)
                {
                    this.OwlTeasers = source.GetItems().ToList();
                }
            }

            // Findout dispaly social icons or not; this is droplist field
            this.SocialDisplay = Item[FieldConstants.TeaserGroup.Display];

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