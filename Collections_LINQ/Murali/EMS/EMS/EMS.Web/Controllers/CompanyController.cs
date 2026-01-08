using EMS.Models;
using EMS.Services.Implementation.TD;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace EMS.Web.Controllers
{
<<<<<<< HEAD
    [Route("company")] 
=======

   
>>>>>>> origin/main
    public class CompanyController : Controller
    {
        //[Route("edit")]
        public IActionResult EditCompany(int id )
        {
            object CompanyADOService = null;
            var company = CompanyADOService.GetCompany().FirstOrDefault(c => c.CompanyId == id);
            if (company == null) return NotFound();

            var model = new CompanyModel()
            {
                CompanyIdPk = company.CompanyId,
                CompanyName = company.CompanyName,
                PhoneNumber = company.PhoneNumber,
                Email = company.Email,
                RegistrationDate = company.RegistrationDate,
                Website = company.Website,
                BankAccountNumber = company.BankAccount
            };
            return View(model);
        }   
          





        //[Route("info")]
        //[Route("")]
        //[Route("view")]
        [Route("details")]
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