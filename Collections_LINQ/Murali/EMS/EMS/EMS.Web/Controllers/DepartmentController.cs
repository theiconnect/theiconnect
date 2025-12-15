using EMS.Models;
using EMS.Services;
using EMS.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace EMS.Web.Controllers
{
    [Route("Department")]
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

            var viewModel = new List<DepartmentListViewModel>();

            foreach (var deptDB in departmentsFromDB)
            {
                DepartmentListViewModel obj = new DepartmentListViewModel();
                obj.DepartmentId = deptDB.DepartmentIdPk;
                obj.Code = deptDB.DepartmentCode;
                obj.DeptName = deptDB.DepartmentName;
                //obj.Location = deptDB.Location;
                obj.IsActive = deptDB.IsActive;

                viewModel.Add(obj);
            }
            return View(viewModel);
        }

        public IActionResult CreateDepartment()
        {
            
            return View();
        }
        public IActionResult EditDepartment(int id)
        {
            
            return View("EditDepartment");
        }

        [Route("view/{id}")]
        [Route("info/{id}")]
        [Route("details/{id}")]
        public IActionResult ViewDepartment(int id)
        {
            var deptDB = departmentService.GetAllDepartments();
                return View();
        }
    }
}

