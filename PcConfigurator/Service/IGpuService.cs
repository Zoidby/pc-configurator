using System.Collections.Generic;
using PcConfigurator.Entities;

namespace PcConfigurator.Service
{
    public interface IGpuService : IService<Gpu>
    {
        IEnumerable<Gpu> GetValidGpus(Configuration configuration);
    }
}