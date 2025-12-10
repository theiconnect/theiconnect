using System.Collections.Generic;
using System.Linq;
using EMS.Models;
using Microsoft.AspNetCore.Mvc;

namespace EMS.Web.Controllers
{
    [Route("Company")]
    public class CompanyController : Controller
    {
        [Route("edit")]
        public IActionResult EditCompany() => View();

        [Route("info")]
        [Route("")]
        [Route("view")]
        [Route("details")]
       public  IActionResult ViewCompany() 
        {
            return View();
        }
    }
}