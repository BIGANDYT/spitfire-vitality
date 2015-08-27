﻿using System.Web;
using System.Web.Mvc;
using Sitecore.Data.Items;
using Sitecore.Mvc.Helpers;
using Spitfire.SitecoreExtensions.Controls;

namespace Spitfire.Framework.SitecoreExtensions.Extensions
{
    /// <summary>
    /// HTML Helper extensions
    /// </summary>
    public static class HtmlHelperExtensions
    {
        public static HtmlString ImageField(this SitecoreHelper helper, string fieldName, Item item, int? mh = null, int? mw = null, string cssClass = null, bool disableWebEditing = false)
        {
            return helper.Field(fieldName, item, new { mh, mw, DisableWebEdit = disableWebEditing, @class = cssClass });
        }

        public static EditFrameRendering BeginEditFrame<T>(this HtmlHelper<T> helper, string dataSource, string buttons)
        {
            var frame = new EditFrameRendering(helper.ViewContext.Writer, dataSource, buttons);
            return frame;
        }
    }
}