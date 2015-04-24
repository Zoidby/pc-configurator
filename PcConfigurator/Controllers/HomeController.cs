using System.Web.Mvc;

namespace PcConfigurator.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}