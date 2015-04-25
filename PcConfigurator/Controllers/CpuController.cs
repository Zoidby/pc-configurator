using System.Web.Mvc;
using PcConfigurator.Entities;
using PcConfigurator.Models.CpuModels;
using PcConfigurator.Service;

namespace PcConfigurator.Controllers
{
    public class CpuController : Controller
    {
        private readonly ICpuService _service;

        public CpuController(ICpuService service)
        {
            _service = service;
        }

        public ViewResult Single(string id)
        {
            var model = new CpuSingleModel {Entity = _service.GetById(id)};
            return View(model);
        }

        public ActionResult Remove(string id)
        {
            _service.Delete(id);
            return RedirectToAction("Index");
        }

        public ViewResult Index()
        {
            var model = new CpuIndexModel {CpuList = _service.GetAll()};
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
                _service.Insert(cpuToAdd);
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}