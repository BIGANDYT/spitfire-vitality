namespace Spitfire.Library.Models
{
    using Sitecore.Mvc.Presentation;
    using Spitfire.Library.Constants;
    using Spitfire.SitecoreExtensions.Extensions;

    public class FooterModel : RenderingModel
    {
        public string BackgroundImageUrl { get; private set; }
        
        public string FooterHeight { get; private set; }

        public override void Initialize(Rendering rendering)
        {
            base.Initialize(rendering);
            var item = this.Item;
            BackgroundImageUrl = item.ImageUrl(SpitfireConstants.FieldConstants.Footer.BackgroundImage);
            FooterHeight = item[SpitfireConstants.FieldConstants.Footer.FooterHeight];
        }
    }
}