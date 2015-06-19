namespace Spitfire.Library.Models
{
    using Sitecore;
    using Sitecore.Data.Fields;
    using Sitecore.Mvc.Presentation;
    using Sitecore.Resources.Media;
    using Spitfire.Library.Constants;
    using Spitfire.SitecoreExtensions.Extensions;

    using Convert = System.Convert;

    public class BannerModel : IRenderingModel
    {
        public string BackgroundImageUrl { get; set; }

        public string TitleColor { get; set; }

        public string SubTitleColor { get; set; }

        public string LinkColor { get; set; }

        public int LogoTop { get; set; }

        public int LogoLeft { get; set; }

        public int BannerHeight { get; set; }

        public void Initialize(Rendering rendering)
        {
            if (!string.IsNullOrEmpty(rendering.DataSource))
            {
                var datasource = Context.Database.GetItem(rendering.DataSource);

                BackgroundImageUrl = datasource.ImageUrl(SpitfireConstants.FieldConstants.Banner.BackgroundImage);

                TitleColor = datasource[SpitfireConstants.FieldConstants.Banner.TitleColor];
                SubTitleColor = datasource[SpitfireConstants.FieldConstants.Banner.SubtitleColor];
                LinkColor = datasource[SpitfireConstants.FieldConstants.Banner.LinkColor];
                var y = double.Parse(datasource[SpitfireConstants.FieldConstants.Banner.LogoTop]);
                LogoTop = Convert.ToInt32(30 * y);
                var x = double.Parse(datasource[SpitfireConstants.FieldConstants.Banner.LogoLeft]);
                LogoLeft = Convert.ToInt32(8 * x);
                var bannerHeightValue = datasource[SpitfireConstants.FieldConstants.Banner.BannerHeight];
                if (bannerHeightValue != null)
                {
                    var z = double.Parse(bannerHeightValue);
                    BannerHeight = Convert.ToInt32(z * 100);
                }
            }
        }
    }
}