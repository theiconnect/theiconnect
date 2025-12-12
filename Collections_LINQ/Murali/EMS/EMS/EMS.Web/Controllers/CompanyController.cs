using System.Collections.Generic;
using System.Linq;
using EMS.Models;
using Microsoft.AspNetCore.Mvc;

namespace EMS.Web.Controllers
{
    
    public class CompanyController : Controller
    {
        //[Route("edit")]
        public IActionResult EditCompany()
        {
            return View();
        }

        //[Route("info")]
        //[Route("")]
        //[Route("view")]
        //[Route("details")]
       public  IActionResult ViewCompany() 
        {
            return View();
        }

        //[Route("list")]
        //public IActionResult CompanyList()
        //{
        //    // Replace with real data retrieval (repository/service) as needed.
        //    IEnumerable<CompanyModel> companies = Enumerable.Empty<CompanyModel>();
        //    return View(companies);
        //}
    }
}