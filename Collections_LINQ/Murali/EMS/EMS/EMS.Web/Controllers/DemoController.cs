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

            //int a1 = 10;
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


        //=================================
        //[Route("cdd")]
        [HttpGet]
        public IActionResult CascadingDropdowns()
        {
            var countries = new List<CountryViewModel>
            {
                new CountryViewModel { CountryIdPk = 1, CountryName = "India" },
                new CountryViewModel { CountryIdPk = 2, CountryName = "USA" },
            };


            ViewBag.Countries = countries;

            return View("cdd");
        }

        [HttpGet]
        //[Route("loadstates/{countryId}")]//=> localhsot:3234/loadstates/2
        //localhsot:1223/demo/loadstates?countryId=2
        //[HttpPost]
        //public JsonResult LoadStates([FromBody]Dummy obj)
        public JsonResult LoadStates(int countryId)
        {
            var states = new List<StateViewModel>
            {
                new StateViewModel { StateIdPk = 1, StateName = "Tamil Nadu", CountryIdFk = 1 },
                new StateViewModel { StateIdPk = 2, StateName = "Karnataka", CountryIdFk = 1 },
                new StateViewModel { StateIdPk = 3, StateName = "Telangana", CountryIdFk = 1 },
                new StateViewModel { StateIdPk = 4, StateName = "Goa", CountryIdFk = 1 },
                new StateViewModel { StateIdPk = 5, StateName = "Andra Pradesh", CountryIdFk = 1 },
                new StateViewModel { StateIdPk = 6, StateName = "Texas", CountryIdFk = 2 },
                new StateViewModel { StateIdPk = 7, StateName = "NewYork", CountryIdFk = 2 },
            };

            var statesFiltered = states.FindAll(s => s.CountryIdFk == countryId);

            return Json(statesFiltered);
        }

        [HttpGet]
        [Route("cities/{id}")]
        public JsonResult LoadCities(int id)
        {
            var cities = new List<CityViewModel>
            {
                new CityViewModel { CityIdPk = 1, CityName = "Chennai", StateIdFk = 1 },
                new CityViewModel { CityIdPk = 2, CityName = "Coimbatore", StateIdFk = 1 },
                new CityViewModel { CityIdPk = 3, CityName = "Bangalore", StateIdFk = 2 },
                new CityViewModel { CityIdPk = 4, CityName = "Mysore", StateIdFk = 2 },
                new CityViewModel { CityIdPk = 5, CityName = "Hyderabad", StateIdFk = 3 },
                new CityViewModel { CityIdPk = 6, CityName = "Goa City", StateIdFk = 4 },
                new CityViewModel { CityIdPk = 7, CityName = "Vijayawada", StateIdFk = 5 },
                new CityViewModel { CityIdPk = 8, CityName = "Houston", StateIdFk = 6 },
                new CityViewModel { CityIdPk = 9, CityName = "Dallas", StateIdFk = 6 },
                new CityViewModel { CityIdPk = 10, CityName = "NewYork City", StateIdFk = 7 },
                new CityViewModel { CityIdPk = 11, CityName = "Nellore", StateIdFk = 5 },
                new CityViewModel { CityIdPk = 12, CityName = "Kurnool", StateIdFk = 5 },
                new CityViewModel { CityIdPk = 13, CityName = "Warangal", StateIdFk = 3 }
            };

            var statebasedCities = cities.FindAll(c => c.StateIdFk == id);

            return Json(statebasedCities);
        }
    }

    public class Dummy 
    {
        public int Id { get; set; }
    }
}