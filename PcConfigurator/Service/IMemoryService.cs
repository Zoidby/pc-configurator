using System.Collections.Generic;
using PcConfigurator.Entities;

namespace PcConfigurator.Service
{
    public interface IMemoryService : IService<Memory>
    {
        IEnumerable<Memory> GetValidMemories(Configuration configuration);
        IEnumerable<int> GetMemoryCapacities();
        IEnumerable<string> GetMemoryBrandsByCapacity(int memoryCapacity);
        IEnumerable<Memory> GetMemoriesByCapacityAndBrand(int memoryCapacity, string memoryBrand);
    }
}