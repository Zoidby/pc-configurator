using System.Collections.Generic;
using PcConfigurator.Entities;

namespace PcConfigurator.Service
{
    public interface IMotherboardService : IService<Motherboard>
    {
        IEnumerable<Motherboard> GetValidMotherboards(Configuration configuration);
    }
}