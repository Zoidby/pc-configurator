using System.Diagnostics;
using System.Linq;
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
                _storageService.GetStorageBrandsByCapacity(model.StorageCapacity).Select(s => new {text = s, value = s});
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
            Debug.WriteLine(id);
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
            _storageService.Insert(component);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(string id)
        {
            _storageService.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(string id)
        {
            return View(_storageService.GetById(id));
        }

        [HttpPost]
        public ActionResult Edit(Harddrive component)
        {
            _storageService.Update(component);
            return RedirectToAction("Index");
        }
    }
}