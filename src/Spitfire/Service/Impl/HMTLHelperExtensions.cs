namespace Spitfire
{
    using System;
    using System.Web.Mvc;

    public static class HMTLHelperExtensions
    {
        public static String IsSelected(this HtmlHelper html, String controller = null, String action = null)
        {
            const String cssClass = "active";
            var currentAction = (String)html.ViewContext.RouteData.Values["action"];
            var currentController = (String)html.ViewContext.RouteData.Values["controller"];

            if (String.IsNullOrEmpty(controller))
            {
                controller = currentController;
            }

            if (String.IsNullOrEmpty(action))
            {
                action = currentAction;
            }

            return controller == currentController && action == currentAction ? cssClass : String.Empty;
        }
	}
}
