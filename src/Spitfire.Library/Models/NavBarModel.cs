namespace Spitfire.Library.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Sitecore;
    using Sitecore.Data.Items;
    using Sitecore.Mvc.Presentation;

    using Spitfire.Library.Constants;

    public class NavBarModel : IRenderingModel
    {
        /// <summary>
        /// The item containing the logo
        /// </summary>
        public Item NavRoot { get; private set; }

        public string BackgroundColor { get; private set; }

        public IList<Item> NavItems { get; private set; }
        

        /// <summary>
        /// Initialize the NavBar Model
        /// </summary>
        /// <param name="rendering">The Rendering to use</param>
        public void Initialize(Rendering rendering)
        {
            // Todo: Possibly use Sitecore Search? 
            NavRoot = Context.Database.SelectSingleItem(Context.Site.StartPath + "//*[@@tid='" + SpitfireConstants.TemplateIds.NavBar + "']");

            if (NavRoot != null)
            {
                BackgroundColor = NavRoot[SpitfireConstants.FieldConstants.NavBar.BackgroundColor];
                NavItems = NavRoot.Children.Where(item => string.Equals(item.TemplateID.ToString(), SpitfireConstants.TemplateIds.NavItem, StringComparison.InvariantCultureIgnoreCase)).ToList();
            }
        }
    }
}