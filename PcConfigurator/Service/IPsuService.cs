using System.Collections.Generic;
using PcConfigurator.Entities;

namespace PcConfigurator.Service
{
    public interface IPsuService : IService<Psu>
    {
        IEnumerable<Psu> GetValidPsus(Configuration configuration);
    }
}