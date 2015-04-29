using System.Collections.Generic;
using PcConfigurator.Entities;

namespace PcConfigurator.Service
{
    public interface IMemoryService : IService<Memory>
    {
        IEnumerable<Memory> GetValidMemories(Configuration configuration);
    }
}