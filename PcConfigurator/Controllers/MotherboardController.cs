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
    public class MotherboardController : Controller
    {
        private readonly IMotherboardService _moboService;

        public MotherboardController(IMotherboardService moboService)
        {
            _moboService = moboService;
        }

        [HttpPost]
        public ActionResult LoadMotherboardFormat(ConfigurationFormModel model)
        {
            var output = _moboService.GetMotherboardFormatsByConfiguration(model).Select(s => new {text = s, value = s});
            return Json(output);
        }

        [HttpPost]
        public ActionResult LoadMotherboardBrand(ConfigurationFormModel model)
        {
            var output =
                _moboService.GetMotherboardBrandsByConfiguration(model)
                    .Select(s => new {text = s, value = s});
            return Json(output);
        }

        [HttpPost]
        public ActionResult LoadMotherboardId(ConfigurationFormModel model)
        {
            var output =
                _moboService.GetMotherboardsByConfiguration(model)
                    .Select(s => new { text = s.Name, value = s.Id });
            return Json(output);

        }

        [HttpPost]
        public ActionResult LoadMotherboard(string id)
        {
            var output =
                _moboService.GetById(id);
            return PartialView("_Motherboard", output);

        }
    }
}