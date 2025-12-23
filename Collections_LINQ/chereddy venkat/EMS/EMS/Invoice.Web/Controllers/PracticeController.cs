using Microsoft.AspNetCore.Mvc;

namespace Invoice.Web.Controllers
{
    public class PracticeController : Controller
    {
        public IActionResult Index()
        {
            return View("venky");
        }
    }
}
