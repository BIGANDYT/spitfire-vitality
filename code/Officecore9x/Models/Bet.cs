using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Officecore9x.Models
{
    public class Bet
    {
        public string markettype { get; set; }
        public string time { get; set; }
        public string marketName { get; set; }
        public string icon { get; set; }
        public string win { get; set; }
        public string draw { get; set; }
        public string lose { get; set; }
        public string relatedBets { get; set; }
        public int[] graph { get; set; }

        public Bet(string markettype, string time, string marketName, string icon, string win, string draw, string lose, string relatedBets, int[] graph)
        {
            this.markettype = markettype;
            this.time = time;
            this.marketName = marketName;
            this.icon = icon;
            this.win = win;
            this.draw = draw;
            this.lose = lose;
            this.relatedBets = relatedBets;
            this.graph = graph;
        }
    }
}