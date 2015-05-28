namespace Spitfire.Library
{
    using Sitecore;
    using Sitecore.Caching;

    public class MyContext
    {
        private static readonly ItemsContext ItemsInternal;

        static MyContext()
        {
            ItemsInternal = new ItemsContext();
        }

        public static ItemsContext Items
        {
            get
            {
                return ItemsInternal;
            }
        }

        // public static IBasePage BasePage
        // {
        // get
        // {
        // const string Key = "BasePage";
        // if (Items[Key] == null)
        // {
        // if (Context.Item == null)
        // {
        // throw new Exception("Sitecore.Context.Item cannot be null");
        // }

        // var basePage = new BasePage();
        // Items[Key] = MappingHelper.MapBasePage(ref basePage, Context.Item);
        // }

        // return (IBasePage)Items[Key];
        // }
        // }

        // public static ISearchIndex SearchIndex
        // {
        // get
        // {
        // const string key = "ContentSearchMasterIndex";
        // if (Items[key] == null)
        // {
        // if (Sitecore.Context.Database == null)
        // {
        // throw new Exception("Sitecore.Context.Database cannot be null");
        // }

        // Items[key] = Sitecore.Context.Database.Name == "web"
        // ? ContentSearchManager.GetIndex("sitecore_web_index")
        // : ContentSearchManager.GetIndex("sitecore_master_index");
        // }

        // return (ISearchIndex)Items[key];
        // }
        // }

        // public static ContextSearchResultItem CurrentSearchResultItem
        // {
        // get
        // {
        // if (Sitecore.Context.Item == null) return null;

        // using (var s = SearchIndex.CreateSearchContext())
        // {
        // return s.GetQueryable<ContextSearchResultItem>()
        // .FirstOrDefault(x => x.ItemId == Sitecore.Context.Item.ID && (!IsMaster || x.IsLatestVersion));
        // }
        // }
        //// }

        public static bool IsMaster
        {
            get { return Context.Database != null && Context.Database.Name == "master"; }
        }
    }
}