namespace Spitfire.Navigation
{
    using Sitecore;
    using Sitecore.Data.Items;

    using Spitfire.Navigation.Models;

    public interface INavigationService
    {
        Item GetNavigationRoot();

        NavigationItems GetBreadcrumb();

        NavigationItems GetPrimaryMenu();

        NavigationItems GetSecondaryMenu();
    }

    public class NavigationService : INavigationService
    {
        public NavigationService()
        {
            //TODO: Find _NavigationRoot and return the correct NavigationItems
        }

        public Item GetNavigationRoot()
        {
            return Context.Database.GetItem("/sitecore/content/spitfire/home");
        }

        public NavigationItems GetBreadcrumb()
        {
            return new NavigationItems();
        }

        public NavigationItems GetPrimaryMenu()
        {
            return new NavigationItems();
        }

        public NavigationItems GetSecondaryMenu()
        {
            return new NavigationItems();
        }
    }
}