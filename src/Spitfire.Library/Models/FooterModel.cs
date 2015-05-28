namespace Spitfire.Library.Models
{
    using Sitecore.Data.Fields;
    using Sitecore.Mvc.Presentation;
    using Sitecore.Resources.Media;

    using Spitfire.Library.Constants;

    public class FooterModel : RenderingModel
    {
        public string BackgroundImageUrl { get; private set; }
        
        public string FooterHeight { get; private set; }

        public override void Initialize(Rendering rendering)
        {
            base.Initialize(rendering);
            var item = this.Item;
            var imgField = (ImageField)item.Fields[SpitfireConstants.FieldConstants.Footer.BackgroundImage];
            if (imgField != null && imgField.MediaItem != null)
            {
                BackgroundImageUrl = MediaManager.GetMediaUrl(imgField.MediaItem);
            }

            FooterHeight = item[SpitfireConstants.FieldConstants.Footer.FooterHeight];
        }
    }
}