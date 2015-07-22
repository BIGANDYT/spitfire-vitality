namespace Spitfire.SitecoreExtensions.Extensions
{
    using System;

    using Sitecore.Data;
    using Sitecore.Data.Fields;
    using Sitecore.Data.Items;
    using Sitecore.Links;
    using Sitecore.Mvc.Presentation;
    using Sitecore.Resources.Media;
    using Sitecore.Xml;
    using Sitecore.Xml.Xsl;

    /// <summary>
    /// Extension of Sitecore iems. A few common used fields of Sitecore Items. Make life slightly easier.
    /// </summary>
    public static class ItemExtensions
    {
        /// <summary>
        /// Url of Link items.
        /// </summary>
        /// <param name="item">
        ///     Sitecore item.
        /// </param>
        /// <returns>
        /// Link Item Url value.
        /// </returns>
        /// <exception cref="ArgumentNullException">Item does not exist excpetion.
        /// </exception>
        public static string Url(this Item item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }

            return LinkManager.GetItemUrl(item);
        }

        /// <summary>
        /// Sitecore Image item Url value.
        /// </summary>
        /// <param name="item">Sitecore Image item
        /// </param>
        /// <param name="imageFieldName">Image Item field name
        /// </param>
        /// <param name="options">Image options value
        /// </param>
        /// <returns>
        /// Image item Url.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Throw item does not exist excpetion
        /// </exception>
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

        /// <summary>
        /// Gets a hash-protected imageUrl of the specified imageField, optionally with specific MediaUrlOptions
        /// </summary>
        /// <param name="imageField">The ImageField
        /// </param>
        /// <param name="options">MediaUrlOptions to supply width/height etc.
        /// </param>
        /// <returns>
        /// Hash-protected URL of the resized image
        /// </returns>
        /// <exception cref="ArgumentNullException">Item does not exist exception.
        /// </exception>
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

        /// <summary>
        /// Image Url value of the rendering image item.
        /// </summary>
        /// <param name="rendering"> Rendering which contains the image item.
        /// </param>
        /// <param name="fieldName"> Image item field name
        /// </param>
        /// <param name="options"> Image item options value
        /// </param>
        /// <returns>
        /// Image item Image url
        /// </returns>
        /// <exception cref="ArgumentNullException">Item does not exist exception
        /// </exception>
        public static string ImageUrl(this Rendering rendering, string fieldName, MediaUrlOptions options = null)
        {
            if (rendering == null)
            {
                throw new ArgumentNullException("rendering");
            }

            // Check if this rendering parameter exists
            // Also crude check to guess if this is actually XML.
            var parameters = rendering.Parameters[fieldName];
            if (string.IsNullOrEmpty(parameters) || !parameters.StartsWith("<"))
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

        /// <summary>
        /// Get attached items on a Sitecore item.
        /// </summary>
        /// <param name="item">Parent item.
        /// </param>
        /// <param name="fieldName"> Field name string value.
        /// </param>
        /// <returns>
        /// Attached items as Item array.
        /// </returns>
        /// <exception cref="ArgumentNullException">Item does not exist exception
        /// </exception>
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

        /// <summary>
        /// Get item's ancestor with defined template.
        /// </summary>
        /// <param name="item">Parent item.
        /// </param>
        /// <param name="templateKey">Template id value
        /// </param>
        /// <returns>
        /// Ancestor of the Item
        /// </returns>
        /// <exception cref="ArgumentNullException">Item does not exit exception
        /// </exception>
        public static Item GetAncestorOfTemplate(this Item item, string templateKey)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }

            return item.Axes.SelectSingleItem("ancestor-or-self::*[@@templatekey='" + templateKey + "']");
        }

        public static string LinkFieldUrl(this Item item, string fieldName)
        {
            var linkUrl = new LinkUrl();
            return linkUrl.GetUrl(item, fieldName);
        }
    }
}