using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using PcConfigurator.Entities;

namespace PcConfigurator.Models.HomeModels
{
    public class HomeIndexModel
    {
        public IEnumerable<string> CpuBrandList { get; set; } 

        public string Message { get; set; }


        public ConfigurationFormModel FormModel;
    }
}