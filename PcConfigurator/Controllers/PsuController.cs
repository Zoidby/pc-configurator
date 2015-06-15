using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Newtonsoft.Json;
using PcConfigurator.Entities;
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
            var output = _psuService.GetPsuBrandsByPowerConsumption(powerConsumption).Select(s => new { text = s, value = s });
            return Json(output);
        }

        [HttpPost]
        public ActionResult LoadPsuId(ConfigurationFormModel model)
        {
            var output = _psuService.GetPsusByConfiguration(model).Select(p => new { text = p.Name, value = p.Id });
            return Json(output);
        }

        [HttpPost]
        public ActionResult LoadPsu(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return PartialView("_Psu", _psuService.GetById(id));
        }


        [HttpGet]
        public ActionResult Index()
        {
            return View(_psuService.GetAll());
        }

        [HttpGet]
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return View(_psuService.GetById(id));
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new Psu());
        }

        [HttpPost]
        public ActionResult Create(Psu component)
        {
            if (ModelState.IsValid)
            {
                _psuService.Insert(component);
                return RedirectToAction("Index");
            }
            return View(component);
        }

        [HttpGet]
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            _psuService.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return View(_psuService.GetById(id));
        }

        [HttpPost]
        public ActionResult Edit(Psu component)
        {
            if (ModelState.IsValid)
            {
                _psuService.Update(component);
                return RedirectToAction("Index");
            }
            return View(component);
        }
    }
}