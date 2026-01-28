using EMS.IServices;
using EMS.Models;
using EMS.Models.Enums;
using EMS.Services.Implementation;
using EMS.Services.Implementation.TD;
using EMS.Web.Models;
using EMS.Web.Models.Enums;
using Google.Apis.Admin.Directory.directory_v1.Data;
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
                obj.Gender = emp.Gender;
                obj.EmailId = emp.EmailId;
                obj.MobileNumber = emp.MobileNumber;
                obj.DateOfBirth = emp.DateOfBirth;
                obj.IsActive = emp.IsActive;
                EmployeeModel.Add(obj);
            }

            return View(EmployeeModel);
        }
        public IActionResult AddEmployee()
        {
            return View();
        }

        [Route("saveemployee")]
        [HttpPost]
        public IActionResult SaveEmployee(EmployeeViewModel viewModel)
        {
            string userName = User.Identity?.Name ?? "Admin";
            EmployeeModel model = new EmployeeModel
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
                IsActive = viewModel.IsActive//should be active by default
            };

            //add permanent address from view model to address model
            EmployeeAddressModel employeeAddress = new EmployeeAddressModel();

            employeeAddress.AddressLine1 = viewModel.PermanentAddress.AddressLine1;
            employeeAddress.AddressLine2 = viewModel.PermanentAddress.AddressLine2;
            employeeAddress.City = viewModel.PermanentAddress.City;
            employeeAddress.State = viewModel.PermanentAddress.State;
            employeeAddress.Pincode = viewModel.PermanentAddress.Pincode;
            employeeAddress.AddressTypeIdFk = AddressTypes.PERM_ADDR;

            model.Addresses.Add(employeeAddress);

            //add present address to the model
            employeeAddress = new EmployeeAddressModel();

            employeeAddress.AddressLine1 = viewModel.PresentAddress.AddressLine1;
            employeeAddress.AddressLine2 = viewModel.PresentAddress.AddressLine2;
            employeeAddress.City = viewModel.PresentAddress.City;
            employeeAddress.State = viewModel.PresentAddress.State;
            employeeAddress.Pincode = viewModel.PresentAddress.Pincode;
            employeeAddress.AddressTypeIdFk = AddressTypes.PRESENT_ADDR;
            model.Addresses.Add(employeeAddress);

            bool isSuccess = employeeServices.SaveEmployee(model, true, userName, out string message);

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
                (int)empDB.BloodGroup,
                (int)empDB.Gender,
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
        [Route("UpdateSaveEmployee")]
        public IActionResult UpdateSaveEmployee(EmployeeViewModel updateModel)
        {
            EmployeeModel employeeModel = new EmployeeModel();
            {
                employeeModel.EmployeeIdPk = updateModel.EmployeeId;
                employeeModel.Employeecode = updateModel.Code;
                employeeModel.FirstName = updateModel.FirstName;
                employeeModel.LastName = updateModel.LastName;
                employeeModel.BloodGroup = (BloodGroups)updateModel.BloodGroup;
                employeeModel.Gender = (Genders)updateModel.Gender;
                employeeModel.EmailId = updateModel.EmailId;
                employeeModel.MobileNumber = updateModel.MobileNumber;
                employeeModel.DateOfBirth = updateModel.DateOfBirth;
                employeeModel.DateOfJoining = updateModel.DateOfJoining;
                employeeModel.ExpInMonths = updateModel.ExpInMonths;
                employeeModel.SalaryCtc = updateModel.SalaryCtc;
                employeeModel.IsActive = updateModel.IsActive;
            };
            string userName = User.Identity?.Name ?? "Admin";

            bool isSuccess = employeeServices.SaveEmployee(employeeModel, false, userName, out string responseMessage);
            return RedirectToAction("list");
        [Route("Employee/UpdateSaveEmployee")]
        public IActionResult UpdateSaveEmployee([FromBody] EmployeeViewModel updateModel)
        {
            EmployeeModel employeeModel = new EmployeeModel
            {
                EmployeeIdPk = updateModel.EmployeeId,
                Employeecode = updateModel.Code,
                FirstName = updateModel.FirstName,
                LastName = updateModel.LastName,
                BloodGroup = (BloodGroups)updateModel.BloodGroup,
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

        [Route("viewemployee/{id}")]
        public IActionResult ViewEmployee(int id)
        {
            var empDB = employeeServices.GetAllEmployees()
                                          .FirstOrDefault(e => e.EmployeeIdPk == id);
            var model = new EmployeeViewModel(
                empDB.EmployeeIdPk,
                empDB.Employeecode,
                empDB.FirstName,
                empDB.LastName,
                (int)empDB.BloodGroup,
                (int)empDB.Gender,
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

        [Route("delete")]
        [HttpPost]
        public IActionResult DeactivateDepartment([FromBody] EmployeeViewModel ViewModel)
        {
            string userName = User.Identity?.Name ?? "Admin";
            bool isSuccess = employeeServices.ActivateDeactivateEmployee(ViewModel.EmployeeId, isDeactivate: true, userName, out string responseMessage);

            //return Json(isSuccess, responseMessage);

            return Json(new { Success = isSuccess, Message = responseMessage });
        }

        [Route("active/{id}")]
        [HttpGet]
        public IActionResult ActivateDepartment(int id)
        {
            string userName = User.Identity?.Name ?? "Admin";
            bool isSuccess = employeeServices.ActivateDeactivateEmployee(id, isDeactivate: false, userName, out string responseMessage);

            //return Json(isSuccess, responseMessage);

            return Json(new { Success = isSuccess, Message = responseMessage });
        }
    }
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