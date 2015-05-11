using Sitecore.Data.Items;
using Sitecore.Mvc.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Spitfire.Models
{
    public class BannerModel : IRenderingModel
    {

        public String BackgroundImageUrl { get; set; }
        public String TitleColor { get; set; }
        public String SubTitleColor { get; set; }
        public String LinkColor { get; set; }
        public int LogoTop { get; set; }
        public int LogoLeft { get; set; }

        public void Initialize(Rendering rendering)
        {
            if (!String.IsNullOrEmpty(rendering.DataSource))
            {
                Item datasource = Sitecore.Context.Database.GetItem(rendering.DataSource);
                Sitecore.Data.Fields.ImageField imgField = ((Sitecore.Data.Fields.ImageField)datasource.Fields["Background Image"]);
                if (imgField != null && imgField.MediaItem != null)
                {
                    BackgroundImageUrl = Sitecore.Resources.Media.MediaManager.GetMediaUrl(imgField.MediaItem);
                }
                TitleColor = datasource.Fields["Title Color"].Value;
                SubTitleColor = datasource.Fields["SubTitle Color"].Value;
                LinkColor = datasource.Fields["Link Color"].Value;
                var y = double.Parse(datasource.Fields["Logo Top"].Value);
                LogoTop = Convert.ToInt32(30 * y);
                var x = double.Parse(datasource.Fields["Logo Left"].Value);
                LogoLeft = Convert.ToInt32(8 * x);
            }
        }
    }
}