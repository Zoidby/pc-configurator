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
    }
}