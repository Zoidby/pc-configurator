using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using PcConfigurator.Entities;
using PcConfigurator.Repositories;

namespace PcConfigurator.Service.Implementation
{
    public class CpuService : Service<Cpu>, ICpuService
    {
        private readonly ICpuRepository _cpuRepo;
        private readonly IConfigurationService _configService;

        public CpuService(ICpuRepository cpuRepo, IConfigurationService configService)
            : base(cpuRepo)
        {
            _cpuRepo = cpuRepo;
            _configService = configService;
        }

        public IEnumerable<Cpu> GetValidCpus(Configuration configuration)
        {
            IQueryable<Cpu> result = _cpuRepo.GetAll();

            if (configuration.Motherboard != null)
            {
                result = result.Where(c => c.Socket == configuration.Motherboard.Socket);
            }
            if (configuration.Psu != null)
            {
                int availablePower = configuration.Psu.ActualPower - _configService.GetTotalConsumption(configuration);
                availablePower = configuration.Cpu == null ? availablePower : availablePower + configuration.Cpu.PowerConsumption;
                result = result.Where(g => g.PowerConsumption <= availablePower);
            }

            return result.AsEnumerable();
        }

        public IEnumerable<string> GetCpuBrands()
        {
            return _cpuRepo.GetAll().Select(c => c.Brand).Distinct().AsEnumerable();
        }

        public IEnumerable<string> GetCpuSocketsByBrand(string cpuBrand)
        {
            return _cpuRepo.GetAll().Where(c => c.Brand == cpuBrand).Select(c => c.Socket).Distinct().AsEnumerable();
        }

        public IEnumerable<Cpu> GetCpusBySocket(string cpuSocket)
        {
            return _cpuRepo.GetAll().Where(c => c.Socket == cpuSocket).AsEnumerable();
        }
    }
}