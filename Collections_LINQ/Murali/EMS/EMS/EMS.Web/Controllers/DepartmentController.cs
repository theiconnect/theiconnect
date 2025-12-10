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
               
            return View("CreateDepartment");
        }
        public IActionResult EditDepartment(int id)
        {
            
            return View("EditDepartment");
        }
        public IActionResult ViewDepartment()
        {
           
            return View("view");

            
        }
    }
}
