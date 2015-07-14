﻿namespace Spitfire.Library.Models
{
    using System.Collections.Specialized;
    using Sitecore.Mvc.Presentation;
    using Sitecore.Web;

    /// <summary>
    /// Image Left Component
    /// </summary>
    public class ImageModel : RenderingModel
    {
       /// <summary>
       /// Gets Title Color
       /// </summary>
       /// <value>
       /// Title color value
       /// </value>
        public string TitleColor { get; private set; }

        /// <summary>
        /// Gets Tilte Font Size
        /// </summary>
        /// <value>
        /// Title Font size value
        /// </value>
        public string TitleFontSize { get; private set; }

        /// <summary>
        /// Gets Background color value
        /// </summary>
        /// <value>
        /// Background color value
        /// </value>
        public string Background { get; private set; }

        /// <summary>
        /// Gets div height value
        /// </summary>
        /// <value>
        /// Div height value
        /// </value>
        public string DivHeight { get; private set; }

        /// <summary>
        /// Gets Image height value
        /// </summary>
        /// <value>
        /// Image height value
        /// </value>
        public string ImageHeight { get; private set; }

        /// <summary>
        /// Gets Image width value
        /// </summary>
        /// <value>
        /// Image Width value
        /// </value>
        public string ImageWidth { get; private set; }

        /// <summary>
        /// Initialize Rendering
        /// </summary>
        /// <param name="rendering">Rendering to intialize
        /// </param>
        public override void Initialize(Rendering rendering)
        {
            base.Initialize(rendering);
            NameValueCollection parameters = null;
            if (!string.IsNullOrEmpty(rendering["Parameters"]))
            {
                string rawParameters = rendering["Parameters"];
                parameters = WebUtil.ParseUrlParameters(rawParameters);
            }

            if (parameters == null || parameters.Count <= 0)
            {
                return;
            }

            this.TitleColor = parameters["TitleColor"];
            this.TitleFontSize = parameters["TitleFontSize"];
            this.Background = parameters["Background"];
            this.DivHeight = parameters["CompHeight"];
            this.ImageHeight = !string.IsNullOrEmpty(parameters["ImageHeight"]) ? parameters["ImageHeight"] : "auto";

            if (!string.IsNullOrEmpty(parameters["ImageWidth"]))
            {
                this.ImageWidth = parameters["ImageWidth"];
            }
            else
            {
                this.ImageHeight = "auto";
            }
        }
    }
}