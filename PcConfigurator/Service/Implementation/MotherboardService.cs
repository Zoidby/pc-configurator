using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Newtonsoft.Json;
using PcConfigurator.Entities;
using PcConfigurator.Models.HomeModels;
using PcConfigurator.Repositories;

namespace PcConfigurator.Service.Implementation
{
    public class MotherboardService : Service<Motherboard>, IMotherboardService
    {
        private readonly IMotherboardRepository _moboRepo;
        private readonly IConfigurationService _configService;
        private readonly IMemoryService _memoryService;
        private readonly IStorageService _storageService;
        private readonly ICpuService _cpuService;
        private readonly IGpuService _gpuService;

        public MotherboardService(IMotherboardRepository moboRepo, 
            IConfigurationService configService, 
            IMemoryService memoryService,
            IStorageService storageService, 
            ICpuService cpuService, 
            IGpuService gpuService) : base(moboRepo)
        {
            _moboRepo = moboRepo;
            _configService = configService;
            _memoryService = memoryService;
            _storageService = storageService;
            _cpuService = cpuService;
            _gpuService = gpuService;
        }

        public IEnumerable<Motherboard> GetValidMotherboards(Configuration configuration)
        {
            IQueryable<Motherboard> result = _moboRepo.GetAll();

            if (configuration.Cpu != null)
            {
                result = result.Where(m => m.Socket == configuration.Cpu.Socket);
            }
            if (configuration.Case != null)
            {
                result = result.Where(m => configuration.Case.MotherboardCompatibility.Contains(m.Format));
            }
            if (configuration.Memory != null)
            {
                result =
                    result.Where(
                        m =>
                            m.MemoryMaximum >= configuration.Memory.TotalCapacity &&
                            m.MemorySlots >= configuration.Memory.Count);
            }
            if (configuration.Harddrive != null)
            {
                result = result.Where(m => m.HarddriveInterfaces.Contains(configuration.Harddrive.Interface));
            }
            if (configuration.Gpu != null)
            {
                result = result.Where(m => m.ExpansionSlots.Contains(configuration.Gpu.ExpansionSlot));
            }
            if (configuration.Psu != null)
            {
                result = result.Where(m => m.PowerConsumption <= configuration.Psu.ActualPower - _configService.GetTotalConsumption(configuration));
            }

            return result.AsEnumerable();
        }

        public IEnumerable<string> GetMotherboardFormatsByConfiguration(ConfigurationFormModel model)
        {
            Memory memory = _memoryService.GetById(model.MemoryId);
            Cpu cpu = _cpuService.GetById(model.CpuId);
            Gpu gpu = _gpuService.GetById(model.GpuId);
            Harddrive hdd = _storageService.GetById(model.StorageId);

            if (memory == null || cpu == null || gpu == null || hdd == null)
            {
                return Enumerable.Empty<string>();
            }

            return _moboRepo.GetAll()
                .Where(m => m.MemoryMaximum >= memory.TotalCapacity
                    && m.MemorySlots >= memory.Count
                    && m.ExpansionSlots.Contains(gpu.ExpansionSlot)
                    && m.HarddriveInterfaces.Contains(hdd.Interface)
                    && m.Socket == cpu.Socket).Select(m => m.Format).Distinct().AsEnumerable();
        }

        public IEnumerable<string> GetMotherboardBrandsByConfiguration(ConfigurationFormModel model)
        {
            Memory memory = _memoryService.GetById(model.MemoryId);
            Cpu cpu = _cpuService.GetById(model.CpuId);
            Gpu gpu = _gpuService.GetById(model.GpuId);
            Harddrive hdd = _storageService.GetById(model.StorageId);
            if (memory == null || cpu == null || gpu == null || hdd == null)
            {
                return Enumerable.Empty<string>();
            }

            return _moboRepo.GetAll()
                .Where(m => m.MemoryMaximum >= memory.TotalCapacity
                    && m.MemorySlots >= memory.Count 
                    && m.ExpansionSlots.Contains(gpu.ExpansionSlot) 
                    && m.HarddriveInterfaces.Contains(hdd.Interface)
                    && m.Socket == cpu.Socket
                    && m.Format == model.MotherboardFormat)
                    .Select(m => m.Brand).Distinct().AsEnumerable();
        }

        public IEnumerable<Motherboard> GetMotherboardsByConfiguration(ConfigurationFormModel model)
        {
            Memory memory = _memoryService.GetById(model.MemoryId);
            Cpu cpu = _cpuService.GetById(model.CpuId);
            Gpu gpu = _gpuService.GetById(model.GpuId);
            Harddrive hdd = _storageService.GetById(model.StorageId);
            if (memory == null || cpu == null || gpu == null || hdd == null)
            {
                return Enumerable.Empty<Motherboard>();
            }

            return _moboRepo.GetAll()
                .Where(m => m.MemoryMaximum >= memory.TotalCapacity
                    && m.MemorySlots >= memory.Count
                    && m.ExpansionSlots.Contains(gpu.ExpansionSlot)
                    && m.HarddriveInterfaces.Contains(hdd.Interface)
                    && m.Socket == cpu.Socket
                    && m.Format == model.MotherboardFormat 
                && m.Brand == model.MotherboardBrand).AsEnumerable();
        }
    }
}