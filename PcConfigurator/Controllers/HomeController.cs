using System.Collections.Generic;
using System.Web.Mvc;
using PcConfigurator.Entities;
using PcConfigurator.Service;

namespace PcConfigurator.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICaseService _caseService;
        private readonly ICpuService _cpuService;
        private readonly IGpuService _gpuService;
        private readonly IHarddriveService _harddriveService;
        private readonly IMemoryService _memoryService;
        private readonly IMotherboardService _motherboardService;
        private readonly IPsuService _psuService;
        private IConfigurationService _configurationService;

        public HomeController(IConfigurationService configurationService, IPsuService psuService,
            ICaseService caseService, ICpuService cpuService, IGpuService gpuService, IMemoryService memoryService,
            IMotherboardService motherboardService, IHarddriveService harddriveService)
        {
            _configurationService = configurationService;
            _psuService = psuService;
            _caseService = caseService;
            _cpuService = cpuService;
            _gpuService = gpuService;
            _memoryService = memoryService;
            _motherboardService = motherboardService;
            _harddriveService = harddriveService;
        }

        public ActionResult Index()
        {
//            var caseDto = new Case
//            {
//                Brand = "Corsair",
//                Name = "300R",
//                MotherboardCompatibility = new List<string> {"ATX", "mATX"}
//            };
//            _caseService.Insert(caseDto);
//            var motherboardDto = new Motherboard
//            {
//                Brand = "Asus",
//                MemoryMaximum = 16,
//                MemorySlots = 4,
//                Name = "p8z77-v lx",
//                Socket = "LGA1155",
//                PowerConsumption = 20
//            };
//            _motherboardService.Insert(motherboardDto);
//            var cpuDto = new Cpu
//            {
//                Brand = "Intel",
//                Name = "i5-3570k",
//                PowerConsumption = 70,
//                Socket = "LGA1155"
//            };
//            _cpuService.Insert(cpuDto);
//            var gpuDto = new Gpu
//            {
//                Brand = "EVGA",
//                ChipsetManufacturer = "NVIDIA",
//                Interface = "",
//                Name = "GTX 770 SC",
//                PowerConsumption = 200
//            };
//            _gpuService.Insert(gpuDto);
//            var memoryDto = new Memory
//            {
//                Brand = "Kingston",
//                Count = 2,
//                Name = "Hyperx Blu",
//                PowerConsumption = 20,
//                TotalCapacity = 8
//            };
//            _memoryService.Insert(memoryDto);
//            var hddDto = new Harddrive
//            {
//                Brand = "Seagate",
//                Name = "Barracuda",
//                Interface = "",
//                PowerConsumption = 8
//            };
//            _harddriveService.Insert(hddDto);
//            var psuDto = new Psu
//            {
//                Brand = "SuperFlower",
//                Name = "Awesome",
//                Efficiency = 97,
//                MaximumPower = 1050
//            };
//            _psuService.Insert(psuDto);


//            var configurationDto = new ConfigurationDto
//            {
//                Case = _caseService.GetAll().First(),
//                Cpu = _cpuService.GetAll().First(),
//                Gpu = _gpuService.GetAll().First(),
//                Harddrive = _harddriveService.GetAll().First(),
//                Memory = _memoryService.GetAll().First(),
//                Motherboard = _motherboardService.GetAll().First(),
//                Psu = _psuService.GetAll().First()
//            };
//
//            _configurationService.Insert(configurationDto);
            return View();
        }
    }
}