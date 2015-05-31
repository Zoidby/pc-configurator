using System.Diagnostics;
using System.Linq;
using System.Web.Mvc;
using Newtonsoft.Json;
using PcConfigurator.Entities;
using PcConfigurator.Models.HomeModels;
using PcConfigurator.Service;

namespace PcConfigurator.Controllers
{
    public class CpuController : Controller
    {
        private readonly ICpuService _cpuService;

        public CpuController(ICpuService cpuService)
        {
            _cpuService = cpuService;
        }

        [HttpPost]
        public ActionResult LoadCpuSocket(ConfigurationFormModel model)
        {
            var output = _cpuService.GetCpuSocketsByBrand(model.CpuBrand).Select(c => new { text = c, value = c });
            return Json(output);
        }

        [HttpPost]
        public ActionResult LoadCpuId(ConfigurationFormModel model)
        {
            var output = _cpuService.GetCpusBySocket(model.CpuSocket).Select(c => new { text = c.Name, value = c.Id });
            return Json(output);
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View(_cpuService.GetAll());
        }

        [HttpGet]
        public ActionResult Details(string id)
        {
            return View(_cpuService.GetById(id));
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new Cpu());
        }

        [HttpPost]
        public ActionResult Create(Cpu component)
        {
            _cpuService.Insert(component);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(string id)
        {
            _cpuService.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(string id)
        {
            return View(_cpuService.GetById(id));
        }

        [HttpPost]
        public ActionResult Edit(Cpu component)
        {
            _cpuService.Update(component);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult LoadCpu(string id)
        {
            return PartialView("_Cpu", _cpuService.GetById(id));
        }
    }
}