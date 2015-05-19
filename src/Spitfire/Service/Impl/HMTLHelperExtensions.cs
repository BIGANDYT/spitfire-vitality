namespace Spitfire
{
    using System;
    using System.Web.Mvc;
    using Framework.Controls;

    /// <summary>
    /// HTML Helper extensions
    /// </summary>
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

        /// <summary>
        /// Create an EditFrame
        /// </summary>
        /// <typeparam name="T">The type T</typeparam>
        /// <param name="helper">The HtmlHelper</param>
        /// <param name="dataSource">The datasource for the item</param>
        /// <param name="buttons">The buttons to use</param>
        /// <returns>An EditFrame</returns>
        public static EditFrameRendering BeginEditFrame<T>(this HtmlHelper<T> helper, String dataSource, String buttons)
        {
            var frame = new EditFrameRendering(helper.ViewContext.Writer, dataSource, buttons);
            return frame;
        }
	}
}
