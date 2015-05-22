using Sitecore.Data.Items;
using Sitecore.Mvc.Presentation;
using Sitecore.Resources.Media;
using Sitecore.Xml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Spitfire.Library.Models
{
    public class StyleModel : IRenderingModel
    {
        public String CssStyle = "";
        public String CssClass = "";
        public String BackgroundImgUrl = "";

        public virtual void Initialize(Rendering rendering)
        {
            CssStyle = rendering.Parameters["CssStyle"];
            CssClass = rendering.Parameters["CssClass"];
            if (!String.IsNullOrEmpty(rendering.Parameters["BackgroundImage"]))
            {
                var imageId = XmlUtil.GetAttribute("mediaid", XmlUtil.LoadXml(rendering.Parameters["BackgroundImage"]));
                MediaItem imageItem = Sitecore.Context.Database.GetItem(imageId);
                if (imageItem != null)
                {
                    BackgroundImgUrl = MediaManager.GetMediaUrl(imageItem);
                }
            }
        }
    }
}