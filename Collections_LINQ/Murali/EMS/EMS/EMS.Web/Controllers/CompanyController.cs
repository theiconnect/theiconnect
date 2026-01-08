using EMS.Models;
using EMS.Services.Implementation.ADO;
using EMS.Services.Implementation.TD;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace EMS.Web.Controllers
{
    [Route("company")] 
    public class CompanyController : Controller
    {
        private readonly CompanyADOService _companyADOService;

        public CompanyController(CompanyADOService companyADOService)
        {
            _companyADOService = companyADOService;
        }

        //[Route("edit")]
        public IActionResult EditCompany(int id)
        {
            var company = _companyADOService.GetCompany().FirstOrDefault(c => c.CompanyIdPk == id);
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
        //[Route("view")]
        [Route("details")]
        public IActionResult ViewCompany()
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