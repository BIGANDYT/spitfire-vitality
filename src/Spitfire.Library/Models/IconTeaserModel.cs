﻿namespace Spitfire.Library.Models
{
    using System.Collections.Specialized;
    using Sitecore.Mvc.Presentation;
    using Sitecore.Web;

    /// <summary>
    /// Icon Teaser Model
    /// </summary>
    public class IconTeaserModel : RenderingModel
    {
        /// <summary>
        /// Get Title color setting
        /// </summary>
        public string TitleColor { get; private set; }

        /// <summary>
        /// Set Title font size
        /// </summary>
        public string TitleFontSize { get; private set; }

        /// <summary>
        /// Set background color
        /// </summary>
        public string Background { get; private set; }

        public override void Initialize(Rendering rendering)
        {
            base.Initialize(rendering);
            NameValueCollection parameters = null;
            if (!string.IsNullOrEmpty(rendering["Parameters"]))
            {
                string rawParameters = rendering["Parameters"];
                parameters = WebUtil.ParseUrlParameters(rawParameters);
            }

            if (parameters != null && parameters.Count > 0)
            {
                TitleColor = parameters["TitleColor"];
                TitleFontSize = parameters["TitleFontSize"];
                Background = parameters["Background"];
            }
        }
    }
}