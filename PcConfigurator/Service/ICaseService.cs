using System.Collections.Generic;
using PcConfigurator.Entities;
using PcConfigurator.Models.HomeModels;

namespace PcConfigurator.Service
{
    public interface ICaseService : IService<Case>
    {
        IEnumerable<Case> GetValidCases(ConfigurationFormModel model);
        IEnumerable<string> GetCaseBrandByConfiguration(ConfigurationFormModel model);
        IEnumerable<Case> GetCasesByConfiguration(ConfigurationFormModel model);
        IEnumerable<string> GetCaseBrandsByFormat(string motherboardFormat);
    }
}