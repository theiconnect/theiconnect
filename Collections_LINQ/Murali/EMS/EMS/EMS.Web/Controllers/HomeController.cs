using EMS.Services;
using EMS.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EMS.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly CompanyService objCompSvc;
        public HomeController(ILogger<HomeController> logger, CompanyService companyService)
        {
            _logger = logger;
            objCompSvc = companyService;
        }

        public IActionResult Index()
        {
            objCompSvc.test();
            

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
