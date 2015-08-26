namespace Spitfire.Navigation.Controllers
{
    using System.Web.Mvc;

    public class NavigationController : Controller
    {
        private readonly INavigationService navigationService;

        public NavigationController() : this(new NavigationService())
        {
        }

        public NavigationController(INavigationService navigationService)
        {
            this.navigationService = navigationService;
        }

        public ActionResult Breadcrumb()
        {
            var items = navigationService.GetBreadcrumb();
            return this.View("Breadcrumb", items);
        }

        public ActionResult PrimaryMenu()
        {
            var items = navigationService.GetPrimaryMenu();
            return this.View("PrimaryMenu", items);
        }

        public ActionResult SecondaryMenu()
        {
            var items = navigationService.GetSecondaryMenu();
            return this.View("SecondaryMenu", items);
        }
    }
}