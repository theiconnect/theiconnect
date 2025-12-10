using EMS.Services;
using EMS.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EMS.Web.Controllers
{
    /*public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly CompanyService objCompSvc;
        private readonly CompanyService b;
        public HomeController(ILogger<HomeController> logger, CompanyService companyService, CompanyService abc )
        {
            _logger = logger;
            objCompSvc = companyService;
            b = abc;
        }

        public IActionResult Index([FromServices] CompanyService serviceFromAction)
        {
            int hashcodeCtor = objCompSvc.GetHashCode();
            int hashcodeCtor1 = b.GetHashCode();
            int hashcodeAction = serviceFromAction.GetHashCode();

            objCompSvc.test();
            

            //return RedirectToAction("Privacy");
            return View();
        }

        public IActionResult Privacy()
        {
            objCompSvc.test();
            return RedirectToAction("Registration", "Emp");
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }*/
}
