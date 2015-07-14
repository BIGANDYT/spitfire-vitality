namespace Spitfire.Website.Handlers.Build
{
    using System.Web;
    using Sitecore.ContentSearch;
    using Sitecore.Diagnostics;
    using Sitecore.Security.Accounts;

    public class RebuildSearchIndexes : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            var index = context.Request["index"];
            Assert.IsNotNullOrEmpty(index, "Please supply index");

            User user = User.FromName(@"sitecore\admin", false);
            using (new UserSwitcher(user))
            {
                IndexRebuild(index);
            }

            context.Response.Write("Finished RebuildSearchIndexes: " + index + "\n");
            context.Response.End();
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        private void IndexRebuild(string indexName)
        {
            Log.Info("CI: RebuildSearchIndexes started: " + indexName, this);

            if (indexName == "system")
            {
                Sitecore.Search.SearchManager.GetIndex("system").Rebuild();
            }
            else
            {
                ISearchIndex index = ContentSearchManager.GetIndex(indexName);
                index.Rebuild();    
            }
            
            Log.Info("CI: RebuildSearchIndexes finished: " + indexName, this);
        }
    }
}