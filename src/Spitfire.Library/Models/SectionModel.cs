using Sitecore.Data.Items;
using Sitecore.Mvc.Presentation;
using Sitecore.Resources.Media;
using Sitecore.Xml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Spitfire.Library.Models
{
    public class SectionModel : StyleModel
    {        
        public String Id = "";
        public String SubCssClass = "";

        public override void Initialize(Rendering rendering)
        {
            base.Initialize(rendering);
            Id = rendering.Parameters["Id"];
            SubCssClass = rendering.Parameters["SubCssClass"];
        }
    }
}