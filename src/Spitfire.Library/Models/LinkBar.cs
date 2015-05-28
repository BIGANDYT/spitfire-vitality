namespace Spitfire.Library.Models
{
    using Sitecore.Mvc.Presentation;
    using System.Collections.Specialized;
    public class LinkBar : RenderingModel
    {
        public override void Initialize(Rendering rendering)
        {
            base.Initialize(rendering);
             NameValueCollection parameters = null;
            if (!string.IsNullOrEmpty(rendering["Parameters"]))
            {
                string rawParameters = rendering["Parameters"];
                parameters = Sitecore.Web.WebUtil.ParseUrlParameters(rawParameters);
            }

            if (parameters != null && parameters.Count > 0)
            {
                Color = parameters["Color"];
                ColorActive = parameters["ColorActive"];
                BackgroundColor = parameters["Background"];
                BackgroundColorActive = parameters["BackgroundActive"];
                FontSize = parameters["FontSize"];
                CssClass = parameters["CssClass"];
            }
        }
        public string Color { get; private set; }
        public string ColorActive { get; private set; }
        public string BackgroundColor { get; private set;}
        public string BackgroundColorActive { get; private set; }
        public string FontSize { get; private set; }
        public string CssClass { get; private set; }
    }
}