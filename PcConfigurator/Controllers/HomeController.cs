using System.Diagnostics;
using System.Linq;
using System.Web.Mvc;
using Newtonsoft.Json;
using PcConfigurator.Entities;
using PcConfigurator.Models.HomeModels;
using PcConfigurator.Service;

namespace PcConfigurator.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICpuService _cpuService;
        private readonly IGpuService _gpuService;
        private readonly IMemoryService _memoryService;
        private readonly IStorageService _storageService;

        public HomeController( ICpuService cpuService, IGpuService gpuService, IMemoryService memoryService, IStorageService storageService)
        {
            _cpuService = cpuService;
            _gpuService = gpuService;
            _memoryService = memoryService;
            _storageService = storageService;
        }

        [HttpGet]
        [OutputCache(Duration = 60)]
        public ActionResult Index()
        {
            var model = new ConfigurationFormModel
            {
                CpuBrandList = _cpuService.GetCpuBrands(),
                MemoryCapacityList = _memoryService.GetMemoryCapacities(),
                StorageCapacityList = _storageService.GetStorageCapacities(),
                GpuManufacturerList = _gpuService.GetGpuManufacturers()
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Index(ConfigurationFormModel model)
        {
            //crazy validation
            return Json("");
        }


        

        

        

        

      

        
    }
}




//            var caseDto = new Case
//            {
//                Brand = "Fractal Design",
//                Name = "DEFINE R4",
//                MotherboardCompatibility = new List<string> {"mATX"}
//            };
//            _caseService.Insert(caseDto);
//            var motherboardDto = new Motherboard
//            {
//                Brand = "Gigabyte",
//                MemoryMaximum = 16,
//                MemorySlots = 4,
//                Name = "GA-880GM-USB3",
//                Socket = "AM3",
//                PowerConsumption = 20,
//                ExpansionSlots = new List<string> {"PCI Express 16.0"},
//                Format = "mATX",
//                HarddriveInterfaces = new List<string> {"SATA II"}
//            };
//            _motherboardService.Insert(motherboardDto);
//            var cpuDto = new Cpu
//            {
//                Brand = "AMD",
//                Name = "Phenom II",
//                PowerConsumption = 70,
//                Socket = "AM3"
//            };
//            _cpuService.Insert(cpuDto);
//            var gpuDto = new Gpu
//            {
//                Brand = "MSI",
//                ChipsetManufacturer = "AMD",
//                ExpansionSlot = "PCI Express 16.0",
//                Name = "HD7850",
//                PowerConsumption = 150
//            };
//            _gpuService.Insert(gpuDto);
//            var memoryDto = new Memory
//            {
//                Brand = "Kingston",
//                Count = 2,
//                Name = "Hyperx Blu",
//                PowerConsumption = 20,
//                TotalCapacity = 4
//            };
//            _memoryService.Insert(memoryDto);
//            var hddDto = new Harddrive
//            {
//                Brand = "Western Digital",
//                Name = "Black",
//                Interface = "SATA II",
//                PowerConsumption = 8
//            };
//            _harddriveService.Insert(hddDto);
//            var psuDto = new Psu
//            {
//                Brand = "SuperFlower",
//                Name = "Not so Awesome",
//                Efficiency = 95,
//                MaximumPower = 400
//            };
//            _psuService.Insert(psuDto);

//
//            Debug.WriteLine("HI!!!!");
//
//            var configuration = new Configuration
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
//
//            _gpuService.GetValidGpus(configuration).ForEach(p => Debug.WriteLine(p));
//            _harddriveService.GetValidHarddrives(configuration).ForEach(p => Debug.WriteLine(p));
//            _motherboardService.GetValidMotherboards(configuration).ForEach(p => Debug.WriteLine(p));
//            //_psuService.GetValidPsus(configuration).ForEach(p => Debug.WriteLine(p));
//
//            _configurationService.Insert(configuration);