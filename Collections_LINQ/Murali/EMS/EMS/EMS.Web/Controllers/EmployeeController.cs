using EMS.Models;
using Microsoft.AspNetCore.Mvc;

namespace EMS.Web.Controllers
{
    // ==============================================
    // 1. EmployeeController
    // ==============================================
    [Route("Employee")]
    public class EmployeeController : Controller
    {
        // Route: /Employee/getallemployees or /Employee/list
        [Route("getallemployees")]
        [Route("list")]
        public ViewResult EmployeeList()
        {
            // NOTE: A ViewResult must return a View() or a string that can resolve to a View.
            // Returning "dfgh" as a string is invalid for ViewResult. Changed to View().
            // If you want to return a string, change the return type to 'string'.
            return View();
        }

        // Route: /Employee/editemployee
        [Route("editemployee")]
        public IActionResult EditEmployee()
        {
            return View();
        }

        // Route: /Employee/deleteemployee
        [Route("deleteemployee")]
        public IActionResult DeleteEmployee()
        {
            return View();
        }

        // Route: /Employee/viewemployee
        [Route("viewemployee")]
        public IActionResult ViewEmployee()
        {
            return View();
        }
    }

    // ==============================================
    // 2. Employee1Controller
    // ==============================================
    [Route("e")]
    public class Employee1Controller : Controller
    {
        // Route: /e, /e/hellobabai, /e/hellochicha, /e/helloKaka
        [Route("")]
        [Route("hellobabai")]
        [Route("hellochicha")]
        [Route("helloKaka")]
        public string Index()
        {
            return "Employee1Controller - Hello from Index";
        }

        // Route: /e/Index2 (Implicit default routing)
        public int Index2()
        {
            return 100;
        }

        // Route: /e/Index3 (Implicit default routing)
        public int Index3()
        {
            return 100;
        }

        // This action cannot be called via a URL because of the [NonAction] attribute
        [NonAction]
        public string Index1()
        {
            return "Hello from Index1";
        }
    }

    // ==============================================
    // 3. TestController
    // ==============================================
    [Route("Test")]
    public class TestController : Controller
    {
        // Route: /Test/Sai
        [Route("Sai")]
        public IActionResult A()
        {
            return View();
        }

        // Route: /Test/test
        [Route("test")]
        public string B()
        {
            return string.Empty;
        }

        // Route: /Test/C (Implicit default routing)
        public string C()
        {
            return string.Empty;
        }
    }

    // ==============================================
    // 4. Test1Controller
    // ==============================================
    [Route("Test1")]
    public class Test1Controller : Controller
    {
        // Route: /Test1/A (Implicit default routing)
        public string A()
        {
            return string.Empty;
        }

        // Route: /Test1/test
        [Route("test")]
        public string B()
        {
            return string.Empty;
        }

        // Route: /Test1/C (Implicit default routing)
        public string C()
        {
            return string.Empty;
        }
    }

    // ==============================================
    // 5. CompanyController (For your Company Edit Page)
    // ==============================================
    [Route("Company")]
    public class CompanyController : Controller
    {
        // Route: /Company/EditCompany or /Company/edit
        [Route("edit")]
        public IActionResult EditCompany()
        {
            // This returns the view file located at /Views/Company/EditCompany.cshtml
            return View();
        }

        // Route: /Company/list
        [Route("list")]
        public IActionResult CompanyList()
        {
            return View();
        }
    }
}