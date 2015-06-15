using System;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Microsoft.Practices.ObjectBuilder2;
using Newtonsoft.Json;
using PcConfigurator.Entities;
using PcConfigurator.Models.HomeModels;
using PcConfigurator.Service;
using PcConfigurator.Service.Implementation;

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
            var output = _moboService.GetMotherboardFormatsByConfiguration(model).Select(s => new { text = s, value = s });
            return Json(output);
        }

        [HttpPost]
        public ActionResult LoadMotherboardBrand(ConfigurationFormModel model)
        {
            var output =
                _moboService.GetMotherboardBrandsByConfiguration(model)
                    .Select(s => new { text = s, value = s });
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
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var output =
                _moboService.GetById(id);
            return PartialView("_Motherboard", output);

        }



        [HttpGet]
        public ActionResult Index()
        {
            return View(_moboService.GetAll());
        }

        [HttpGet]
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return View(_moboService.GetById(id));
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new Motherboard());
        }

        [HttpPost]
        public ActionResult Create(Motherboard component, string harddriveInterfaces, string expansionSlots)
        {
            if (ModelState.IsValid && !string.IsNullOrEmpty(harddriveInterfaces) && !string.IsNullOrEmpty(expansionSlots))
            {

                component.HarddriveInterfaces = harddriveInterfaces.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries).Select(s => s.Trim()).ToList();
                component.ExpansionSlots = expansionSlots.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries).Select(s => s.Trim()).ToList();
                _moboService.Insert(component);
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
            _moboService.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var mobo = _moboService.GetById(id);
            return View(mobo);
        }

        [HttpPost]
        public ActionResult Edit(Motherboard component, string harddriveInterfaces, string expansionSlots)
        {
            if (ModelState.IsValid && !string.IsNullOrEmpty(harddriveInterfaces) &&
                !string.IsNullOrEmpty(expansionSlots))
            {
                component.HarddriveInterfaces =
                    harddriveInterfaces.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(s => s.Trim())
                        .ToList();
                component.ExpansionSlots =
                    expansionSlots.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries).Select(s => s.Trim()).ToList();
                _moboService.Update(component);
                return RedirectToAction("Index");
            }
            return View(component);
        }
    }
}