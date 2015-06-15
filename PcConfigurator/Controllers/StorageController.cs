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
    public class StorageController : Controller
    {
        private readonly IStorageService _storageService;

        public StorageController(IStorageService storageService)
        {
            _storageService = storageService;
        }

        [HttpPost]
        public ActionResult LoadStorageBrand(ConfigurationFormModel model)
        {
            var output =
                _storageService.GetStorageBrandsByCapacity(model.StorageCapacity).Select(s => new { text = s, value = s });
            return Json(output);

        }

        [HttpPost]
        public ActionResult LoadStorageId(ConfigurationFormModel model)
        {
            var output =
                _storageService.GetStoragesByCapacityAndBrand(model.StorageCapacity, model.StorageBrand).Select(s => new { text = s.Name, value = s.Id });
            return Json(output);
        }

        [HttpPost]
        public ActionResult LoadStorage(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return PartialView("_Storage", _storageService.GetById(id));
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View(_storageService.GetAll());
        }

        [HttpGet]
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return View(_storageService.GetById(id));
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new Harddrive());
        }

        [HttpPost]
        public ActionResult Create(Harddrive component)
        {
            if (ModelState.IsValid)
            {
                _storageService.Insert(component);
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
            _storageService.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return View(_storageService.GetById(id));
        }

        [HttpPost]
        public ActionResult Edit(Harddrive component)
        {
            if (ModelState.IsValid)
            {
                _storageService.Update(component);
                return RedirectToAction("Index");
            }
            return View(component);
        }
    }
}