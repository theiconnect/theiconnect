using EMS.IServices;
using EMS.Models;
using EMS.Models.Enums;
using EMS.Services.Implementation.TD;
using EMS.Web.Models;
using EMS.Web.Models.Enums;
using Intuit.Ipp.Data;
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
            var employeesFromDB = employeeServices.GetAllEmployees();

            var EmployeeModel = new List<EmployeeListViewModel>();

            foreach (var emp in employeesFromDB)
            {
                EmployeeListViewModel obj = new EmployeeListViewModel();
                obj.EmployeeId = emp.EmployeeIdPk;
                obj.Code = emp.Employeecode;
                obj.FirstName = emp.FirstName;
                obj.LastName = emp.LastName;
                obj.BloodGroup = emp.BloodGroup;
                obj.Gender = emp.Gender;
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

        // Route: /Employee/editemployee
        [Route("editemployee/{employeeid}")]
        public IActionResult EditEmployee(int employeeid)
        {
            var empDB = employeeServices
                .GetAllEmployees()
                .FirstOrDefault(e => e.EmployeeIdPk == employeeid);

            if (empDB == null)
                return NotFound();


            var model = new EmployeeViewModel(
                empDB.EmployeeIdPk,
                empDB.Employeecode,
                empDB.FirstName,
                empDB.LastName,
                empDB.BloodGroup,
                empDB.Gender,
                empDB.EmailId,
                empDB.MobileNumber,
                empDB.DateOfBirth,
                empDB.DateOfJoining,
                empDB.ExpInMonths,
                empDB.SalaryCtc,
                empDB.IsActive

            );
            return View(model);
        }
        [HttpPost]
        [Route("Employee/UpdateSaveEmployee")]
        public IActionResult UpdateSaveEmployee([FromBody] EmployeeViewModel updateModel)
        {
            EmployeeModel employeeModel = new EmployeeModel
            {
                EmployeeIdPk = updateModel.EmployeeId,
                Employeecode = updateModel.Code,
                FirstName = updateModel.FirstName,
                LastName = updateModel.LastName,
                BloodGroup = updateModel.BloodGroup,
                Gender = updateModel.Gender,
                EmailId = updateModel.EmailId,
                MobileNumber = updateModel.MobileNumber,
                DateOfBirth = updateModel.DateOfBirth,
                DateOfJoining = updateModel.DateOfJoining,
                ExpInMonths = updateModel.ExpInMonths,
                SalaryCtc = updateModel.SalaryCtc,
                IsActive = updateModel.IsActive
            };
            bool isSuccess = employeeServices.SaveEmployee(employeeModel, false, out string responseMessage
               );
            return Json(new { IsSuccess = isSuccess, errorMessage = responseMessage });
        }

        // Route: /Employee/viewemployee
        [Route("viewemployee/{id}")]
        public IActionResult ViewEmployee(int id)
        {
            var empDB = employeeServices.GetAllEmployees()
                                          .FirstOrDefault(e => e.EmployeeIdPk == id);
                                          
                                          
           if (empDB == null) 
                return NotFound();

            return Json(new { Success = isSuccess, Message = responseMessage });
        }

        [Route("active/{id}")]
        [HttpGet]

        public IActionResult ActivateDepartment(int id)
        {
            bool isSuccess = employeeServices.ActivateDeactivateEmployee(id, isDeactivate: false, out string responseMessage);

            //return Json(isSuccess, responseMessage);

            return View(model);
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