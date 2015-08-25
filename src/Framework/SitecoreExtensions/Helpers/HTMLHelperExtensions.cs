namespace Spitfire.SitecoreExtensions.Helpers
{
    using System.Web.Mvc;

    using Spitfire.SitecoreExtensions.Controls;

    /// <summary>
    /// HTML Helper extensions
    /// </summary>
    public static class HtmlHelperExtensions
    {
        /// <summary>
        /// Check whether the Frame is selected. Not in use yet.
        /// </summary>
        /// <param name="html"> Htmlhelper html
        /// </param>
        /// <param name="controller"> With controller = null
        /// </param>
        /// <param name="action">With action = null
        /// </param>
        /// <returns>
        /// IsSelected value
        /// </returns>
        public static string IsSelected(this HtmlHelper html, string controller = null, string action = null)
        {
            const string CssClass = "active";
            var currentAction = (string)html.ViewContext.RouteData.Values["action"];
            var currentController = (string)html.ViewContext.RouteData.Values["controller"];

            if (string.IsNullOrEmpty(controller))
            {
                controller = currentController;
            }

            if (string.IsNullOrEmpty(action))
            {
                action = currentAction;
            }

            return controller == currentController && action == currentAction ? CssClass : string.Empty;
        }

        /// <summary>
        /// Create an EditFrame
        /// </summary>
        /// <typeparam name="T">The type T</typeparam>
        /// <param name="helper">The HtmlHelper</param>
        /// <param name="dataSource">The datasource for the item</param>
        /// <param name="buttons">The buttons to use</param>
        /// <returns>An EditFrame</returns>
        public static EditFrameRendering BeginEditFrame<T>(this HtmlHelper<T> helper, string dataSource, string buttons)
        {
            var frame = new EditFrameRendering(helper.ViewContext.Writer, dataSource, buttons);
            return frame;
        }
    }
}