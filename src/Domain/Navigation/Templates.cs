using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sitecore.Data;

namespace Spitfire.Navigation
{
    public struct Templates
    {
        public struct Navigable
        {
            public static ID ID => new ID("{49F0FDE3-A402-4A53-AF6E-F6C57D34FD52}");
            public struct Fields
            {
                public static ID NavigationTitle => new ID("{1B483E91-D8C4-4D19-BA03-462074B55936}");
                public static ID ShowInNavigation => new ID("{5585A30D-B115-4753-93CE-422C3455DEB2}");
            }
        }
    }
}
