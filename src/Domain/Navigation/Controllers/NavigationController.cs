using System.Collections.Generic;
using System.Linq;
using Sitecore.Data.Items;
using Sitecore.Mvc.Controllers;
using Sitecore.Mvc.Presentation;
using Spitfire.Framework.SitecoreExtensions.Extensions;

namespace Spitfire.Navigation.Controllers
{
    using System.Web.Mvc;
    using Spitfire.Navigation.Models;

    public class NavigationController : Controller
    {
        public ActionResult Breadcrumb()
        {
            var items = new NavigationItems()
            {
                Items = this.GetNavigableItems().Reverse(),
            };

            items.ActiveItem = items.Items.LastOrDefault();

            return this.View("Breadcrumb", items);
        }

        private IEnumerable<Item> GetNavigableItems()
        {
            var item = RenderingContext.Current.Rendering.Item;
            while (item != null)
            {
                if (item.IsDerived(Templates.Navigable.ID))
                {
                    yield return item;
                }
                item = item.Parent;
            }
        }

        public ActionResult PrimaryMenu()
        {
            //TODO: Find _NavigationRoot and return the correct NavigationItems
            var items = new NavigationItems();
            return this.View("PrimaryMenu", items);
        }

        public ActionResult SecondaryMenu()
        {
            //TODO: Find _NavigationRoot and return the correct NavigationItems
            var items = new NavigationItems();
            return this.View("SecondaryMenu", items);
        }
    }
}