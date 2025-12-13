using EMS.Models;
using EMS.Services;
using Microsoft.AspNetCore.Mvc;

namespace EMS.Web.Controllers
{
    public class DepartmentController : Controller
    {

        public IActionResult List()
        {
            //EMSDbContext obj0 = EMSDbContext.GetInstance();
            DepartmentService departmentService = new DepartmentService();
            var Model = departmentService.GetAllDepartments();
            return View(Model);
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
            
            return View();
        }
        public IActionResult EditDepartment(int id)
        {
            
            return View("EditDepartment");
        }
        public IActionResult ViewDepartment()
        {
           
            return View();

            
        }
    }
}
