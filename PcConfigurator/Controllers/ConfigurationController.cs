using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PcConfigurator.Entities;
using PcConfigurator.Models.HomeModels;
using PcConfigurator.Service;

namespace PcConfigurator.Controllers
{
    public class ConfigurationController : Controller
    {
        private readonly IConfigurationService _configService;
        private readonly ICpuService _cpuService;
        private readonly IGpuService _gpuService;
        private readonly IPsuService _psuService;
        private readonly IMemoryService _memoryService;
        private readonly IStorageService _storageService;
        private readonly ICaseService _caseService;
        private readonly IMotherboardService _moboService;

        public ConfigurationController(IConfigurationService configService, ICpuService cpuService, IGpuService gpuService, IPsuService psuService, IMemoryService memoryService, IStorageService storageService, ICaseService caseService, IMotherboardService moboService)
        {
            _configService = configService;
            _cpuService = cpuService;
            _gpuService = gpuService;
            _psuService = psuService;
            _memoryService = memoryService;
            _storageService = storageService;
            _caseService = caseService;
            _moboService = moboService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View(_configService.GetAll());
        }

        [HttpGet]
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            _configService.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Create(ConfigurationFormModel model)
        {
            var config = new Configuration
            {
                Cpu = _cpuService.GetById(model.CpuId),
                Gpu = _gpuService.GetById(model.GpuId),
                Psu = _psuService.GetById(model.PsuId),
                Motherboard = _moboService.GetById(model.MotherboardId),
                Memory = _memoryService.GetById(model.MemoryId),
                Harddrive = _storageService.GetById(model.StorageId),
                Case = _caseService.GetById(model.CaseId)
            };
            _configService.Insert(config);
            return Json(new { result = "success" });
        }
    }
}