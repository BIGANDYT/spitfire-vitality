namespace Spitfire.Models
{
    using System;
    using Constant;
    using Sitecore.Mvc.Presentation;

    public class BannerModel : IRenderingModel
    {
        public String BackgroundImageUrl { get; set; }
        public String TitleColor { get; set; }
        public String SubTitleColor { get; set; }
        public String LinkColor { get; set; }
        public Int32 LogoTop { get; set; }
        public Int32 LogoLeft { get; set; }
        public Int32 BannerHeight { get; set; }

        public void Initialize(Rendering rendering)
        {
            if (!String.IsNullOrEmpty(rendering.DataSource))
            {
                var datasource = Sitecore.Context.Database.GetItem(rendering.DataSource);
                var imgField = ((Sitecore.Data.Fields.ImageField)datasource.Fields[SpitfireConstants.FieldConstants.Banner.BackgroundImage]);
                if (imgField != null && imgField.MediaItem != null)
                {
                    BackgroundImageUrl = Sitecore.Resources.Media.MediaManager.GetMediaUrl(imgField.MediaItem);
                }

                TitleColor = datasource[SpitfireConstants.FieldConstants.Banner.TitleColor];
                SubTitleColor = datasource[SpitfireConstants.FieldConstants.Banner.SubtitleColor];
                LinkColor = datasource[SpitfireConstants.FieldConstants.Banner.LinkColor];
                var y = Double.Parse(datasource[SpitfireConstants.FieldConstants.Banner.LogoTop]);
                LogoTop = Convert.ToInt32(30 * y);
                var x = Double.Parse(datasource[SpitfireConstants.FieldConstants.Banner.LogoLeft]);
                LogoLeft = Convert.ToInt32(8 * x);
                var BannerHeightValue = datasource[SpitfireConstants.FieldConstants.Banner.BannerHeight];
                if (BannerHeightValue != null)
                {
                    var z = Double.Parse(BannerHeightValue);
                    BannerHeight = Convert.ToInt32(z * 100);
                }
            }
        }
    }
}