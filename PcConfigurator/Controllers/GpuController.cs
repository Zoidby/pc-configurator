using System.Diagnostics;
using System.Linq;
using System.Web.Mvc;
using Newtonsoft.Json;
using PcConfigurator.Entities;
using PcConfigurator.Models.GpuModels;
using PcConfigurator.Models.HomeModels;
using PcConfigurator.Service;

namespace PcConfigurator.Controllers
{
    public class GpuController : Controller
    {
        private readonly IGpuService _gpuService;

        public GpuController(IGpuService gpuService)
        {
            _gpuService = gpuService;
        }

        [HttpPost]
        public ActionResult LoadGpuBrand(ConfigurationFormModel model)
        {
            var output =
                _gpuService.GetGpuBrandsByManufacturer(model.GpuManufacturer).Select(s => new {text = s, value = s});
            return Json(output);
        }

        [HttpPost]
        public ActionResult LoadGpuId(ConfigurationFormModel model)
        {
            var output =
                _gpuService.GetGpusByBrandAndManufacturer(model.GpuBrand, model.GpuManufacturer)
                    .Select(g => new {text = g.Name, value = g.Id});
            return Json(output);
        }

        [HttpPost]
        public ActionResult LoadGpu(string id)
        {
            Debug.WriteLine(id);
            return PartialView("_Gpu", _gpuService.GetById(id));
        }

        public ActionResult Index()
        {
            var model = new GpuIndexModel {GpuList = _gpuService.GetAll().ToList()};
            return View(model);
        }

        [HttpPost]
        public ActionResult Add(GpuAddModel model)
        {
            if (ModelState.IsValid)
            {
                var gpuToAdd = new Gpu {Brand = model.Brand, Name = model.Name};
                _gpuService.Insert(gpuToAdd);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult Add()
        {
            var model = new GpuAddModel();
            return View(model);
        }
    }
}