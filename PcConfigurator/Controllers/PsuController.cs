using System.Diagnostics;
using System.Linq;
using System.Web.Mvc;
using Newtonsoft.Json;
using PcConfigurator.Entities;
using PcConfigurator.Models.CpuModels;
using PcConfigurator.Models.HomeModels;
using PcConfigurator.Service;

namespace PcConfigurator.Controllers
{
    public class PsuController : Controller
    {
        private readonly IPsuService _psuService;

        public PsuController(IPsuService psuService)
        {
            _psuService = psuService;
        }

        [HttpPost]
        public ActionResult LoadPsuBrand(ConfigurationFormModel model)
        {
            var powerConsumption = model.MemoryPowerConsumption + model.MotherboardPowerConsumption +
                                   model.CpuPowerConsumption + model.StoragePowerConsumption + model.GpuPowerConsumption;
            var output = _psuService.GetPsuBrandsByPowerConsumption(powerConsumption).Select(s => new {text = s, value = s});
            return Json(output);
        }

        [HttpPost]
        public ActionResult LoadPsuId(ConfigurationFormModel model)
        {
            var output = _psuService.GetPsusByConfiguration(model).Select(p => new {text = p.Name, value = p.Id});
            return Json(output);
        }

        [HttpPost]
        public ActionResult LoadPsu(string id)
        {
            return PartialView("_Psu", _psuService.GetById(id));
        }

    }
}