using System.Collections.Specialized;
using Sitecore.Data.Items;
using Sitecore.Mvc.Presentation;
namespace Spitfire.Models
{
    public class IconTeaserModel :RenderingModel
    {
        public string TitleColor { get; private set; }
        public string TitleFontSize { get; private set; }
        public string Background { get; private set;}
         public override void Initialize(Rendering rendering)
         {
             base.Initialize(rendering);
             Item item = this.Item;
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

    }

}