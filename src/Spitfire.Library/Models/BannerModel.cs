namespace Spitfire.Library.Models
{
    using Sitecore;
    using Sitecore.Mvc.Presentation;
    using Spitfire.Library.Constants;
    using Spitfire.SitecoreExtensions.Extensions;
    using Convert = System.Convert;

    /// <summary>
    /// Banner Model
    /// </summary>
    public class BannerModel : IRenderingModel
    {
        /// <summary>
        /// Gets Background Image Url value
        /// </summary>
        /// <value>
        /// Background Image Url value
        /// </value>
        public string BackgroundImageUrl { get; private set; }

        /// <summary>
        /// Gets Title Color value
        /// </summary>
        /// <value>
        /// Title Color value
        /// </value>
        public string TitleColor { get; private set; }

        /// <summary>
        /// Gets SubTitle Color value
        /// </summary>
        /// <value>
        /// SubTitle color value
        /// </value>
        public string SubTitleColor { get; private set; }

        /// <summary>
        /// Gets Link Color value
        /// </summary>
        /// <value>
        /// Link color value
        /// </value>
        public string LinkColor { get; private set; }

        /// <summary>
        /// Gets Logo position to Top
        /// </summary>
        /// <value>
        /// Logo to top css style value
        /// </value>
        public int LogoTop { get; private set; }

        /// <summary>
        /// Gets Logo position to Left
        /// </summary>
        /// <value>
        /// Logo to left css sytle value
        /// </value>
        public int LogoLeft { get; private set; }

        /// <summary>
        /// Gets Banner height value
        /// </summary>
        /// <value>
        /// Banner height value
        /// </value>
        public int BannerHeight { get; private set; }

        /// <summary>
        /// Initilze Rendering              
        /// </summary>
        /// <param name="rendering">Rendering to Initialze
        /// </param>
        public void Initialize(Rendering rendering)
        {
            if (!string.IsNullOrEmpty(rendering.DataSource))
            {
                var datasource = Context.Database.GetItem(rendering.DataSource);

                this.BackgroundImageUrl = datasource.ImageUrl(SpitfireConstants.FieldConstants.Banner.BackgroundImage);

                this.TitleColor = datasource[SpitfireConstants.FieldConstants.Banner.TitleColor];
                this.SubTitleColor = datasource[SpitfireConstants.FieldConstants.Banner.SubtitleColor];
                this.LinkColor = datasource[SpitfireConstants.FieldConstants.Banner.LinkColor];
                var y = double.Parse(datasource[SpitfireConstants.FieldConstants.Banner.LogoTop]);
                this.LogoTop = Convert.ToInt32(30 * y);
                var x = double.Parse(datasource[SpitfireConstants.FieldConstants.Banner.LogoLeft]);
                this.LogoLeft = Convert.ToInt32(8 * x);
                var bannerHeightValue = datasource[SpitfireConstants.FieldConstants.Banner.BannerHeight];
                if (bannerHeightValue == null)
                {
                    return;
                }
                var z = double.Parse(bannerHeightValue);
                this.BannerHeight = Convert.ToInt32(z * 100);
            }
        }
    }
}