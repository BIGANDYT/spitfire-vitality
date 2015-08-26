using Sitecore.Data.Items;
using Spitfire.Framework.SitecoreExtensions.Extensions;

namespace Spitfire.Navigation
{
    public class NavigationRootService
    {
        public static Item GetNavigationRoot(Item contextItem)
        {
            return contextItem.GetAncestorOrSelfOfTemplate(Templates.NavigationRoot.ID) ?? Sitecore.Context.Site.GetContextItem(Templates.NavigationRoot.ID);
        }
    }
}
