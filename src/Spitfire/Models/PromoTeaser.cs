using System.Collections.Specialized;
using System.EnterpriseServices;
using WebGrease.Css.Extensions;

namespace Spitfire.Models
{
    using Sitecore.Mvc.Presentation;
    public class PromoTeaser : RenderingModel
    {

        public override void Initialize(Rendering rendering)
        {
            base.Initialize(rendering);
            //defualt cssClass for promo teaser:
            CssClass = "pricing-item featured";
            NameValueCollection parameters = null;
            if (!string.IsNullOrEmpty(rendering["Parameters"]))
            {
                string rawParameters = rendering["Parameters"];
                parameters =
      Sitecore.Web.WebUtil.ParseUrlParameters(rawParameters);
            }
            if (parameters != null && parameters.Count > 0)
            {
                TitleColor = parameters["TitleColor"];
                TitleFontSize = parameters["TitleFontSize"];
                Background = parameters["Background"];
                CssClass = parameters["CssClass"];
            }
         }
        /// <summary>
        /// Title color
        /// </summary>
        public string TitleColor { get; private set; }
        /// <summary>
        /// Change Title Font size
        /// </summary>
        public string TitleFontSize { get; private set; }
        /// <summary>
        /// Backgournd of the promo teaser
        /// </summary>
        public string Background { get; private set; }
        /// <summary>
        /// cssClass for the teaser
        /// </summary>
        public string CssClass { get; private set;}
    }
}