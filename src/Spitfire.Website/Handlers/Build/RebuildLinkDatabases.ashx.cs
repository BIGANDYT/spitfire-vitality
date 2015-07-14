namespace Spitfire.Website.Handlers.Build
{
    using System.Web;
    using Sitecore;
    using Sitecore.Configuration;
    using Sitecore.Data;
    using Sitecore.Diagnostics;
    using Sitecore.Security.Accounts;

    public class RebuildLinkDatabases : IHttpHandler
    {
        private readonly Database webDb = Factory.GetDatabase("web");
        private readonly Database masterDb = Factory.GetDatabase("master");
        private readonly Database coreDb = Factory.GetDatabase("core");

        public void ProcessRequest(HttpContext context)
        {
            User user = User.FromName(@"sitecore\admin", false);
            using (new UserSwitcher(user))
            {
                Log.Info("CI: Rebuilding Core Link Database", this);
                Globals.LinkDatabase.Rebuild(coreDb);

                Log.Info("CI: Rebuilding Master Link Database", this);
                Globals.LinkDatabase.Rebuild(masterDb);

                Log.Info("CI: Rebuilding Web Link Database", this);
                Globals.LinkDatabase.Rebuild(webDb);
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}