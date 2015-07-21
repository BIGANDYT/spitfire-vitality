namespace Spitfire.Library.Models.Core.Components.Images
{
    using Sitecore;
    using Sitecore.Mvc.Presentation;

    using Constants;
    using Spitfire.SitecoreExtensions.Extensions;

    using Convert = System.Convert;

    /// <summary>
    /// Banner Model
    /// </summary>
    public class ImageBanner : IRenderingModel
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
            if (string.IsNullOrEmpty(rendering.DataSource))
            {
                return;
            }

            var datasource = Context.Database.GetItem(rendering.DataSource);

            BackgroundImageUrl = datasource.ImageUrl(FieldConstants.Banner.BackgroundImage.ToString());

            TitleColor = datasource[FieldConstants.Banner.TitleColor];
            SubTitleColor = datasource[FieldConstants.Banner.SubtitleColor];
            LinkColor = datasource[FieldConstants.Banner.LinkColor];
            var y = double.Parse(datasource[FieldConstants.Banner.LogoTop]);
            LogoTop = Convert.ToInt32(30 * y);
            var x = double.Parse(datasource[FieldConstants.Banner.LogoLeft]);
            LogoLeft = Convert.ToInt32(8 * x);
            var bannerHeightValue = datasource[FieldConstants.Banner.BannerHeight];
            if (bannerHeightValue == null)
            {
                return;
            }

            var z = double.Parse(bannerHeightValue);
            BannerHeight = Convert.ToInt32(z * 100);
        }
    }
}