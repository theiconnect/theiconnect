using EMS.Models;
using EMS.Models.Enums;
using Microsoft.AspNetCore.Mvc;

namespace EMS.Web.Controllers
{
    [Route("Employee")]
    public class EmployeeController : Controller
    {
        [Route("getallemployees")]
        [Route("list")]
        public IActionResult EmployeeList()
        {
            List<EmployeeModel> employees = new List<EmployeeModel>();
            employees.Add(new EmployeeModel
            {
                Addresses = null,
                Employeecode = "E001",
                FirstName = "John",
                LastName = "Doe",
                DepartmentIdFk = 1

            });
            employees.Add(new EmployeeModel
            {
                Addresses = null,
                Employeecode = "E002",
                FirstName = "sai",
                LastName = "Prasad",
                DepartmentIdFk = 2

            });
            employees.Add(new EmployeeModel
            {
                Addresses = null,
                Employeecode = "E003",
                FirstName = "venky",
                LastName = "chereddy",
                DepartmentIdFk = 3

            });
            return View(employees);
        }

        [Route("addemployee")]
        public IActionResult AddEmployee()



        {
            return View();
        }

        [Route("editemployee")]
        public IActionResult EditEmployee()
        {
            return View();
        }

        [Route("deleteemployee")]
        public IActionResult DeleteEmployee()
        {
            return View();
        }

        [Route("viewemployee")]
        public IActionResult ViewEmployee()
        {
            return View();
        }
    }

    [Route("e")]
    public class Employee1Controller : Controller
    {


        [Route("")]
        [Route("hellobabai")]
        [Route("hellochicha")]
        [Route("helloKaka")]
        public string Index()
        {
            return "Employee1Controller - Hello from Index";
        }

        public int Index2()
        {
            return 100;
        }

        public int Index3()
        {
            return 100;
        }


        [NonAction]
        public string Index1()
        {
            return "Hello from Index1";
        }
    }

    
    [Route("Test")]
    public class TestController : Controller
    {
        public string A()
        {
            return string.Empty;
        }
        //localhost:234/test
        [Route("test")]
        public string B()
        {
            return string.Empty;
        }

        public string C()
        {
            return string.Empty;
        }
    }

    [Route("Test1")]
    public class Test1Controller : Controller
    {
        public string A()
        {
            return string.Empty;
        }

        //localhost:234/test
        [Route("test")]
        public string B()
        {
            return string.Empty;
        }

        public string C()
        {
            return string.Empty;
        }
    }

}
