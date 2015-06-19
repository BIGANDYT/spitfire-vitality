namespace Spitfire.SitecoreExtensions.Extensions
{
    using System;
    using Sitecore.Data.Fields;
    using Sitecore.Data.Items;
    using Sitecore.Links;
    using Sitecore.Mvc.Presentation;
    using Sitecore.Resources.Media;
    using Sitecore.Xml;

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

            return imageField.ImageUrl(options);
        }

        public static string ImageUrl(this ImageField imageField, MediaUrlOptions options = null)
        {
            if (imageField == null || imageField.MediaItem == null)
            {
                throw new ArgumentNullException("imageField");
            }

            if (options == null)
            {
                options = MediaUrlOptions.Empty;
                int width, height;

                if (int.TryParse(imageField.Width, out width))
                {
                    options.Width = width;
                }

                if (int.TryParse(imageField.Height, out height))
                {
                    options.Height = height;
                }
            }

            return HashingUtils.ProtectAssetUrl(MediaManager.GetMediaUrl(imageField.MediaItem, options));
        }

        public static string ImageUrl(this Rendering rendering, string fieldName, MediaUrlOptions options = null)
        {
            if (rendering == null)
            {
                throw new ArgumentNullException("rendering");
            }

            // Check if this rendering parameter exists
            var parameters = rendering.Parameters[fieldName];
            if (string.IsNullOrEmpty(parameters))
            {
                return string.Empty;
            }

            // Try and parse the parameters into XML
            var xml = XmlUtil.LoadXml(parameters);
            if (xml == null)
            {
                return string.Empty;
            }

            // Check if xml contains mediaid attribute
            var imageId = XmlUtil.GetAttribute("mediaid", xml);
            if (string.IsNullOrEmpty(imageId))
            {
                return string.Empty;
            }

            // Check if mediaid exists in database
            var imageItem = Sitecore.Context.Database.GetItem(imageId);
            if (imageItem == null)
            {
                return string.Empty;
            }

            // If no explicit options supplied, work out width and height from xml parameters
            if (options == null)
            {
                options = MediaUrlOptions.Empty;
                int width, height;

                if (int.TryParse(XmlUtil.GetAttribute("width", xml), out width))
                {
                    options.Width = width;
                }

                if (int.TryParse(XmlUtil.GetAttribute("height", xml), out height))
                {
                    options.Height = height;
                }
            }

            // Return hash protected URL.
            return HashingUtils.ProtectAssetUrl(MediaManager.GetMediaUrl(imageItem, options));
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