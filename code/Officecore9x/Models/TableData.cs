using Officecore9x.Service;
using Officecore9x.Service.Impl;
using Sitecore.Mvc.Presentation;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Officecore9x.Models
{
    public class TableData : IRenderingModel
    {
        public ArrayList Data { get; set; }
        private IBettingService bettingservice;

        public void Initialize(Rendering rendering)
        {
            bettingservice = new BettingService();
            Data = bettingservice.GetBets(rendering.Parameters["markettype"]);
        }
    }
}