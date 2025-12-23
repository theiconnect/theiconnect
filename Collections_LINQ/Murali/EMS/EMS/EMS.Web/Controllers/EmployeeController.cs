using EMS.Models;
using EMS.Models.Enums;
using EMS.Services;
using EMS.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace EMS.Web.Controllers
{
    // ==============================================
    // 1. EmployeeController
    // ==============================================

    [Route("Employee")]
    [Route("Emp")]
    public class EmployeeController : Controller
    {
        // Route: /Employee/getallemployees or /Employee/list
        private EmployeeServices employeeServices;
        public EmployeeController(EmployeeServices _employeeservices)
        {
            employeeServices = _employeeservices;

        }

        [Route("getallemployees")]
        [Route("list")]
        public IActionResult EmployeeList()
        {
            // NOTE: A ViewResult must return a View() or a string that can resolve to a View.
            // Returning "dfgh" as a string is invalid for ViewResult. Changed to View().
            // If you want to return a string, change the return type to 'string'.

            var employeesFromDB = employeeServices.GetAllEmployees();

            var employeesViewModel = new List<EmployeeListViewModel>();

            foreach (var emp in employeesFromDB)
            {
                EmployeeListViewModel obj = new EmployeeListViewModel();
                {
                    obj.EmployeeId = emp.EmployeeIdPk;
                    obj.Code = emp.Employeecode;
                    obj.FirstName = emp.FirstName;
                    obj.MiddleName = emp.MiddleName;
                    obj.LastName = emp.LastName;
                    obj.BloodGroup = emp.BloodGroup;
                    obj.Gender = emp.Gender;
                    obj.EmailId = emp.EmailId;
                    obj.MobileNumber = emp.MobileNumber;
                    obj.AlternateMobileNumber = emp.AlternateMobileNumber;
                    obj.DateOfBirth = emp.DateOfBirth;
                    obj.DateOfJoining = emp.DateOfJoining;
                    obj.ExpInMonths = emp.ExpInMonths;
                    obj.Salary = emp.SalaryCtc;
                    obj.IsActive = emp.IsActive;

                    employeesViewModel.Add(obj);

                }
            }
            ;


            return View(employeesViewModel);
        }



        public IActionResult AddEmployee()
        {

            return View();
        }

        // Route: /Employee/editemployee
        [Route("editemployee/{id}")]
        public IActionResult EditEmployee()
        {
            return View();
        }

        // Route: /Employee/deleteemployee

        //public IActionResult DeleteEmployee()
        //{
        //    return View();
        //}

        // Route: /Employee/viewemployee

        [Route("viewemployee/{id}")]
        public IActionResult ViewEmployee(int id)
        {
            return View();
        }
    }
}






    /*
    // ==============================================
    // 2. Employee1Controller
    // ==============================================
    [Route("e")]
    public class Employee1Controller : Controller
    {
        // Route: /e, /e/hellobabai, /e/hellochicha, /e/helloKaka
        [Route("")]
        [Route("hellobabai")]
      
        [Route("helloKaka")]
        public string Index()
        {
            return "Employee1Controller - Hello from sai ram";
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
            return "Hello hii";
        }
    }

    // ==============================================
    //// 5. CompanyController (For your Company Edit Page)
    //// ==============================================
    //[Route("Company")]
    //public class CompanyController : Controller
    //{
    //    // Route: /Company/EditCompany or /Company/edit
    //    [Route("edit")]
    //    public IActionResult EditCompany()
    //    {
    //        // This returns the view file located at /Views/Company/EditCompany.cshtml
    //        return View();
    //    }

    //    // Route: /Company/list
    //    [Route("list")]
    //    public IActionResult CompanyList()
    //    {
    //        return View();
    //    }
    //}
}
    */