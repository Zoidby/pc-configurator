using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using PcConfigurator.DAL;
using PcConfigurator.Models;
using PcConfigurator.Models.CpuModels;

namespace PcConfigurator.Controllers
{
    public class CpuController : Controller
    {

        private CpuDal dal;

        public CpuController(CpuDal dal)
        {
            this.dal = dal;
        }

        public async Task<ViewResult> Index()
        {
            var model = new IndexModel {CpuList = await dal.GetAll()};
            return View(model);
        }

        [HttpGet]
        public ActionResult Add()
        {
            var model = new CpuAddModel();

            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Add(CpuAddModel model)
        {
            if (this.ModelState.IsValid)
            {
                var cpuToAdd = new Cpu {Brand = model.Brand, Socket = model.Socket, Number = model.Number};

                await dal.CreateCpu(cpuToAdd);
            }
            return View(model);
        }
    }
}