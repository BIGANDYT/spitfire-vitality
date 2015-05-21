namespace Spitfire.Models
{
    using Sitecore.Mvc.Presentation;
    using System.Collections.Specialized;
    using Spitfire.Constant;

    /// <summary>
    /// Icon Teaser left component
    /// </summary>
    public class IconTeaserLeft : RenderingModel
    {
        public override void Initialize(Rendering rendering)
        {
         base.Initialize(rendering);

            NameValueCollection parameters=null;
            if (!string.IsNullOrEmpty(rendering["Parameters"]))
            {
                string rawParameters = rendering["Parameters"];
                parameters =
      Sitecore.Web.WebUtil.ParseUrlParameters(rawParameters); 
             }
             if (parameters != null&& parameters.Count> 0)
             {
                 TitleColor = parameters["TitleColor"];
                 TitleFontSize = parameters["TitleFontSize"];
                 Background = parameters["Background"];
             }
        }
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
    }
}