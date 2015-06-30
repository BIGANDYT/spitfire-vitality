namespace Spitfire.Library.Models
{
    using System.Collections.Generic;
    using System.Linq;

    using Sitecore;
    using Sitecore.Data.Items;
    using Sitecore.Mvc.Presentation;

    /// <summary>
    /// Model for Navigation list
    /// </summary>
    public class NavList : IRenderingModel
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
        public void Initialize(Rendering rendering)
        {
            if (!string.IsNullOrEmpty(rendering.DataSource))
            {
                Item datasource = Context.Database.GetItem(rendering.DataSource);
                this.Data = datasource.Children.OrderBy(x => x.Name).ToList();
            }
        }
    }
}