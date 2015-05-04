using System.Collections.Generic;
using PcConfigurator.Entities;
using PcConfigurator.Models.HomeModels;

namespace PcConfigurator.Service
{
    public interface IPsuService : IService<Psu>
    {
        IEnumerable<Psu> GetValidPsus(Configuration configuration);
        IEnumerable<string> GetPsuBrandsByConfiguration(ConfigurationFormModel model);
        IEnumerable<Psu> GetPsusByConfiguration(ConfigurationFormModel model);

        IEnumerable<string> GetPsuBrandsByPowerConsumption(int powerConsumption);
    }
}