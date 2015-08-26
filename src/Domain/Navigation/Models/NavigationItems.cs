namespace Spitfire.Navigation.Models
{
    using System.Collections.Generic;
    using Sitecore.Data.Items;
    using Sitecore.Mvc.Presentation;

    public class NavigationItems : RenderingModel
    {
        public IEnumerable<Item> Items { get; set; }
        public Item ActiveItem { get; set; }
    }
}