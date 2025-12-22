using EMS.Models;
using EMS.Services;
using EMS.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace EMS.Web.Controllers
{
    [Route("department")]
    [Route("dept")]
    public class DepartmentController : Controller
    {
        private DepartmentService departmentService;

        public DepartmentController(DepartmentService _departmentService)
        {
            departmentService = _departmentService;
            
        }

        [Route("list")]
        [Route("all")]
        public IActionResult List()
        {
            //EMSDbContext obj = EMSDbContext.GetInstance();
            //DepartmentService departmentService = new DepartmentService();

            var departmentsFromDB = departmentService.GetAllDepartments();

            var viewModel = new List<DepartmentViewModel>();

            foreach (var deptDB in departmentsFromDB)
            {
                var obj = new DepartmentViewModel(
                    _departmentId: deptDB.DepartmentIdPk,
                    _code: deptDB.DepartmentCode,
                    _name: deptDB.DepartmentName,
                    _location: deptDB.Location,
                    _isActive: deptDB.IsActive
                    );

                viewModel.Add(obj);
            }

            return View(viewModel);
        }

        [Route("add")]
        [Route("create")]
        [Route("new")]
        public IActionResult CreateDepartment()
        {            
            return View();
        }

        [Route("savedepartment")]
        public IActionResult SaveDepartment(DepartmentViewModel model)
        {
            return RedirectToAction("list", "department");
        }

        [Route("edit/{id}")]
        [Route("update/{id}")]
        [Route("change/{id}")]
        [Route("modify/{id}")]
        public IActionResult EditDepartment(int id)
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

        [Route("view/{id}")]
        [Route("info/{id}")]
        [Route("details/{id}")]
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


        [Route("delete/{id}")]
        public IActionResult DeactivateDepartment(int id)
        {
            bool isSuccess = departmentService.ActivateDeactivateDepartment(id, isDeactivate: true, out string responseMessage);
            
            //return Json(isSuccess, responseMessage);

            return Json(new { Success = isSuccess, Message = responseMessage });
        }

        [Route("active/{id}")]
        public IActionResult ActivateDepartment(int id)
        {
            bool isSuccess = departmentService.ActivateDeactivateDepartment(id, isDeactivate: false, out string responseMessage);

            //return Json(isSuccess, responseMessage);

            return Json(new { Success = isSuccess, Message = responseMessage });
        }


    }
}
