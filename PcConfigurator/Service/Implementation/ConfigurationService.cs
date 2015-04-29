using System.Collections.Generic;
using System.Linq;
using PcConfigurator.Entities;
using PcConfigurator.Repositories;

namespace PcConfigurator.Service.Implementation
{
    public class ConfigurationService : Service<Configuration>, IConfigurationService
    {
        private IConfigurationRepository _repo;

        public ConfigurationService(IConfigurationRepository repo)
            : base(repo)
        {
            _repo = repo;
        }

        public int GetTotalConsumption(Configuration config)
        {
            var pcs = new List<PowerConsumerComponent>
            {
                config.Cpu,
                config.Gpu,
                config.Harddrive,
                config.Memory,
                config.Motherboard
            };
            return pcs.Where(pc => pc != null).Sum(pc => pc.PowerConsumption);
        }
    }
}