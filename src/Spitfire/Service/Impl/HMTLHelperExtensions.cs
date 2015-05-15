namespace Spitfire
{
    using System;
    using System.Web.Mvc;

    /// <summary>
    /// Helper methods for the Html Helper class
    /// </summary>
    public static class HMTLHelperExtensions
    {
        /// <summary>
        /// Get css class when selected
        /// </summary>
        /// <param name="html">The HtmlHelper instance</param>
        /// <param name="controller">The controller</param>
        /// <param name="action">The action</param>
        /// <returns>'active' if selected, empty string otherwise</returns>
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
