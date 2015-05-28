namespace Spitfire.Library.Models
{
    using System.Collections.Generic;
    using System.Linq;

    using Sitecore;
    using Sitecore.Data.Items;
    using Sitecore.Mvc.Presentation;

    public class NavList : IRenderingModel
    {
        public List<Item> Data { get; set; }

        public void Initialize(Rendering rendering)
        {
            if (!string.IsNullOrEmpty(rendering.DataSource))
            {
                Item datasource = Context.Database.GetItem(rendering.DataSource);
                Data = datasource.Children.OrderBy(x => x.Name).ToList();
            }
        }
    }
}