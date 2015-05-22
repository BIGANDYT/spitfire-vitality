namespace Spitfire.Website
{
    using System.Web.Optimization;

    using Sitecore.Web;

    public class MvcApplication : Application
    {
        protected void Application_Start()
        {
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}