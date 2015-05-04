using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Newtonsoft.Json;
using PcConfigurator.Entities;
using PcConfigurator.Models.HomeModels;
using PcConfigurator.Repositories;

namespace PcConfigurator.Service.Implementation
{
    public class CaseService : Service<Case>, ICaseService
    {
        private ICaseRepository _repo;

        public CaseService(ICaseRepository repo)
            : base(repo)
        {
            _repo = repo;
        }

        public IEnumerable<Case> GetValidCases(ConfigurationFormModel model)
        {
            IQueryable<Case> result = _repo.GetAll();

//            if (!string.IsNullOrEmpty(model.MotherboardFormat))
//            {
//                result = result.Where(c => c.MotherboardCompatibility.Contains(model.MotherboardFormat));
//            }
            if (!string.IsNullOrEmpty(model.MotherboardFormat))
            {
                result = result.Where(c => c.MotherboardCompatibility.Contains(model.MotherboardFormat));
            }
            if (!string.IsNullOrEmpty(model.CaseBrand))
            {
                result = result.Where(c => c.Brand == model.CaseBrand);
            }

            return result.AsEnumerable();
        }

        public IEnumerable<string> GetCaseBrandByConfiguration(ConfigurationFormModel model)
        {
            return
                _repo.GetAll()
                    .Where(c => c.MotherboardCompatibility.Contains(model.MotherboardFormat))
                    .Select(c => c.Brand)
                    .Distinct()
                    .AsEnumerable();
        }

        public IEnumerable<Case> GetCasesByConfiguration(ConfigurationFormModel model)
        {
            return
                _repo.GetAll()
                    .Where(
                        c => model.CaseBrand == c.Brand && c.MotherboardCompatibility.Contains(model.MotherboardFormat))
                    .AsEnumerable();
        }

        public IEnumerable<string> GetCaseFormats()
        {
            return _repo.GetAll().Select(c => c.MotherboardCompatibility).AsEnumerable().SelectMany(c => c).Distinct();
        }

        public IEnumerable<string> GetCaseBrandsByFormat(string format)
        {
            var result = _repo.GetAll()
                    .Where(c => c.MotherboardCompatibility.Contains(format))
                    .Select(c => c.Brand)
                    .AsEnumerable()
                    .Distinct();
            return result;
        } 
    }
}