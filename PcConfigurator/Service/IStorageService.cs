using System.Collections.Generic;
using PcConfigurator.Entities;

namespace PcConfigurator.Service
{
    public interface IStorageService : IService<Harddrive>
    {
        IEnumerable<Harddrive> GetValidHarddrives(Configuration configuration);
        IEnumerable<int> GetStorageCapacities();
        IEnumerable<string> GetStorageBrandsByCapacity(int storageCapacity);
        IEnumerable<Harddrive> GetStoragesByCapacityAndBrand(int storageCapacity, string storageBrand);
    }
}