using System.Collections.Generic;
using PcConfigurator.Entities;

namespace PcConfigurator.Service
{
    public interface ICpuService : IService<Cpu>
    {
        IEnumerable<Cpu> GetValidCpus(Configuration configuration);

        IEnumerable<string> GetCpuBrands();
        IEnumerable<string> GetCpuSocketsByBrand(string caseBrand);
        IEnumerable<Cpu> GetCpusBySocket(string cpuSocket);
    }
}