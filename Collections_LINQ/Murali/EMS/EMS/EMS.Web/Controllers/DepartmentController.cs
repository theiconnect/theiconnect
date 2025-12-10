using EMS.Models;
using EMS.Services;
using Microsoft.AspNetCore.Mvc;

namespace EMS.Web.Controllers
{
    public class DepartmentController : Controller
    {
        public IActionResult List()
        {
            //EMSDbContext obj = EMSDbContext.GetInstance();
            DepartmentService departmentService = new DepartmentService();
            var departments = departmentService.GetAllDepartments();
            return View(departments);
        }
        public IActionResult List1()
        {
            //EMSDbContext obj = EMSDbContext.GetInstance();
            DepartmentService departmentService = new DepartmentService();
            var departments = departmentService.GetAllDepartments();
            return View("DepartmentList", departments);
        }

        public IActionResult CreateDepartment()
        {
            DepartmentModel departmentModel = new DepartmentModel();
            return View(departmentModel);
        }
        public IActionResult EditDepartment(int id)
        {
            DepartmentService departmentService = new DepartmentService();
            var department = departmentService.GetAllDepartments().FirstOrDefault(d => d.DepartmentIdPk == id);
            return View(department);
        }
        public IActionResult ViewDepartment()
        {
            DepartmentModel departmentModel = new DepartmentModel();
            return View(departmentModel);

            
        }
    }
}
