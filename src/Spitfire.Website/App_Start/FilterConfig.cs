namespace Spitfire.Website
{
    using System.Web.Mvc;

    /// <summary>
    /// Register global filters. These filters are applied to every action and controllers.
    /// </summary>
    public class FilterConfig
    {
        /// <summary>
        /// Register mvc fliters: error fileters, action filters and etc.
        /// </summary>
        /// <param name="filters">Filters need to be registered. 
        /// </param>
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}