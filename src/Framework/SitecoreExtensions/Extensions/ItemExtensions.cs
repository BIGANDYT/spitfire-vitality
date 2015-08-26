using System;
using System.Linq;
using Sitecore.Data;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Data.Managers;
using Sitecore.Data.Templates;
using Sitecore.Links;
using Sitecore.Resources.Media;
using Sitecore.Xml.Xsl;

namespace Spitfire.Framework.SitecoreExtensions.Extensions
{
    /// <summary>
    /// Extension of Sitecore iems. A few common used fields of Sitecore Items. Make life slightly easier.
    /// </summary>
    public static class ItemExtensions
    {
        public static string Url(this Item item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            return LinkManager.GetItemUrl(item);
        }

        public static string ImageUrl(this Item item, string imageFieldName, MediaUrlOptions options = null)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            if (imageFieldName == null)
                throw new ArgumentNullException(nameof(imageFieldName));

            var imageField = (ImageField) item.Fields[imageFieldName];
            if (imageField == null || imageField.MediaItem == null)
                return string.Empty;

            return imageField.ImageUrl(options);
        }

        public static Item[] TargetItems(this Item item, string fieldName)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            if (fieldName == null)
                throw new ArgumentNullException(nameof(fieldName));

            var mf = (MultilistField) item.Fields[fieldName];
            return mf == null ? new Item[0] : mf.GetItems();
        }

        public static Item GetAncestorOrSelfOfTemplate(this Item item, ID templateID)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));
            if (item.TemplateID == templateID)
                return item;
            return item.Axes.GetAncestors().FirstOrDefault(i => i.IsDerived(templateID));
        }

        public static string LinkFieldUrl(this Item item, ID fieldID)
        {
            var linkUrl = new LinkUrl();
            return linkUrl.GetUrl(item, fieldID.ToString());
        }

        public static bool IsDerived(this Item item, ID templateId)
        {
            if (item == null)
                return false;
            return !templateId.IsNull && item.IsDerived(item.Database.Templates[templateId]);
        }

        public static bool IsDerived(this Item item, Item templateItem)
        {
            if (item == null)
                return false;
            if (templateItem == null)
                return false;
            var itemTemplate = TemplateManager.GetTemplate(item);
            return itemTemplate != null && (itemTemplate.ID == templateItem.ID || itemTemplate.DescendsFrom(templateItem.ID));
        }
    }
}