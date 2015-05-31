using System;
using System.Diagnostics;
using System.Linq;
using System.Web.Mvc;
using Microsoft.Practices.ObjectBuilder2;
using Newtonsoft.Json;
using PcConfigurator.Entities;
using PcConfigurator.Models.HomeModels;
using PcConfigurator.Models.MotherboardModels;
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



        [HttpGet]
        public ActionResult Index()
        {
            return View(_moboService.GetAll().Select(m => EntityToModel(m)));
        }

        [HttpGet]
        public ActionResult Details(string id)
        {
            return View(EntityToModel(_moboService.GetById(id)));
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new MotherboardModel());
        }

        [HttpPost]
        public ActionResult Create(MotherboardModel component)
        {
            _moboService.Insert(ModelToEntity(component));
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(string id)
        {
            _moboService.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(string id)
        {
            return View(EntityToModel(_moboService.GetById(id)));
        }

        [HttpPost]
        public ActionResult Edit(MotherboardModel component)
        {
            _moboService.Update(ModelToEntity(component));
            return RedirectToAction("Index");
        }

        private MotherboardModel EntityToModel(Motherboard mobo)
        {
            return new MotherboardModel
            {
                Id = mobo.Id,
                Brand = mobo.Brand,
                Name = mobo.Name,
                MemoryMaximum = mobo.MemoryMaximum,
                MemorySlots = mobo.MemorySlots,
                Format = mobo.Format,
                Socket = mobo.Socket,
                ExpansionSlots = mobo.ExpansionSlots.JoinStrings(","),
                HarddriveInterfaces = mobo.HarddriveInterfaces.JoinStrings(",")
            };
        }

        private Motherboard ModelToEntity(MotherboardModel model)
        {
            return new Motherboard
            {
                Brand = model.Brand,
                Name = model.Name,
                MemoryMaximum = model.MemoryMaximum,
                MemorySlots = model.MemorySlots,
                Format = model.Format,
                Socket = model.Socket,
                ExpansionSlots = model.ExpansionSlots.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries).Select(s => s.Trim())
                        .ToList(),
                HarddriveInterfaces = model.HarddriveInterfaces.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries).Select(s => s.Trim())
                .ToList(),
            };
        }
    }
}