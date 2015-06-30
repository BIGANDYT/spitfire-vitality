﻿namespace Spitfire.Library
{
    using System;
    using Sitecore;
    using Sitecore.Caching;
    using Sitecore.ContentSearch;
    using Sitecore.Data.Items;

    using Spitfire.Library.Constants;

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
                    var root = current.Axes.SelectSingleItem("ancestor-or-self::*[@@templateid='" + SpitfireConstants.TemplateIds.SiteRoot + "']");
                    Items[Key] = root ?? Context.Database.GetItem(Context.Site.StartPath);
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
    }
}