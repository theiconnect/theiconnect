using EMS.IServices;
using EMS.Models;
using EMS.Models.Enums;
using EMS.Services.Implementation;
using EMS.Services.Implementation.TD;
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
            var empDB = employeeServices.GetEmployeeDetailsById(employeeid);

            if (empDB == null)
                return NotFound();


            var viewModel = new EmployeeViewModel(
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
            var permAddress = empDB.Addresses.Find(a => a.AddressTypeIdFk == AddressTypes.PERM_ADDR);

            if (permAddress != null)
            {
                viewModel.PermanentAddress = new EmployeeAddressViewModel();
                viewModel.PermanentAddress.AddressLine1 = permAddress.AddressLine1;
                viewModel.PermanentAddress.AddressLine2 = permAddress.AddressLine2;
                viewModel.PermanentAddress.City = permAddress.City;
                viewModel.PermanentAddress.State = permAddress.State;
                viewModel.PermanentAddress.Pincode = permAddress.Pincode;
            }

            var presentAddress = empDB.Addresses.Find(a => a.AddressTypeIdFk == AddressTypes.PRESENT_ADDR);
            if (presentAddress != null)
            {
                viewModel.PresentAddress = new EmployeeAddressViewModel();
                viewModel.PresentAddress.AddressLine1 = presentAddress.AddressLine1;
                viewModel.PresentAddress.AddressLine2 = presentAddress.AddressLine2;
                viewModel.PresentAddress.City = presentAddress.City;
                viewModel.PresentAddress.State = presentAddress.State;
                viewModel.PresentAddress.Pincode = presentAddress.Pincode;
            }


            //viewModel.AddressHistory = empDB.AddressHistory;
            foreach(var dbhistory in empDB.AddressHistory)
            {
                viewModel.AddressHistory.Add(new EmployeeAddressViewModel()
                {
                    AddressLine1 = dbhistory.AddressLine1,
                    AddressLine2 = dbhistory.AddressLine2,
                    City = dbhistory.City,
                    State = dbhistory.State,
                    Pincode = dbhistory.Pincode
                });
            }



            return View(viewModel);
        }
        [HttpPost]
        [Route("UpdateSaveEmployee")]
        public IActionResult UpdateSaveEmployee(EmployeeViewModel updateModel)
        {
            EmployeeModel model = new EmployeeModel();
            {
                model.EmployeeIdPk = updateModel.EmployeeId;
                model.Employeecode = updateModel.Code;
                model.FirstName = updateModel.FirstName;
                model.LastName = updateModel.LastName;
                model.BloodGroup = (BloodGroups)updateModel.BloodGroup;
                model.Gender = (Genders)updateModel.Gender;
                model.EmailId = updateModel.EmailId;
                model.MobileNumber = updateModel.MobileNumber;
                model.DateOfBirth = updateModel.DateOfBirth;
                model.DateOfJoining = updateModel.DateOfJoining;
                model.ExpInMonths = updateModel.ExpInMonths;
                model.SalaryCtc = updateModel.SalaryCtc;
                model.IsActive = updateModel.IsActive;
            };
            //add permanent address from view model to address model
            EmployeeAddressModel employeeAddress = new EmployeeAddressModel();
            employeeAddress.AddressLine1 = updateModel.PermanentAddress.AddressLine1;
            employeeAddress.AddressLine2 = updateModel.PermanentAddress.AddressLine2;
            employeeAddress.City = updateModel.PermanentAddress.City;
            employeeAddress.State = updateModel.PermanentAddress.State;
            employeeAddress.Pincode = updateModel.PermanentAddress.Pincode;
            employeeAddress.AddressTypeIdFk = AddressTypes.PERM_ADDR;

            model.Addresses.Add(employeeAddress);

            //add present address to the model
            employeeAddress = new EmployeeAddressModel();

            employeeAddress.AddressLine1 = updateModel.PresentAddress.AddressLine1;
            employeeAddress.AddressLine2 = updateModel.PresentAddress.AddressLine2;
            employeeAddress.City = updateModel.PresentAddress.City;
            employeeAddress.State = updateModel.PresentAddress.State;
            employeeAddress.Pincode = updateModel.PresentAddress.Pincode;
            employeeAddress.AddressTypeIdFk = AddressTypes.PRESENT_ADDR;
            model.Addresses.Add(employeeAddress);

            string userName = User.Identity?.Name ?? "Admin";

            bool isSuccess = employeeServices.SaveEmployee(model, false, userName, out string responseMessage);
            return RedirectToAction("list");
        }

        [Route("viewemployee/{id}")]
        public IActionResult ViewEmployee(int id)
        {
            var empDB = employeeServices.GetEmployeeDetailsById(id);
            var viewModel = new EmployeeViewModel(
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
            var permAddress = empDB.Addresses.Find(a => a.AddressTypeIdFk == AddressTypes.PERM_ADDR);

            if (permAddress != null)
            {
                viewModel.PermanentAddress = new EmployeeAddressViewModel();
                viewModel.PermanentAddress.AddressLine1 = permAddress.AddressLine1;
                viewModel.PermanentAddress.AddressLine2 = permAddress.AddressLine2;
                viewModel.PermanentAddress.City = permAddress.City;
                viewModel.PermanentAddress.State = permAddress.State;
                viewModel.PermanentAddress.Pincode = permAddress.Pincode;
            }

            var presentAddress = empDB.Addresses.Find(a => a.AddressTypeIdFk == AddressTypes.PRESENT_ADDR);
            if (presentAddress != null)
            {
                viewModel.PresentAddress = new EmployeeAddressViewModel();
                viewModel.PresentAddress.AddressLine1 = presentAddress.AddressLine1;
                viewModel.PresentAddress.AddressLine2 = presentAddress.AddressLine2;
                viewModel.PresentAddress.City = presentAddress.City;
                viewModel.PresentAddress.State = presentAddress.State;
                viewModel.PresentAddress.Pincode = presentAddress.Pincode;
            }


            //viewModel.AddressHistory = empDB.AddressHistory;
            foreach (var dbhistory in empDB.AddressHistory)
            {
                viewModel.AddressHistory.Add(new EmployeeAddressViewModel()
                {
                    AddressLine1 = dbhistory.AddressLine1,
                    AddressLine2 = dbhistory.AddressLine2,
                    City = dbhistory.City,
                    State = dbhistory.State,
                    Pincode = dbhistory.Pincode
                });
            }
            return View(viewModel);
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











