using System;
using System.Diagnostics;
using System.Linq;
using System.Web.Mvc;
using Microsoft.Practices.ObjectBuilder2;
using Newtonsoft.Json;
using PcConfigurator.Entities;
using PcConfigurator.Models.CaseModels;
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

        [HttpGet]
        public ActionResult Index()
        {
            return View(_caseService.GetAll().Select(c => EntityToModel(c)));
        }

        [HttpGet]
        public ActionResult Details(string id)
        {
            var caseEntity =
            _caseService.GetById(id);
            return View(EntityToModel(caseEntity));
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new CaseModel());
        }

        [HttpPost]
        public ActionResult Create(CaseModel component)
        {
            _caseService.Insert(ModelToEntity(component));
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(string id)
        {
            _caseService.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(string id)
        {
            var caseEntity =
            _caseService.GetById(id);
            return View(EntityToModel(caseEntity));
        }

        [HttpPost]
        public ActionResult Edit(CaseModel component)
        {
            _caseService.Update(ModelToEntity(component));
            return RedirectToAction("Index");
        }


        private Case ModelToEntity(CaseModel model)
        {
            return new Case
            {
                Id = model.Id,
                Brand = model.Brand,
                Name = model.Name,
                MotherboardCompatibility =
                    model.MotherboardCompatibility.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries).Select(s => s.Trim())
                        .ToList()
            };
        }

        private CaseModel EntityToModel(Case entity)
        {
            return new CaseModel
            {
                Id = entity.Id,
                Brand = entity.Brand,
                Name = entity.Name,
                MotherboardCompatibility = entity.MotherboardCompatibility.JoinStrings(",")
            };
        }
    }
}