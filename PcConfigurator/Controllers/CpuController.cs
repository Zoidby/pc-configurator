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
            //Debug.WriteLine(JsonConvert.SerializeObject(output));
            return Json(output);
        }

        [HttpPost]
        public ActionResult LoadCpuId(ConfigurationFormModel model)
        {
            var output = _cpuService.GetCpusBySocket(model.CpuSocket).Select(c => new { text = c.Name, value = c.Id });
            //Debug.WriteLine(JsonConvert.SerializeObject(output));
            return Json(output);
        }

        public ViewResult Single(string id)
        {
            var model = new CpuSingleModel {Entity = _cpuService.GetById(id)};
            return View(model);
        }

        public ActionResult Remove(string id)
        {
            _cpuService.Delete(id);
            return RedirectToAction("Index");
        }

        public ViewResult Index()
        {
            var model = new CpuIndexModel {CpuList = _cpuService.GetAll().ToList()};
            return View(model);
        }

        [HttpGet]
        public ActionResult Add()
        {
            var model = new CpuAddModel();

            return View(model);
        }

        [HttpPost]
        public ActionResult Add(CpuAddModel model)
        {
            if (ModelState.IsValid)
            {
                var cpuToAdd = new Cpu
                {
                    Brand = model.Brand,
                    Socket = model.Socket,
                    Name = model.Name
                };
                _cpuService.Insert(cpuToAdd);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult LoadCpu(string id)
        {
            Debug.WriteLine(id);
            return PartialView("_Cpu", _cpuService.GetById(id));
        }
    }
}