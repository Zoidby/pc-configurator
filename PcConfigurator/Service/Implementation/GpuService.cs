using System.Collections.Generic;
using System.Linq;
using PcConfigurator.Entities;
using PcConfigurator.Repositories;

namespace PcConfigurator.Service.Implementation
{
    public class GpuService : Service<Gpu>, IGpuService
    {
        private IGpuRepository _gpuRepo;
        private IConfigurationService _configService;

        public GpuService(IGpuRepository gpuRepo, IConfigurationService configService)
            : base(gpuRepo)
        {
            _gpuRepo = gpuRepo;
            _configService = configService;
        }

        public IEnumerable<Gpu> GetValidGpus(Configuration configuration)
        {
            IQueryable<Gpu> result = _gpuRepo.GetAll();

            if (configuration.Motherboard != null)
            {
                result = result.Where(g => configuration.Motherboard.ExpansionSlots.Contains(g.ExpansionSlot));
            }
            if (configuration.Psu != null)
            {
                result = result.Where(g => g.PowerConsumption <= configuration.Psu.ActualPower - _configService.GetTotalConsumption(configuration));
            }

            return result.AsEnumerable();
        }
    }
}