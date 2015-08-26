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
        public Item GetIdentity()
        {
            Item identityItem;

            if (this.GetIdentityFromContextItem(out identityItem))
                return identityItem;

            if (this.GetIdentityFromContextSite(out identityItem))
                return identityItem;

            return null;
        }

        private bool GetIdentityFromContextSite(out Item identityItem)
        {
            identityItem = null;
            if (Sitecore.Context.Site == null)
                return false;

            var startItem = Sitecore.Context.Site.Database.GetItem(Sitecore.Context.Site.StartPath);
            if (startItem == null)
                return false;
            identityItem = this.GetIdentity(startItem);
            return identityItem != null;
        }

        private bool GetIdentityFromContextItem(out Item identityItem)
        {
            identityItem = null;
            if (Sitecore.Context.Item == null)
                return false;
            identityItem = this.GetIdentity(Sitecore.Context.Item);
            return identityItem != null;
        }

        private Item GetIdentity(Item contextItem)
        {
            if (contextItem == null)
                throw new ArgumentNullException(nameof(contextItem));
            return contextItem.GetAncestorOrSelfOfTemplate(Templates.Identity.ID);
        }
    }
}
