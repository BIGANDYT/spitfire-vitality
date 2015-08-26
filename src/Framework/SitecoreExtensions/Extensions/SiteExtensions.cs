using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sitecore.Data;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Resources.Media;
using Sitecore.Sites;

namespace Spitfire.Framework.SitecoreExtensions.Extensions
{
    public static class SiteExtensions
    {
        public static Item GetContextItem(this SiteContext site, ID derivedFromTemplateID)
        {
            if (site == null)
                throw new ArgumentNullException(nameof(site));

            var startItem = site.Database.GetItem(Sitecore.Context.Site.StartPath);
            if (startItem == null)
                return null;
            return startItem.GetAncestorOrSelfOfTemplate(derivedFromTemplateID);
        }
    }
}
