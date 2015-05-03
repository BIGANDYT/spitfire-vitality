using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Officecore9x.Service;
using Officecore9x.Service.Impl;
using Sitecore.Data.Items;
using Sitecore.Mvc.Presentation;
using Sitecore.Sites;

namespace Officecore9x.Models
{
    public class IFrame : IRenderingModel
    {
        public string Source;

        public void Initialize(Rendering rendering)
        {
            if (!String.IsNullOrEmpty(rendering.DataSource))
            {
                Item i = Sitecore.Context.Database.GetItem(rendering.DataSource);
                Source = i.Fields["IFrame Link"].Value;
            }
        }
    }
}