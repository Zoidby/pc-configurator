using System.Diagnostics;
using System.Linq;
using System.Web.Mvc;
using Newtonsoft.Json;
using PcConfigurator.Entities;
using PcConfigurator.Models.HomeModels;
using PcConfigurator.Service;

namespace PcConfigurator.Controllers
{
    public class MemoryController : Controller
    {
        private readonly IMemoryService _memoryService;

        public MemoryController(IMemoryService memoryService)
        {
            _memoryService = memoryService;
        }


        [HttpPost]
        public ActionResult LoadMemoryBrand(ConfigurationFormModel model)
        {
            var output = _memoryService.GetMemoryBrandsByCapacity(model.MemoryCapacity).Select(c => new { text = c, value = c });
            return Json(output);

        }

        [HttpPost]
        public ActionResult LoadMemoryId(ConfigurationFormModel model)
        {
            var output = _memoryService.GetMemoriesByCapacityAndBrand(model.MemoryCapacity, model.MemoryBrand).Select(m => new {text = m.Name, value= m.Id});
            return Json(output);
        }

        [HttpPost]
        public ActionResult LoadMemory(string id)
        {
            Debug.WriteLine(id);
            return PartialView("_Memory", _memoryService.GetById(id));
        }

        //index,details,edit,delete,create

        [HttpGet]
        public ActionResult Index()
        {
            return View(_memoryService.GetAll());
        }

        [HttpGet]
        public ActionResult Details(string id)
        {
            return View(_memoryService.GetById(id));
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new Memory());
        }

        [HttpPost]
        public ActionResult Create(Memory memory)
        {
            _memoryService.Insert(memory);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(string id)
        {
            _memoryService.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(string id)
        {
            return View(_memoryService.GetById(id));
        }

        [HttpPost]
        public ActionResult Edit(Memory memory)
        {
            _memoryService.Update(memory);
            return RedirectToAction("Index");
        }

    }
}