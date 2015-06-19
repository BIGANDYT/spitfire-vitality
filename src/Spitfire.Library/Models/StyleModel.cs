namespace Spitfire.Library.Models
{
    using Sitecore.Mvc.Presentation;
    using Spitfire.SitecoreExtensions.Extensions;

    public class StyleModel : IRenderingModel
    {
        public string CssStyle { get; set; }
        
        public string CssClass { get; set; }

        public string BackgroundImgUrl { get; set; }

        public virtual void Initialize(Rendering rendering)
        {
            CssStyle = rendering.Parameters["CssStyle"];
            CssClass = rendering.Parameters["CssClass"];
            BackgroundImgUrl = rendering.ImageUrl("BackgroundImage");
        }
    }
}