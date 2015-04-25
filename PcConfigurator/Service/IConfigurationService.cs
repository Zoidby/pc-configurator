using PcConfigurator.Entities;

namespace PcConfigurator.Service
{
    public interface IConfigurationService : IService<Configuration>
    {
        int GetTotalConsumption(Configuration dto);
    }
}