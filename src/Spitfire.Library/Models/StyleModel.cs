namespace Spitfire.Library.Models
{
    using Sitecore;
    using Sitecore.Mvc.Presentation;
    using Sitecore.Resources.Media;
    using Sitecore.Xml;

    public class StyleModel : IRenderingModel
    {
        public string CssStyle { get; set; }
        
        public string CssClass { get; set; }

        public string BackgroundImgUrl { get; set; }

        public virtual void Initialize(Rendering rendering)
        {
            CssStyle = rendering.Parameters["CssStyle"];
            CssClass = rendering.Parameters["CssClass"];
            BackgroundImgUrl = string.Empty;

            if (!string.IsNullOrEmpty(rendering.Parameters["BackgroundImage"]))
            {
                var imageId = XmlUtil.GetAttribute("mediaid", XmlUtil.LoadXml(rendering.Parameters["BackgroundImage"]));
                var imageItem = Context.Database.GetItem(imageId);
                if (imageItem != null)
                {
                    BackgroundImgUrl = MediaManager.GetMediaUrl(imageItem);
                }
            }
        }
    }
}