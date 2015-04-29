using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PcConfigurator.Models.HomeModels
{
    public class ConfigurationFormModel
    {
        public string CaseFormat { get; set; }
        public string CaseBrand { get; set; }
        public string CaseId { get; set; }
        public string MotherboardId { get; set; }
        public string CpuId { get; set; }
        public string GpuId { get; set; }
        public string MemoryId { get; set; }
        public string PsuId { get; set; }
        public string HarddriveId { get; set; }
        public string CpuBrand { get; set; }
        public string CpuSocket { get; set; }


        public IEnumerable<string> CpuBrandList { get; set; }
        public IEnumerable<string> CpuFormatList { get; set; }


        public string Message { get; set; }
    }
}