namespace Spitfire.Library.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Sitecore.Data.Items;
    using Sitecore.Mvc.Presentation;
    using Spitfire.Library.Constants;

    /// <summary>
    /// Nav bar component
    /// </summary>
    public class NavBarModel : IRenderingModel
    {
        /// <summary>
        /// Gets The item containing the logo
        /// </summary>
        /// <value>
        /// Root item which contains navigation items.
        /// </value>
        public Item NavRoot { get; private set; }

        /// <summary>
        /// Gets Background color value
        /// </summary>
        /// <value>
        /// Background color value
        /// </value>
        public string BackgroundColor { get; private set; }

        /// <summary>
        /// Gets all Navigation items as a list of Sitecore items.
        /// </summary>
        /// <value>
        /// Navigation items
        /// </value>
        public IList<Item> NavItems { get; private set; }
        
        /// <summary>
        /// Initialize the NavBar Model
        /// </summary>
        /// <param name="rendering">The Rendering to use</param>
        public void Initialize(Rendering rendering)
        {
            // Todo: Possibly use Sitecore Search? 
            NavRoot = MyContext.SiteRoot.Axes.SelectSingleItem("./*/*[@@tid='" + SpitfireConstants.TemplateIds.NavBar + "']");

            if (NavRoot != null)
            {
                BackgroundColor = NavRoot[SpitfireConstants.FieldConstants.NavBar.BackgroundColor];
                NavItems = NavRoot.Children.Where(item => string.Equals(item.TemplateID.ToString(), SpitfireConstants.TemplateIds.NavItem, StringComparison.InvariantCultureIgnoreCase)).ToList();
            }
        }
    }
}