using Sitecore.Collections;
using Sitecore.Data.Items;
using Sitecore.Mvc.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Officecore9x.Models
{
    public class GameList : IRenderingModel
    {
        public List<Item> Data { get; set; }

        public void Initialize(Rendering rendering)
        {
            if (!String.IsNullOrEmpty(rendering.DataSource))
            {
                Item datasource = Sitecore.Context.Database.GetItem(rendering.DataSource);
                Data = datasource.Children.OrderBy(x => x.Name).ToList();
            }
        }
    }
}