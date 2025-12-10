using Asp.NetMVC.Models;
using Asp.NetMVC.Service.Models;
using Asp.NetMVC.Service.Services;
using Microsoft.AspNetCore.Mvc;

namespace Asp.NetMVC.Controllers
{
    public class EmpController : Controller
    {
        private readonly EmployeeService _employeeService;
        private readonly ILogger<EmpController> _logger;

        public EmpController(EmployeeService employeeService, ILogger<EmpController> logger)
        {
            _employeeService = employeeService;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SaveEmployee(Employee emp)
        public IActionResult SaveEmployee(Employee emp)
        {
            var result = _employeeService.SaveEmployee(emp);
            TempData["Message"] = "Employee saved successfully!";

            return View("Index");
        }
    }
}

    
