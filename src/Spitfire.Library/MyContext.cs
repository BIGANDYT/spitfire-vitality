namespace Spitfire.Library
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Constants;
    using Sitecore;
    using Sitecore.Caching;
    using Sitecore.ContentSearch;
    using Sitecore.Data.Items;

    using Spitfire.Library.Models;
    using Spitfire.Library.Services;

    /// <summary>
    /// A helper for find related information of the Context
    /// </summary>
    public static class MyContext
    {
        /// <summary>
        /// Static Member of MyContext class
        /// </summary>
        private static readonly ItemsContext ItemsInternal;

        /// <summary>
        /// Initializes static members of the <see cref="MyContext"/> class 
        /// </summary>
        static MyContext()
        {
            ItemsInternal = new ItemsContext();
        }

        /// <summary>
        /// Gets ItemContext item
        /// </summary>
        /// <value>
        /// ItemContext item
        /// </value>
        public static ItemsContext Items
        {
            get
            {
                return ItemsInternal;
            }
        }

        /// <summary>
        /// Gets current context item's site root item.
        /// </summary>
        /// <value>
        /// Site Root item
        /// </value>
        public static Item SiteRoot
        {
            get
            {
                const string Key = "SiteRootItem";
                if (Items[Key] == null)
                {
                    var current = Context.Item;
                    var root = current.Axes.SelectSingleItem("ancestor-or-self::*[@@templateid='" + TemplateIds.SiteRoot + "']");
                    Items[Key] = root ?? Context.Database.GetItem(Context.Site.StartPath);
                }

                return (Item)Items[Key];
            }
        }

        /// <summary>
        /// Gets current context item's site root item.
        /// </summary>
        /// <value>
        /// Site Root item
        /// </value>
        public static Item Footer
        {
            get
            {
                const string Key = "FooterItem";
                if (Items[Key] == null)
                {
                    var siteRoot = SiteRoot;
                    if (siteRoot != null)
                    {
                        var footerItem = siteRoot.Children.FirstOrDefault(x => x.TemplateName == "Footer");
                        Items[Key] = footerItem;
                    }
                }

                return (Item)Items[Key];
            }
        }

        /// <summary>
        /// Gets Item search index value
        /// </summary>
        /// <exception cref="Exception">Database does not exist exception
        /// </exception>
        /// <value>
        /// Item search index value
        /// </value>
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

        /// <summary>
        /// Gets a value indicating whether the Context database is Master
        /// </summary>
        /// <value>
        /// Whether the Context database is master
        /// </value>
        public static bool IsMaster
        {
            get { return Context.Database != null && Context.Database.Name == "master"; }
        }

        /// <summary>
        /// Gets a reference of <see cref="AssetRequirementService"/> for this page request
        /// </summary>
        public static AssetRequirementService AssetRequirementService
        {
            get
            {
                const string Key = "JavaScriptService";
                if (Items[Key] == null)
                {
                    Items[Key] = new AssetRequirementService();
                }

                return (AssetRequirementService)Items[Key];
            }
        }

        public static List<string> RequiredCss
        {
            get
            {
                const string Key = "RequiredCss";
                if (Items[Key] == null)
                {
                    Items[Key] = new List<string>();
                }

                return (List<string>)Items[Key];
            }
        }
    }
}