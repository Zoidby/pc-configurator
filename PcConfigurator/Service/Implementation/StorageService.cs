using System.Collections.Generic;
using System.Linq;
using PcConfigurator.Entities;
using PcConfigurator.Repositories;

namespace PcConfigurator.Service.Implementation
{
    public class StorageService : Service<Harddrive>, IStorageService
    {
        private readonly IHarddriveRepository _harddriveRepo;
        private readonly IConfigurationService _configService;

        public StorageService(IHarddriveRepository harddriveRepo, IConfigurationService configService)
            : base(harddriveRepo)
        {
            _harddriveRepo = harddriveRepo;
            _configService = configService;
        }

        public IEnumerable<Harddrive> GetValidHarddrives(Configuration configuration)
        {
            IQueryable<Harddrive> result = _harddriveRepo.GetAll();

            if (configuration.Motherboard != null)
            {
                result = result.Where(h => configuration.Motherboard.HarddriveInterfaces.Contains(h.Interface));
            }
            if (configuration.Psu != null)
            {
                result = result.Where(g => g.PowerConsumption <= configuration.Psu.ActualPower - _configService.GetTotalConsumption(configuration));
            }

            return result.AsEnumerable();
        }

        public IEnumerable<int> GetStorageCapacities()
        {
            return _harddriveRepo.GetAll().Select(s => s.Capacity).Distinct().AsEnumerable();
        }

        public IEnumerable<string> GetStorageBrandsByCapacity(int storageCapacity)
        {
            return _harddriveRepo.GetAll().Where(s => s.Capacity == storageCapacity).Select(s => s.Brand).Distinct().AsEnumerable();
        }

        public IEnumerable<Harddrive> GetStoragesByCapacityAndBrand(int storageCapacity, string storageBrand)
        {
            return
                _harddriveRepo.GetAll()
                    .Where(s => s.Capacity == storageCapacity && s.Brand == storageBrand)
                    .AsEnumerable();
        }
    }
}