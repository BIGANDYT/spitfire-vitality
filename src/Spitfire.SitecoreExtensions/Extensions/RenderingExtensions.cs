using System.Collections.Specialized;
using Sitecore.Mvc.Presentation;
using Sitecore.Web;

namespace Spitfire.SitecoreExtensions.Extensions
{
    public static class RenderingExtensions
    {
        public static StylingRenderingParameters GetStylingParams(this Rendering rendering)
        {
            return new StylingRenderingParameters(rendering);
        }
    }

    public class StylingRenderingParameters
    {
        public StylingRenderingParameters(Rendering rendering)
        {
            NameValueCollection parameters = null;
            if (!string.IsNullOrEmpty(rendering["Parameters"]))
            {
                var rawParameters = rendering["Parameters"];
                parameters = WebUtil.ParseUrlParameters(rawParameters);
            }

            if (parameters == null || parameters.Count <= 0)
                return;

            this.Color = parameters.Get(Constants.RenderingParameters.Color);
            this.ColorActive = parameters.Get(Constants.RenderingParameters.ColorActive);
            this.BackgroundColor = parameters.Get(Constants.RenderingParameters.Background);
            this.BackgroundColorActive = parameters.Get(Constants.RenderingParameters.BackgroundActive);
            this.FontSize = parameters.Get(Constants.RenderingParameters.FontSize);
            this.CssClass = parameters.Get(Constants.RenderingParameters.CssClass);
            this.BackgroundImageUrl = parameters.Get(Constants.RenderingParameters.BackgroundImageUrl);
            this.CssStyle = parameters.Get(Constants.RenderingParameters.CssStyle);
            this.SubCssClass = parameters.Get(Constants.RenderingParameters.SubCssClass);
            this.Animation = parameters.Get(Constants.RenderingParameters.Animation);
        }

        public string Color { get; private set; }
        public string ColorActive { get; private set; }
        public string BackgroundColor { get; private set; }
        public string BackgroundColorActive { get; private set; }
        public string FontSize { get; private set; }
        public string CssClass { get; private set; }
        public string BackgroundImageUrl { get; private set; }
        public string CssStyle { get; private set; }
        public string SubCssClass { get; private set; }
        public string Animation { get; private set; }
    }
}