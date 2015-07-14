﻿namespace Spitfire.Library.Models.Video
{
    using Sitecore;
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
        /// Gets the datasource item to use for the model
        /// </summary>
        /// <value>
        /// Item to use for the video model
        /// </value>
        public MediaItem Item { get; private set; }

        /// <summary>
        /// Gets The type of video
        /// </summary>
        /// <value>
        /// Video type value
        /// </value>
        public string VideoType { get; private set; }

        /// <summary>
        /// Gets The path to the video in the media library
        /// </summary>
        /// <value>
        /// Video path value
        /// </value>
        public string VideoPath { get; private set; }

        /// <summary>
        /// Gets a value indicating whether the video should loop (start over again every time it is finished)
        /// </summary>
        /// <value>
        /// Video loop value, whehter to start over everytime the video is finished.
        /// </value>
        public bool Loop { get; private set; }

        /// <summary>
        /// Gets a value indicating whether the video should autoplay (video will start playing as soon as it is ready)
        /// </summary>
        /// <value>
        /// Video Autoplay setting value
        /// </value>
        public bool Autoplay { get; private set; }

        /// <summary>
        /// Gets a value indicating whether the video should play muted
        /// </summary>
        /// <value>
        /// Video mute setting value
        /// </value>
        public bool Mute { get; private set; }

        /// <summary>
        /// Initialize the Video Model
        /// </summary>
        /// <param name="rendering">The Rendering to use</param>
        public void Initialize(Rendering rendering)
        {
            this.Item = !string.IsNullOrWhiteSpace(rendering.DataSource)
                ? Context.Database.GetItem(rendering.DataSource)
                : Context.Item;

            if (this.Item == null)
            {
                return;
            }

            this.VideoPath = MediaManager.GetMediaUrl(this.Item);
            this.VideoType = this.Item.MimeType;

            this.Loop = MainUtil.GetBool(rendering.Parameters[ParameterConstants.Video.Loop], false);
            this.Autoplay = MainUtil.GetBool(rendering.Parameters[ParameterConstants.Video.Autoplay], false);
            this.Mute = MainUtil.GetBool(rendering.Parameters[ParameterConstants.Video.Mute], false);
        }
    }
}