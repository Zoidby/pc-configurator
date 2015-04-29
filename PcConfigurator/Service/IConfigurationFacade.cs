using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PcConfigurator.Entities;
using PcConfigurator.Models.HomeModels;

namespace PcConfigurator.Service
{
    public interface IConfigurationFacade
    {
        IEnumerable<Case> GetValidCases(ConfigurationFormModel model);
        IEnumerable<Motherboard> GetValidMotherboards(Configuration configuration);
        IEnumerable<Cpu> GetValidCpus(Configuration configuration);
        IEnumerable<Memory> GetValidMemories(Configuration configuration);
        IEnumerable<Harddrive> GetValidHarddrives(Configuration configuration);
        IEnumerable<Gpu> GetValidGpus(Configuration configuration);
        IEnumerable<Psu> GetValidPsus(Configuration configuration);
        bool Validate(HomeIndexModel model);
    }
}
