﻿namespace Spitfire.Library.Models.Navigation
{
    using System.Collections.Generic;
    using System.Linq;

    using Sitecore.Data.Items;
    using Sitecore.Mvc.Presentation;

    /// <summary>
    /// Model for Navigation list
    /// </summary>
    public class NavList : RenderingModel
    {
        /// <summary>
        /// Gets Ordered list of items
        /// </summary>
        /// <value>
        /// Ordered list of items
        /// </value>
        public List<Item> Data { get; private set; }

        /// <summary>Initialize the rendering
        /// </summary>
        /// <param name="rendering">Rendering to initialize
        /// </param>
        public override void Initialize(Rendering rendering)
        {
            base.Initialize(rendering);
            if (this.Item != null)
            {
                this.Data = this.Item.Children.OrderBy(x => x.Name).ToList();
            }
        }
    }
}