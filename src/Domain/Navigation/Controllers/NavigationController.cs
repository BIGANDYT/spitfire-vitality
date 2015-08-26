using System.Collections.Generic;
using System.Linq;
using Sitecore;
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
        private Item _navigationRoot;

        public ActionResult Breadcrumb()
        {
            var items = new NavigationItems()
            {
                Items = this.GetNavigationHierarchy().Reverse(),
            };

            items.ActiveItem = items.Items.LastOrDefault();

            return this.View("Breadcrumb", items);
        }

        private IEnumerable<Item> GetNavigationHierarchy()
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
            var items = new NavigationItems()
            {
                Items = this.GetPrimaryNavigationItems(),
                ActiveItem = this.GetActiveNavigationItem(),
            };

            items.ActiveItem = items.Items.LastOrDefault();
            return this.View("PrimaryMenu", items);
        }

        private Item GetActiveNavigationItem()
        {
            //TODO
            return null;
        }

        private IEnumerable<Item> GetPrimaryNavigationItems()
        {
            var items = new List<Item>();
            if (MainUtil.GetBool(this.NavigationRoot[Templates.NavigationRoot.Fields.IncludeRootInPrimaryMenu], false))
            {
                if (this.NavigationRoot.IsDerived(Templates.Navigable.ID))
                {
                    items.Add(this.NavigationRoot);
                }
            }
            items.AddRange(this.NavigationRoot.Children.Where(i => i.IsDerived(Templates.Navigable.ID)));
            return items;
        }

        public Item NavigationRoot
        {
            get { return this._navigationRoot ?? (this._navigationRoot = NavigationRootService.GetNavigationRoot(RenderingContext.Current.Rendering.Item)); }
        }

        public ActionResult SecondaryMenu()
        {
            //TODO: Find _NavigationRoot and return the correct NavigationItems
            var items = new NavigationItems();
            return this.View("SecondaryMenu", items);
        }
    }
}