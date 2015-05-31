using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PcConfigurator.Models.CaseModels
{
    public class CaseModel
    {
        public string Id { get; set; }
        public string Brand { get; set; }
        public string Name { get; set; }
        public String MotherboardCompatibility { get; set; }
    }
}