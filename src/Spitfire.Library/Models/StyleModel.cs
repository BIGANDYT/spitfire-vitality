namespace Spitfire.Library.Models
{
    using Sitecore;
    using Sitecore.Data.Items;
    using Sitecore.Mvc.Presentation;
    using Sitecore.Resources.Media;
    using Sitecore.Xml;

    public class StyleModel : IRenderingModel
    {
        public string CssStyle = string.Empty;
        public string CssClass = string.Empty;
        public string BackgroundImgUrl = string.Empty;

        public virtual void Initialize(Rendering rendering)
        {
            CssStyle = rendering.Parameters["CssStyle"];
            CssClass = rendering.Parameters["CssClass"];
            if (!string.IsNullOrEmpty(rendering.Parameters["BackgroundImage"]))
            {
                var imageId = XmlUtil.GetAttribute("mediaid", XmlUtil.LoadXml(rendering.Parameters["BackgroundImage"]));
                MediaItem imageItem = Context.Database.GetItem(imageId);
                if (imageItem != null)
                {
                    BackgroundImgUrl = MediaManager.GetMediaUrl(imageItem);
                }
            }
        }
    }
}