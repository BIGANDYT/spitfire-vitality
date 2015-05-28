namespace Spitfire.Library.Models
{
    using System.Collections.Specialized;
    using Sitecore.Mvc.Presentation;
    using Sitecore.Web;

    public class ImageRightModel : RenderingModel
    {
        public string TitleColor { get; private set; }

        public string TitleFontSize { get; private set; }

        public string Background { get; private set; }

        public string DivHeight { get; private set; }

        public string ImageHeight { get; private set; }

        public string ImageWidth { get; private set; }

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
                DivHeight = parameters["CompHeight"];
                if (!string.IsNullOrEmpty(parameters["ImageHeight"]))
                {
                    ImageHeight = parameters["ImageHeight"];
                }
                else
                {
                    ImageHeight = "auto";
                }

                if (!string.IsNullOrEmpty(parameters["ImageWidth"]))
                {
                    ImageWidth = parameters["ImageWidth"];
                }
                else
                {
                    ImageWidth = "auto";
                }
            }
        }
    }
}