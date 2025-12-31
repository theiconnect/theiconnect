using EMS.Models;
using EMS.Services;
using EMS.Services.Implementation;
using EMS.Services.Implementation.EFCore;
using EMS.IServices;
using EMS.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace EMS.Web.Controllers
{
    [Route("department")]
    [Route("dept")]
    public class DepartmentController : Controller
    {
        private IDepartmentService departmentService;

        public DepartmentController(IDepartmentService _departmentService)
        {
            departmentService = _departmentService;

        }

        [Route("list")]
        [Route("all")]
        public IActionResult List()
        {
            var departmentFromDb = departmentService.GetAllDepartments();

            var ViewModel = new List<DepartmentViewModel>();
            foreach (var model in departmentFromDb)
            {
                var obj = new DepartmentViewModel();
                obj.DepartmentId = model.DepartmentIdPk;
                obj.Code = model.DepartmentCode;
                obj.DeptName = model.DepartmentName;
                obj.IsActive = model.IsActive;
                ViewModel.Add(obj);
            }
            return View(ViewModel);
        }

        [Route("search")]
        [HttpGet]
        public IActionResult Searching(string searchName, string searchLocation)
        {
            List<DepartmentModel> departmentsFromDB = departmentService.GetAllDepartments(searchName, searchLocation);
            
            var viewModel = departmentsFromDB.Select(d => new DepartmentViewModel
            {
                DepartmentId = d.DepartmentIdPk,
                Code = d.DepartmentCode,
                DeptName = d.DepartmentName,
                Location = d.Location,
                IsActive = d.IsActive
            }).ToList();

            return View("List", viewModel);
        }

        [Route("add")]
        [Route("create")]
        [Route("new")]
        [HttpGet]
        public IActionResult CreateDepartment()
        {
            return View();
        }

        [Route("savedepartment")]
        [HttpPost]
        public IActionResult SaveDepartment(DepartmentViewModel viewModel)
        {
            DepartmentModel departmentModel = new DepartmentModel
            {
                DepartmentCode = viewModel.Code,
                DepartmentName = viewModel.DeptName,
                Location = viewModel.Location,
                IsActive = viewModel.IsActive
            };
            bool isSuccess = departmentService.SaveDepartment(departmentModel, true, out string message);

            if (isSuccess)
            {
                TempData["SuccessMessage"] = $"Department-{viewModel.DeptName} created successfully.";
                return RedirectToAction("list", "department");
            }
            else
            {
                ViewBag.ErrorMessage = message;
                return View("CreateDepartment", viewModel);
            }
        }

        [Route("edit/{id}")]
        [Route("update/{id}")]
        [Route("change/{id}")]
        [Route("modify/{id}")]
        [HttpGet]
        public IActionResult EditDepartment(int id)
        {
            var deptDB = departmentService.GetDepartmentById(id);

            var model = new DepartmentViewModel(
                    deptDB.DepartmentIdPk,
                    deptDB.DepartmentCode,
                    deptDB.DepartmentName,
                    deptDB.Location,
                    deptDB.IsActive
                    );

            return View(model);
        }

        [Route("UpdatesaveDepartment")]
        [HttpPost]
        public IActionResult UpdatesaveDepartment([FromBody] DepartmentViewModel updateModel)
        {

            DepartmentModel departmentModel = new DepartmentModel
            {
                DepartmentIdPk = updateModel.DepartmentId,
                DepartmentCode = updateModel.Code,
                DepartmentName = updateModel.DeptName,
                Location = updateModel.Location,
                IsActive = updateModel.IsActive
            };
            bool IsSuccess = departmentService.SaveDepartment(departmentModel, false, out string responseMessage);

            return Json(new { IsSuccess = IsSuccess, errorMessage = responseMessage });
        }


        [Route("view/{id}")]
        [Route("info/{id}")]
        [Route("details/{id}")]
        [HttpGet]
        public IActionResult ViewDepartment(int id)
        {
            var deptDB = departmentService.GetAllDepartments().FirstOrDefault(d => d.DepartmentIdPk == id);

            var model = new DepartmentViewModel(
                    deptDB.DepartmentIdPk,
                    deptDB.DepartmentCode,
                    deptDB.DepartmentName,
                    deptDB.Location,
                    deptDB.IsActive
                    );

            return View(model);
        }


        [Route("delete")]
        [HttpPost]
        public IActionResult DeactivateDepartment([FromBody] Test t)
        {
            bool isSuccess = departmentService.ActivateDeactivateDepartment(t.id, isDeactivate: true, out string responseMessage);

            //return Json(isSuccess, responseMessage);

            return Json(new { Success = isSuccess, Message = responseMessage });
        }

        [Route("active/{id}")]
        [HttpGet]
        public IActionResult ActivateDepartment(int id)
        {
            bool isSuccess = departmentService.ActivateDeactivateDepartment(id, isDeactivate: false, out string responseMessage);

            //return Json(isSuccess, responseMessage);

            return Json(new { Success = isSuccess, Message = responseMessage });
        }


    }

    public class Test
    {
        public int id { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public bool active { get; set; }
    }
}
