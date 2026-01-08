using EMS.Models;
using EMS.Services.Implementation.ADO;
using EMS.Services.Implementation.TD;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using EMS.Web.Models;
using EMS.IServices;


namespace EMS.Web.Controllers
{

    [Route("Company")]
    public class CompanyController : Controller
    {
        private readonly ICompanyService companyservice;
        public CompanyController(ICompanyService _obj)
        {
            companyservice  = _obj;

        }
        //[Route("edit")]
        public IActionResult EditCompany(int i )
        {
            //object CompanyADOService = null;
            var company = companyservice.GetCompany();
            if (company == null) return NotFound();

            var model = new CompanyModel()
            {
                CompanyIdPk = company.CompanyIdPk,
                CompanyName = company.CompanyName,
                PhoneNumber = company.PhoneNumber,
                Email = company.Email,
                RegistrationDate = company.RegistrationDate,
                Website = company.Website,
                BankAccountNumber = company.BankAccountNumber
            };
            return View(model);
        }   
          





        //[Route("info")]
        //[Route("")]
        [Route("view")]
       // [Route("details")]
       public  IActionResult ViewCompany() 
        {
            var company = companyservice.GetCompany();
            if (company == null) return NotFound();

            var Viewmodel = new CompanyViewModel()
            {
                CompanyIdPk = company.CompanyIdPk,
                CompanyName = company.CompanyName,
                PhoneNumber = company.PhoneNumber,
                Email = company.Email,
                RegistrationDate = company.RegistrationDate,
                Website = company.Website,
                BankAccountNumber = company.BankAccountNumber
            };
            return View(Viewmodel);
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