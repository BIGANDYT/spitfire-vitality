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
        public static Item GetIdentity(Item item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            var identityItem = GetIdentityFromItem(item);
            if (identityItem != null)
                return identityItem;

            if (GetIdentityFromContextSite(out identityItem))
                return identityItem;

            return null;
        }

        public static Item GetIdentity()
        {
            return GetIdentity(Sitecore.Context.Item);
        }

        private static bool GetIdentityFromContextSite(out Item identityItem)
        {
            identityItem = null;
            if (Sitecore.Context.Site == null)
                return false;

            var startItem = Sitecore.Context.Site.Database.GetItem(Sitecore.Context.Site.StartPath);
            if (startItem == null)
                return false;
            identityItem = GetIdentityFromItem(startItem);
            return identityItem != null;
        }

        private static Item GetIdentityFromItem(Item contextItem)
        {
            if (contextItem == null)
                throw new ArgumentNullException(nameof(contextItem));
            return contextItem.GetAncestorOrSelfOfTemplate(Templates.Identity.ID);
        }
    }
}
