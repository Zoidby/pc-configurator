using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using MongoDB.Bson;
using PcConfigurator.Entities;
using PcConfigurator.Models.HomeModels;

namespace PcConfigurator.Service.Implementation
{
    public class ConfigurationFacade : IConfigurationFacade
    {
        private readonly ICaseService _caseService;
        private readonly ICpuService _cpuService;
        private readonly IGpuService _gpuService;
        private readonly IHarddriveService _harddriveService;
        private readonly IMemoryService _memoryService;
        private readonly IMotherboardService _motherboardService;
        private readonly IPsuService _psuService;
        private readonly IConfigurationService _configurationService;

        public ConfigurationFacade(ICaseService caseService,
            ICpuService cpuService,
            IGpuService gpuService,
            IHarddriveService harddriveService,
            IMemoryService memoryService,
            IMotherboardService motherboardService,
            IPsuService psuService,
            IConfigurationService configurationService)
        {
            _caseService = caseService;
            _cpuService = cpuService;
            _gpuService = gpuService;
            _harddriveService = harddriveService;
            _memoryService = memoryService;
            _motherboardService = motherboardService;
            _psuService = psuService;
            _configurationService = configurationService;
        }


        public IEnumerable<Case> GetValidCases(ConfigurationFormModel model)
        {
            return _caseService.GetValidCases(model);
        }

        public IEnumerable<Motherboard> GetValidMotherboards(Configuration configuration)
        {
            return _motherboardService.GetValidMotherboards(configuration);
        }

        public IEnumerable<Cpu> GetValidCpus(Configuration configuration)
        {
            return _cpuService.GetValidCpus(configuration);
        }

        public IEnumerable<Memory> GetValidMemories(Configuration configuration)
        {

            return _memoryService.GetValidMemories(configuration);
        }

        public IEnumerable<Harddrive> GetValidHarddrives(Configuration configuration)
        {
            return _harddriveService.GetValidHarddrives(configuration);
        }

        public IEnumerable<Gpu> GetValidGpus(Configuration configuration)
        {
            return _gpuService.GetValidGpus(configuration);
        }

        public IEnumerable<Psu> GetValidPsus(Configuration configuration)
        {
            return _psuService.GetValidPsus(configuration);
        }

        public bool Validate(HomeIndexModel model)
        {
            return true;
//            var configuration = new Configuration
//            {
//                Psu = _psuService.GetById(model.Psu),
//                Cpu = _cpuService.GetById(model.Cpu),
//                Gpu = _gpuService.GetById(model.Gpu),
//                Motherboard = _motherboardService.GetById(model.Motherboard),
//                Harddrive = _harddriveService.GetById(model.Harddrive),
//                Memory = _memoryService.GetById(model.Memory),
//                Case = _caseService.GetById(model.Case)
//            };
//
//            Debug.WriteLine(configuration.Psu);
//            Debug.WriteLine(configuration.Cpu);
//            Debug.WriteLine(configuration.Gpu);
//            Debug.WriteLine(configuration.Motherboard);
//            Debug.WriteLine(configuration.Harddrive);
//            Debug.WriteLine(configuration.Memory);
//            Debug.WriteLine(configuration.Case);
//
//            var cases = GetValidCases(model).Select(c => c.Id);
//            var cpus = GetValidCpus(configuration).Select(c => c.Id);
//            var gpus = GetValidGpus(configuration).Select(c => c.Id);
//            var hdds = GetValidHarddrives(configuration).Select(c => c.Id);
//            var mobos = GetValidMotherboards(configuration).Select(c => c.Id);
//            var rams = GetValidMemories(configuration).Select(c => c.Id);
//            var psus = GetValidPsus(configuration).Select(c => c.Id);
//
//            Debug.WriteLine(cases.ToJson());
//            Debug.WriteLine(cpus.ToJson());
//            Debug.WriteLine(gpus.ToJson());
//            Debug.WriteLine(hdds.ToJson());
//            Debug.WriteLine(mobos.ToJson());
//            Debug.WriteLine(rams.ToJson());
//            Debug.WriteLine(psus.ToJson());
//
//            return GetValidCases(model).Select(c => c.Id).Contains(model.Case) &&
//                GetValidCpus(configuration).Select(c => c.Id).Contains(model.Cpu) &&
//                (string.IsNullOrEmpty(model.Gpu) || GetValidGpus(configuration).Select(c => c.Id).Contains(model.Gpu)) &&
//                GetValidHarddrives(configuration).Select(c => c.Id).Contains(model.Harddrive) &&
//                GetValidMemories(configuration).Select(c => c.Id).Contains(model.Memory) &&
//                GetValidMotherboards(configuration).Select(c => c.Id).Contains(model.Motherboard) &&
//                GetValidPsus(configuration).Select(c => c.Id).Contains(model.Psu);
        }
    }
}