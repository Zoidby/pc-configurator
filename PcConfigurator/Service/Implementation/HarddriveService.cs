using System.Collections.Generic;
using System.Linq;
using PcConfigurator.Entities;
using PcConfigurator.Repositories;

namespace PcConfigurator.Service.Implementation
{
    public class HarddriveService : Service<Harddrive>, IHarddriveService
    {
        private readonly IHarddriveRepository _harddriveRepo;
        private readonly IConfigurationService _configService;

        public HarddriveService(IHarddriveRepository harddriveRepo, IConfigurationService configService)
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
    }
}