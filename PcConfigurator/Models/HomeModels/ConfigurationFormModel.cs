using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PcConfigurator.Models.HomeModels
{
    public class ConfigurationFormModel
    {
        public string CaseBrand { get; set; }
        public string CaseId { get; set; }

        public string MotherboardId { get; set; }
        public string MotherboardFormat { get; set; }
        public string MotherboardBrand { get; set; }
        public int MotherboardPowerConsumption { get; set; }

        public string CpuId { get; set; }
        public string CpuBrand { get; set; }
        public string CpuSocket { get; set; }
        public int CpuPowerConsumption { get; set; }

        public string GpuId { get; set; }
        public string GpuBrand { get; set; }
        public string GpuManufacturer { get; set; }
        public int GpuPowerConsumption { get; set; }

        public string MemoryId { get; set; }
        public int MemoryCapacity { get; set; }
        public string MemoryBrand { get; set; }
        public int MemoryPowerConsumption { get; set; }

        public string PsuId { get; set; }
        public string PsuBrand { get; set; }

        public string StorageId { get; set; }
        public int StorageCapacity { get; set; }
        public string StorageBrand { get; set; }
        public int StoragePowerConsumption { get; set; }




        public IEnumerable<string> CpuBrandList { get; set; }
        public IEnumerable<int> MemoryCapacityList { get; set; }
        public IEnumerable<int> StorageCapacityList { get; set; }
        public IEnumerable<string> GpuManufacturerList { get; set; }


        public string Message { get; set; }
    }
}