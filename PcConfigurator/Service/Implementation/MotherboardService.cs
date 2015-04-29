using System.Collections.Generic;
using System.Linq;
using PcConfigurator.Entities;
using PcConfigurator.Repositories;

namespace PcConfigurator.Service.Implementation
{
    public class MotherboardService : Service<Motherboard>, IMotherboardService
    {
        private readonly IMotherboardRepository _moboRepo;
        private readonly IConfigurationService _configService;

        public MotherboardService(IMotherboardRepository moboRepo, IConfigurationService configService) : base(moboRepo)
        {
            _moboRepo = moboRepo;
            _configService = configService;
        }

        public IEnumerable<Motherboard> GetValidMotherboards(Configuration configuration)
        {
            IQueryable<Motherboard> result = _moboRepo.GetAll();

            if (configuration.Cpu != null)
            {
                result = result.Where(m => m.Socket == configuration.Cpu.Socket);
            }
            if (configuration.Case != null)
            {
                result = result.Where(m => configuration.Case.MotherboardCompatibility.Contains(m.Format));
            }
            if (configuration.Memory != null)
            {
                result =
                    result.Where(
                        m =>
                            m.MemoryMaximum >= configuration.Memory.TotalCapacity &&
                            m.MemorySlots >= configuration.Memory.Count);
            }
            if (configuration.Harddrive != null)
            {
                result = result.Where(m => m.HarddriveInterfaces.Contains(configuration.Harddrive.Interface));
            }
            if (configuration.Gpu != null)
            {
                result = result.Where(m => m.ExpansionSlots.Contains(configuration.Gpu.ExpansionSlot));
            }
            if (configuration.Psu != null)
            {
                result = result.Where(m => m.PowerConsumption <= configuration.Psu.ActualPower - _configService.GetTotalConsumption(configuration));
            }

            return result.AsEnumerable();
        }
    }
}