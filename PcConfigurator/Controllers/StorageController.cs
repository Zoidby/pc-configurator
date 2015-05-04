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
    }
}