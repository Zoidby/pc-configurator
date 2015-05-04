using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using PcConfigurator.Entities;
using PcConfigurator.Repositories;

namespace PcConfigurator.Service.Implementation
{
    public class MemoryService : Service<Memory>, IMemoryService
    {
        private IMemoryRepository _memoryRepo;
        private IConfigurationService _configurationService;

        public MemoryService(IMemoryRepository memoryRepo, IConfigurationService configurationService)
            : base(memoryRepo)
        {
            _memoryRepo = memoryRepo;
            _configurationService = configurationService;
        }

        public IEnumerable<Memory> GetValidMemories(Configuration configuration)
        {
            IQueryable<Memory> result = _memoryRepo.GetAll();

            if (configuration.Motherboard != null)
            {
                result =
                    result.Where(
                        m =>
                            m.TotalCapacity <= configuration.Motherboard.MemoryMaximum &&
                            m.Count <= configuration.Motherboard.MemorySlots);
            }
            if (configuration.Psu != null)
            {
                result = result.Where(g => g.PowerConsumption <= configuration.Psu.ActualPower - _configurationService.GetTotalConsumption(configuration));
            }

            return result.AsEnumerable();
        }

        public IEnumerable<int> GetMemoryCapacities()
        {
            return _memoryRepo.GetAll().Select(m => m.TotalCapacity).Distinct().AsEnumerable();
        }

        public IEnumerable<string> GetMemoryBrandsByCapacity(int memoryCapacity)
        {
            return
                _memoryRepo.GetAll()
                    .Where(m => m.TotalCapacity == memoryCapacity)
                    .Select(m => m.Brand)
                    .Distinct()
                    .AsEnumerable();
        }

        public IEnumerable<Memory> GetMemoriesByCapacityAndBrand(int memoryCapacity, string memoryBrand)
        {
            return
                _memoryRepo.GetAll()
                    .Where(m => m.TotalCapacity == memoryCapacity && m.Brand == memoryBrand)
                    .AsEnumerable();
        }
    }
}