namespace Spitfire.Website.Handlers.Build
{
    using System.Web;
    using Sitecore;
    using Sitecore.Configuration;
    using Sitecore.Data;
    using Sitecore.Diagnostics;
    using Sitecore.Security.Accounts;

    /// <summary>
    /// Rebuild the core, master and web link databases
    /// </summary>
    public class RebuildLinkDatabases : IHttpHandler
    {
        /// <summary>
        /// The web database 
        /// </summary>
        private readonly Database _webDb = Factory.GetDatabase("web");

        /// <summary>
        /// The master database
        /// </summary>
        private readonly Database _masterDb = Factory.GetDatabase("master");

        /// <summary>
        /// The core database
        /// </summary>
        private readonly Database _coreDb = Factory.GetDatabase("core");

        /// <summary>
        /// Do the actual rebuild as an admin
        /// </summary>
        /// <param name="context">The httpcontext</param>
        public void ProcessRequest(HttpContext context)
        {
            User user = User.FromName(@"sitecore\admin", false);
            using (new UserSwitcher(user))
            {
                Log.Info("CI: Rebuilding Core Link Database", this);
                Globals.LinkDatabase.Rebuild(_coreDb);

                Log.Info("CI: Rebuilding Master Link Database", this);
                Globals.LinkDatabase.Rebuild(_masterDb);

                Log.Info("CI: Rebuilding Web Link Database", this);
                Globals.LinkDatabase.Rebuild(_webDb);
            }
        }

        /// <summary>
        /// This always returns false, but is required because of IHttpHandler
        /// </summary>
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}