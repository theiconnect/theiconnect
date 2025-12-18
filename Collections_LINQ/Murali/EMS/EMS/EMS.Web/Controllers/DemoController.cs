using EMS.Models;
using EMS.Services;
using EMS.IServices;
using Microsoft.AspNetCore.Mvc;

namespace EMS.Web.Controllers
{
    public class DemoController : Controller
    {
        public DemoController()
        {

        }

        public IActionResult Index()
        {

            int a1 = 10;
            EmployeeModel obj = new EmployeeModel();
            obj.FirstName = "iconnect";
            obj.LastName = "Tech solutions";
            string str = "hi";

            ViewData["Value1"] = "View Data - TestValue1";
            ViewData["Value2"] = 1;
            ViewData["Value3"] = DateTime.Now;
            ViewData["Value4"] = false;

            ViewBag.Value5 = "View Bag - TestValue1";
            ViewBag.Value6 = 2;
            ViewBag.Value7 = DateTime.Now.AddYears(2);
            ViewBag.Value8 = true;

            var b = 20;//type will be fixed and we cannot change.
            b.ToString();
            //b = "hello";
            //b = DateTime.Now;

            dynamic a = 20;//type can be changed at runtime.
           
            a = "hello";
            a = Convert.ToString(DateTime.Now);
            a = false;

            
            return View("Murali", str);
        }

        public IActionResult BindDataFromControllerToView()
        {
            return View("bind");
        }

        public IActionResult GetEmployeeDetails([FromServices]IDepartmentService departmentService)
        {
            var emp = new EmployeeModel();
            var depts = departmentService.GetAllDepartments();
            if (depts.Any())
            {
                if (depts[0].Employees.Any())
                {
                    emp = depts[0].Employees[0];
                }
            }
            return View("EmployeeDetails", emp);

        }

    }
}
