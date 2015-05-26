using System;
using Sitecore.Data.Items;
using Spitfire.Library.Constants;

namespace Spitfire.Library.Models
{
    using Sitecore.Mvc.Presentation;

    public class FooterModel : RenderingModel
    {
        public String BackgroundImageUrl { get; private set; }
        public override void Initialize(Rendering rendering)
        {
            base.Initialize(rendering);
            Item item = this.Item;
            var imgField = ((Sitecore.Data.Fields.ImageField)item.Fields[SpitfireConstants.FieldConstants.Footer.BackgroundImage]);
            if (imgField != null && imgField.MediaItem != null)
            {
                BackgroundImageUrl = Sitecore.Resources.Media.MediaManager.GetMediaUrl(imgField.MediaItem);
            }
        }
    }
}