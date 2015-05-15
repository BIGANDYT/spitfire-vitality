namespace Spitfire.Models
{
    using System;
    using Constant;
    using Sitecore.Data.Fields;
    using Sitecore.Mvc.Presentation;

    /// <summary>
    /// The model for the video. 
    /// </summary>
    public class VideoModel : RenderingModel
    {
        /// <summary>
        /// Initialize the Video Model
        /// </summary>
        /// <param name="rendering">The Rendering to use</param>
        public override void Initialize(Rendering rendering)
        {
            base.Initialize(rendering);

            var videoItemField = (FileField)Item.Fields[SpitfireConstants.FieldConstants.Video.Source];
            if (videoItemField != null && videoItemField.MediaItem != null)
            {
                VideoPath = Sitecore.Resources.Media.MediaManager.GetMediaUrl(videoItemField.MediaItem);
            }

            var videoTypeItemField = (LookupField) Item.Fields[SpitfireConstants.FieldConstants.Video.Type];
            if (videoTypeItemField != null && videoTypeItemField.TargetItem != null)
            {
                VideoType = videoTypeItemField.TargetItem[SpitfireConstants.FieldConstants.Video.TypeName];
            }
        }

        /// <summary>
        /// The type of video
        /// </summary>
        public String VideoType { get; private set; }

        /// <summary>
        /// The path to the video in the media library
        /// </summary>
        public String VideoPath { get; private set; }
    }
}
