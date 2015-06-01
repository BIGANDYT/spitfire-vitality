namespace Spitfire.Library.Models
{
    using Sitecore;
    using Sitecore.Data.Fields;
    using Sitecore.Data.Items;
    using Sitecore.Mvc.Presentation;
    using Sitecore.Resources.Media;

    using Spitfire.Library.Constants;

    /// <summary>
    /// The model for the video. 
    /// </summary>
    public class VideoModel : IRenderingModel
    {
        /// <summary>
        /// The item to use for the model
        /// </summary>
        public Item Item { get; private set; }

        /// <summary>
        /// The type of video
        /// </summary>
        public string VideoType { get; private set; }

        /// <summary>
        /// The path to the video in the media library
        /// </summary>
        public string VideoPath { get; private set; }

        /// <summary>
        /// Value indicating whether the video should loop
        /// </summary>
        public bool Loop { get; private set; }

        /// <summary>
        /// Value indicating whether the video should autoplay
        /// </summary>
        public bool Autoplay { get; private set; }

        /// <summary>
        /// Value indicating whether the video should play muted
        /// </summary>
        public bool Mute { get; private set; }

        /// <summary>
        /// Initialize the Video Model
        /// </summary>
        /// <param name="rendering">The Rendering to use</param>
        public void Initialize(Rendering rendering)
        {
            if (!string.IsNullOrWhiteSpace(rendering.DataSource))
            {
                Item = Context.Database.GetItem(rendering.DataSource);
            }
            else
            {
                Item = Context.Item;
            }

            var videoItemField = (FileField)Item.Fields[SpitfireConstants.FieldConstants.Video.Source];
            if (videoItemField != null && videoItemField.MediaItem != null)
            {
                VideoPath = MediaManager.GetMediaUrl(videoItemField.MediaItem);
            }

            var videoTypeItemField = (LookupField)Item.Fields[SpitfireConstants.FieldConstants.Video.Type];
            if (videoTypeItemField != null && videoTypeItemField.TargetItem != null)
            {
                VideoType = videoTypeItemField.TargetItem[SpitfireConstants.FieldConstants.VideoType.TypeName];
            }

            Loop = MainUtil.GetBool(rendering.Parameters[SpitfireConstants.ParameterConstants.Loop], false);
            Autoplay = MainUtil.GetBool(rendering.Parameters[SpitfireConstants.ParameterConstants.Autoplay], false);
            Mute = MainUtil.GetBool(rendering.Parameters[SpitfireConstants.ParameterConstants.Mute], false);
        }
    }
}
