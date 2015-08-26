using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sitecore.Data.Items;
using Sitecore.Mvc.Presentation;

namespace Spitfire.Navigation.Models
{
    public class NavigationItems : RenderingModel
    {
        public IEnumerable<Item> Items { get; set; } 
    }
}
