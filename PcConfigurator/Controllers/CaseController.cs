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
    public class CaseController : Controller
    {
        private readonly ICaseService _caseService;

        public CaseController(ICaseService caseService)
        {
            _caseService = caseService;
        }
        [HttpPost]
        public ActionResult LoadCaseId(ConfigurationFormModel model)
        {
            var output = _caseService.GetCasesByConfiguration(model).Select(c => new {text = c.Name, value = c.Id});
            return Json(output);
        }

        [HttpPost]
        public ActionResult LoadCaseBrand(ConfigurationFormModel model)
        {
            var output = _caseService.GetCaseBrandsByFormat(model.MotherboardFormat).Select(b => new {text = b, value = b});
            return Json(output);
        }

        [HttpPost]
        public ActionResult LoadCase(string id)
        {
            return PartialView("_Case",_caseService.GetById(id));
        }
    }
}