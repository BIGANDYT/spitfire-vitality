namespace Spitfire.Navigation
{
    using System.Collections.Generic;
    using System.Linq;

    using Sitecore;
    using Sitecore.Data.Items;
    using Sitecore.Mvc.Presentation;

    using Spitfire.Framework.SitecoreExtensions.Extensions;
    using Spitfire.Navigation.Models;

    public interface INavigationService
    {
        Item GetNavigationRoot(Item contextItem);

        NavigationItems GetBreadcrumb();

        NavigationItems GetPrimaryMenu();

        NavigationItems GetSecondaryMenu();
    }

    public class NavigationService : INavigationService
    {
        private readonly Item navigationRoot;

        public NavigationService()
        {
            navigationRoot = GetNavigationRoot(RenderingContext.Current.Rendering.Item);
        }

        public Item GetNavigationRoot(Item contextItem)
        {
            return contextItem.GetAncestorOrSelfOfTemplate(Templates.NavigationRoot.ID) ?? Context.Site.GetContextItem(Templates.NavigationRoot.ID);
        }

        public NavigationItems GetBreadcrumb()
        {
            var items = new NavigationItems
            {
                Items = GetNavigationHierarchy().Reverse(),
            };

            items.ActiveItem = items.Items.LastOrDefault();
            return items;
        }

        public NavigationItems GetPrimaryMenu()
        {
            var items = new NavigationItems
            {
                Items = GetPrimaryNavigationItems(),
                ActiveItem = GetActiveNavigationItem(),
            };

            items.ActiveItem = items.Items.LastOrDefault();
            return items;
        }

        public NavigationItems GetSecondaryMenu()
        {
            return new NavigationItems();
        }

        private Item GetActiveNavigationItem()
        {
            // TODO:
            return null;
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

        private IEnumerable<Item> GetPrimaryNavigationItems()
        {
            var items = new List<Item>();
            if (MainUtil.GetBool(navigationRoot[Templates.NavigationRoot.Fields.IncludeRootInPrimaryMenu], false))
            {
                if (navigationRoot.IsDerived(Templates.Navigable.ID))
                {
                    items.Add(navigationRoot);
                }
            }

            items.AddRange(navigationRoot.Children.Where(i => i.IsDerived(Templates.Navigable.ID)));
            return items;
        }
    }
}