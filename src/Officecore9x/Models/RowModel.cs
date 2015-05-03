using Sitecore.Data.Items;
using Sitecore.Mvc.Presentation;
using Sitecore.Resources.Media;
using Sitecore.Xml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Officecore9x.Models
{
    public class RowModel : IRenderingModel
    {
        public String BackgroundImgUrl = "";
        public String CssStyle = "";
        public String CssClass = "";

        public void Initialize(Rendering rendering)
        {
            if (!String.IsNullOrEmpty(rendering.Parameters["BackgroundImage"]))
            {
                var imageId = XmlUtil.GetAttribute("mediaid", XmlUtil.LoadXml(rendering.Parameters["BackgroundImage"]));
                MediaItem imageItem = Sitecore.Context.Database.GetItem(imageId);
                if (imageItem != null)
                {
                    BackgroundImgUrl = MediaManager.GetMediaUrl(imageItem);
                }
            }

            CssStyle = rendering.Parameters["CssStyle"];
            CssClass = rendering.Parameters["CssClass"];
        }
    }
}