using System.Collections.Generic;
using PcConfigurator.Entities;
using PcConfigurator.Models.HomeModels;

namespace PcConfigurator.Service
{
    public interface IMotherboardService : IService<Motherboard>
    {
        IEnumerable<Motherboard> GetValidMotherboards(Configuration configuration);
        IEnumerable<string> GetMotherboardFormatsByConfiguration(ConfigurationFormModel model);
        IEnumerable<string> GetMotherboardBrandsByConfiguration(ConfigurationFormModel model);
        IEnumerable<Motherboard> GetMotherboardsByConfiguration(ConfigurationFormModel model);
    }
}