using Sitecore.Data.Items;
using Spitfire.Framework.SitecoreExtensions.Extensions;

namespace Spitfire.Metadata
{
    public class SiteMetadataService
    {
        public static Item GetSiteMetadata(Item contextItem)
        {
            return contextItem.GetAncestorOrSelfOfTemplate(Templates.SiteMetadata.ID) ?? Sitecore.Context.Site.GetContextItem(Templates.SiteMetadata.ID);
        }
    }
}
