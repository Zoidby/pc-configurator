using System.Collections.Generic;
using PcConfigurator.Entities;

namespace PcConfigurator.Service
{
    public interface IGpuService : IService<Gpu>
    {
        IEnumerable<Gpu> GetValidGpus(Configuration configuration);
        IEnumerable<string> GetGpuManufacturers();
        IEnumerable<Gpu> GetGpusByBrandAndManufacturer(string gpuBrand, string gpuManufacturer);
        IEnumerable<string> GetGpuBrandsByManufacturer(string gpuManufacturer);
    }
}