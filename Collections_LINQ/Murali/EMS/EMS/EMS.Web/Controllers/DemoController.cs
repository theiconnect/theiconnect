using System.Xml.Linq;
using EMS.IServices;
using EMS.Models;
using EMS.Services;
using EMS.Web.Models;
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

        //BindDataFromControllerToViewUsingPlainHTMLAndJS--Start
        public IActionResult BindDataFromControllerToViewUsingPlainHTMLAndJS()
        {
            return View("bind");
        }

        [HttpGet]
        public IActionResult GetEmployeeDetails([FromServices] IDepartmentService departmentService)
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
            return Json(emp);

        }

        [HttpPost]
        public IActionResult SaveEmployeeDetails([FromBody] EmployeeModel model)
        {
            //saved logic to the DB
            return Json(new { IsSuccess = false, errorMessage = "Service not responded" });
        }
        //BindDataFromControllerToViewUsingPlainHTMLAndJS--End


        //GetPostDataUsingModel - Start
        [HttpGet]
        public IActionResult GetPostDataUsingModel()
        {
            return View(new InvoiceViewModel());
        }

        [HttpPost]
        public IActionResult GetPostDataUsingModel(InvoiceViewModel model)
        {
            if (ModelState.IsValid)
            {
                //save to db
            }
            else
            {
                //go back to view and show error msg
            }
            return View();
        }
        //GetPostDataUsingModel - End

        [Route("Sneha")]
       

        public IActionResult Nickname()
        {
            string Name = "Shreya";


            return View("Sneha", Name);
        }
    }
}