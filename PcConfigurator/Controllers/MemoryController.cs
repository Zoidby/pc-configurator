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
            var output = _memoryService.GetMemoriesByCapacityAndBrand(model.MemoryCapacity, model.MemoryBrand).Select(m => new { text = m.Name, value = m.Id });
            return Json(output);
        }

        [HttpPost]
        public ActionResult LoadMemory(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
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
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
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
            if (ModelState.IsValid)
            {
                _memoryService.Insert(memory);
                return RedirectToAction("Index");
            }
            return View(memory);
        }

        [HttpGet]
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            _memoryService.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return View(_memoryService.GetById(id));
        }

        [HttpPost]
        public ActionResult Edit(Memory memory)
        {
            if (ModelState.IsValid)
            {
                _memoryService.Update(memory);
                return RedirectToAction("Index");
            }
            return View(memory);
        }

    }
}