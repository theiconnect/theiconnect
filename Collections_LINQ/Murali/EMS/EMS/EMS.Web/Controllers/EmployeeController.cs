using EMS.IServices;
using EMS.Models;
using EMS.Models.Enums;
using EMS.Services;
using EMS.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Runtime.ExceptionServices;

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
        private IEmployeeService employeeServices;
        public EmployeeController(IEmployeeService _employeeservices)
        {
            employeeServices = _employeeservices;
        }


        [Route("getallemployees")]
        [Route("list")]
        [HttpGet]
        public IActionResult EmployeeList()
        {
            var employeesFromDB = employeeServices.GetEmployeeDetails();

            var EmployeeModel = new List<EmployeeListViewModel>();

            foreach (var emp in employeesFromDB)
            {
                EmployeeListViewModel obj = new EmployeeListViewModel();
                obj.EmployeeId = emp.EmployeeIdPk;
                obj.Code = emp.Employeecode;
                obj.FirstName = emp.FirstName;
                obj.LastName = emp.LastName;
                obj.BloodGroup =(BloodGroups)(int)emp.BloodGroup;
                obj.Gender =(int)emp.Gender;
                obj.EmailId = emp.EmailId;
                obj.MobileNumber = emp.MobileNumber;
                obj.DateOfBirth = emp.DateOfBirth;
                obj.DateOfJoining = emp.DateOfJoining;
                obj.ExpInMonths = emp.ExpInMonths;
                obj.SalaryCtc = emp.SalaryCtc;
                obj.IsActive = emp.IsActive;
                EmployeeModel.Add(obj);
            }

            return View(EmployeeModel);
        }
        public IActionResult AddEmployee()
        {
            return View();
        }

        [HttpPost]
        [Route("saveemployees")]


        public IActionResult SaveEmployee(EmployeeViewModel viewModel)
        {
            string userName = User.Identity?.Name ?? "Admin";
            EmployeeModel EmployeeModel = new EmployeeModel()
            {
                Employeecode = viewModel.Code,
                FirstName = viewModel.FirstName,
                LastName = viewModel.LastName,
                BloodGroup = (BloodGroups)viewModel.BloodGroup,
                Gender = (Genders)viewModel.Gender,
                EmailId = viewModel.EmailId,
                MobileNumber = viewModel.MobileNumber,
                DateOfBirth = viewModel.DateOfBirth,
                DateOfJoining = viewModel.DateOfJoining,
                ExpInMonths = viewModel.ExpInMonths,
                SalaryCtc = viewModel.SalaryCtc,
                IsActive = viewModel.IsActive
            };

            bool isSuccess = employeeServices.SaveEmployee(EmployeeModel, true, userName, out string message);

            if (isSuccess)
            {
                TempData["SuccessMessage"] = $"Employee-{viewModel.FirstName} created successfully.";
                return RedirectToAction("list", "Employee");
            }
            else
            {
                ViewBag.ErrorMessage = message;
                return View("AddEmployee", viewModel);
            }
        }
    

        [Route("Updatesaveemployee")]
        public IActionResult Updatesaveemployee(EmployeeViewModel updatemodel)
        {

            EmployeeModel EmployeeModel = new EmployeeModel()
            {
                EmployeeIdPk = updatemodel.EmployeeId,
                Employeecode = updatemodel.Code,
                FirstName = updatemodel.FirstName,
                LastName = updatemodel.LastName,
                BloodGroup = (BloodGroups)updatemodel.BloodGroup,
                Gender = (Genders)updatemodel.Gender,
                EmailId = updatemodel.EmailId,
                MobileNumber = updatemodel.MobileNumber,
                DateOfBirth = updatemodel.DateOfBirth,
                DateOfJoining = updatemodel.DateOfJoining,
                ExpInMonths = updatemodel.ExpInMonths,
                SalaryCtc = updatemodel.SalaryCtc,
                IsActive = updatemodel.IsActive
            };
            string userName = User.Identity?.Name ?? "Admin";
            bool issuccess = employeeServices.SaveEmployee(EmployeeModel, false,userName, out string responsemessage
               );
            return RedirectToAction("list");
        }

        [Route("editemployee/{employeeid}")]
        public IActionResult EditEmployee(int employeeid)
        {
            var employee = employeeServices.GetEmployeeDetails().FirstOrDefault(e=>e.EmployeeIdPk==employeeid);

            if (employee == null)
            {
                return NotFound();
            }
            var model = new EmployeeViewModel
            {
                EmployeeId = employee.EmployeeIdPk,
                Code = employee.Employeecode,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                BloodGroup = (int)employee.BloodGroup,
                Gender = (int)employee.Gender,
                EmailId = employee.EmailId,
                MobileNumber = employee.MobileNumber,
                DateOfBirth = employee.DateOfBirth,
                DateOfJoining = employee.DateOfJoining,
                ExpInMonths = employee.ExpInMonths,
                SalaryCtc = employee.SalaryCtc,
                IsActive = employee.IsActive
            };

            return View(model);
        }


        [Route("viewemployee/{employeeid}")]
        public IActionResult ViewEmployee(int employeeid)
        {
            var employee = employeeServices.GetEmployeeDetails().FirstOrDefault(e => e.EmployeeIdPk == employeeid);

            if (employee == null)
            {
                return NotFound();
            }
            var model = new EmployeeViewModel
            {
                EmployeeId = employee.EmployeeIdPk,
                Code = employee.Employeecode,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                BloodGroup = (int)employee.BloodGroup,
                Gender = (int)employee.Gender,
                EmailId = employee.EmailId,
                MobileNumber = employee.MobileNumber,
                DateOfBirth = employee.DateOfBirth,
                DateOfJoining = employee.DateOfJoining,
                ExpInMonths = employee.ExpInMonths,
                SalaryCtc = employee.SalaryCtc,
                IsActive = employee.IsActive
            };

            return View(model);
        }


[Route("delete")]
[HttpPost]
public IActionResult DeactivateEmployee([FromBody] EmployeeViewModel ViewModel)
{
    string userName = User.Identity?.Name ?? "Admin";
    bool isSuccess = employeeServices.ActivateDeactivateEmployee(ViewModel.EmployeeId, isDeactivate: true, userName, out string responseMessage);

    //return Json(isSuccess, responseMessage);

    return Json(new { Success = isSuccess, Message = responseMessage });
}

[Route("active/{id}")]
[HttpGet]
public IActionResult ActivateEmployee(int id)
{
    string userName = User.Identity?.Name ?? "Admin";
    bool isSuccess = employeeServices.ActivateDeactivateEmployee(id, isDeactivate: false, userName, out string responseMessage);

    //return Json(isSuccess, responseMessage);

    return Json(new { Success = isSuccess, Message = responseMessage });
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