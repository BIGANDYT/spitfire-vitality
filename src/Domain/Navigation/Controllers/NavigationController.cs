namespace Spitfire.Navigation.Controllers
{
    using System.Web.Mvc;
    using Spitfire.Navigation.Models;

    public class NavigationController : Controller
    {
        public ActionResult Breadcrumb()
        {
            //TODO: Find _NavigationRoot and return the correct NavigationItems
            var items = new NavigationItems();
            return this.View("Breadcrumb", items);
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