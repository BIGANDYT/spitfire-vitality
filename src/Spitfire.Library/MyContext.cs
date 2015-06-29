namespace Spitfire.Library
{
    using System;
    using Sitecore;
    using Sitecore.Caching;
    using Sitecore.ContentSearch;
    using Sitecore.Data.Items;

    using Spitfire.Library.Constants;

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

        public static Item SiteRoot
        {
            get
            {
                const string Key = "SiteRootItem";
                if (Items[Key] == null)
                {
                    var current = Context.Item;
                    var root = current.Axes.SelectSingleItem("ancestor-or-self::*[@@templateid='" + SpitfireConstants.TemplateIds.SiteRoot + "']");
                    Items[Key] = root ?? Context.Database.GetItem(Context.Site.StartPath);
                }

                return (Item)Items[Key];
            }
        }

        public static ISearchIndex SearchIndex
        {
            get
            {
                const string Key = "ContentSearchMasterIndex";
                if (Items[Key] == null)
                {
                    if (Context.Database == null)
                    {
                        throw new Exception("Sitecore.Context.Database cannot be null");
                    }

                    Items[Key] = Context.Database.Name == "web"
                    ? ContentSearchManager.GetIndex("sitecore_web_index")
                    : ContentSearchManager.GetIndex("sitecore_master_index");
                }

                return (ISearchIndex)Items[Key];
            }
        }

        public static bool IsMaster
        {
            get { return Context.Database != null && Context.Database.Name == "master"; }
        }
    }
}