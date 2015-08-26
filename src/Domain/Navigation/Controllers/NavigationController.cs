using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Spitfire.Navigation.Models;

namespace Spitfire.Navigation.Controllers
{
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
