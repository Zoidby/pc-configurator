using PcConfigurator.Entities;
using PcConfigurator.Models.HomeModels;

namespace PcConfigurator.Service
{
    public interface IConfigurationService : IService<Configuration>
    {
        int GetTotalConsumption(Configuration dto);
        int GetTotalConsumption(ConfigurationFormModel dto);
    }
}