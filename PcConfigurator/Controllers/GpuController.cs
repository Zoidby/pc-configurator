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
                _gpuService.GetGpuBrandsByManufacturer(model.GpuManufacturer).Select(s => new { text = s, value = s });
            return Json(output);
        }

        [HttpPost]
        public ActionResult LoadGpuId(ConfigurationFormModel model)
        {
            var output =
                _gpuService.GetGpusByBrandAndManufacturer(model.GpuBrand, model.GpuManufacturer)
                    .Select(g => new { text = g.Name, value = g.Id });
            return Json(output);
        }

        [HttpPost]
        public ActionResult LoadGpu(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Debug.WriteLine(id);
            return PartialView("_Gpu", _gpuService.GetById(id));
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View(_gpuService.GetAll());
        }

        [HttpGet]
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return View(_gpuService.GetById(id));
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new Gpu());
        }

        [HttpPost]
        public ActionResult Create(Gpu component)
        {
            if (ModelState.IsValid)
            {
                _gpuService.Insert(component);
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
            _gpuService.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return View(_gpuService.GetById(id));
        }

        [HttpPost]
        public ActionResult Edit(Gpu component)
        {
            if (ModelState.IsValid)
            {
                _gpuService.Update(component);
                return RedirectToAction("Index");
            }
            return View(component);
        }
    }
}