namespace Spitfire.SitecoreExtensions.Extensions
{
    using System;
    using System.Collections.Generic;

    using Sitecore.Data.Fields;
    using Sitecore.Data.Items;
    using Sitecore.Links;
    using Sitecore.Resources.Media;

    public static class ItemExtensions
    {
        public static string Url(this Item item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }

            return LinkManager.GetItemUrl(item);
        }

        public static string ImageUrl(this Item item, string imageFieldName, MediaUrlOptions options = null)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }

            if (imageFieldName == null)
            {
                throw new ArgumentNullException("imageFieldName");
            }

            var imageField = (ImageField)item.Fields[imageFieldName];
            if (imageField == null || imageField.MediaItem == null)
            {
                return string.Empty;
            }

            return options == null 
                ? MediaManager.GetMediaUrl(imageField.MediaItem) 
                : MediaManager.GetMediaUrl(imageField.MediaItem, options);
        }

        public static Item[] TargetItems(this Item item, string fieldName)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }

            if (fieldName == null)
            {
                throw new ArgumentNullException("fieldName");
            }

            var mf = (MultilistField)item.Fields[fieldName];
            return mf == null ? new Item[0] : mf.GetItems();
        }

        public static Item GetAncestorOfTemplate(this Item item, string templateKey)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }

            return item.Axes.SelectSingleItem("ancestor-or-self::*[@@templatekey='" + templateKey + "']");
        }
    }
}