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
            var output = _caseService.GetCasesByConfiguration(model).Select(c => new { text = c.Name, value = c.Id });
            return Json(output);
        }

        [HttpPost]
        public ActionResult LoadCaseBrand(ConfigurationFormModel model)
        {
            var output = _caseService.GetCaseBrandsByFormat(model.MotherboardFormat).Select(b => new { text = b, value = b });
            return Json(output);
        }

        [HttpPost]
        public ActionResult LoadCase(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return PartialView("_Case", _caseService.GetById(id));
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View(_caseService.GetAll());
        }

        [HttpGet]
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var caseEntity =
            _caseService.GetById(id);
            return View(caseEntity);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new Case());
        }

        [HttpPost]
        public ActionResult Create(Case component, string motherboardCompatibility)
        {
            if (ModelState.IsValid && !string.IsNullOrEmpty(motherboardCompatibility))
            {
                component.MotherboardCompatibility =
                    motherboardCompatibility.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(s => s.Trim())
                        .ToList();
                _caseService.Insert(component);
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
            _caseService.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var caseEntity =
            _caseService.GetById(id);
            return View(caseEntity);
        }

        [HttpPost]
        public ActionResult Edit(Case component, string motherboardCompatibility)
        {
            if (ModelState.IsValid && !string.IsNullOrEmpty(motherboardCompatibility))
            {
                component.MotherboardCompatibility =
                    motherboardCompatibility.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(s => s.Trim())
                        .ToList();
                _caseService.Update(component);
                return RedirectToAction("Index");
            }
            return View(component);
        }
    }
}