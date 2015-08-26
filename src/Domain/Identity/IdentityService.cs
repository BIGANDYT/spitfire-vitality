using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sitecore.Data.Items;
using Sitecore.Sites;
using Spitfire.Framework.SitecoreExtensions.Extensions;

namespace Spitfire.Identity
{
    public class IdentityService
    {
        public static Item GetIdentity(Item contextItem)
        {
            return contextItem.GetAncestorOrSelfOfTemplate(Templates.Identity.ID) ?? Sitecore.Context.Site.GetContextItem(Templates.Identity.ID);
        }
    }
}
