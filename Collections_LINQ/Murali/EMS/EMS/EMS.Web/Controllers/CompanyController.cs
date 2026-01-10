using EMS.Models;
using EMS.Services.Implementation.ADO;
using EMS.Services.Implementation.TD;
using Microsoft.AspNetCore.Mvc;
using EMS.Services;
using EMS.IServices;
using EMS.Web.Models;
using EMS.Services;

namespace EMS.Web.Controllers
{
    [Route("company")]
    public class CompanyController : Controller
    {
        private ICompanyService companyservice;
        public CompanyController(ICompanyService _obj)
        {
            companyservice = _obj;
        }

        [Route("edit")]
        [Route("modify")]
        public IActionResult EditCompany(int id)
        {
            object CompanyADOService = null;
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

        [Route("view")]
        public IActionResult ViewCompany()
        {
            var companyDB = companyservice.GetCompany();
            var viewmodel = new CompanyViewModel()
            {
                CompanyIdPk = companyDB.CompanyIdPk,
                CompanyName = companyDB.CompanyName,
                PhoneNumber = companyDB.PhoneNumber,
                Email = companyDB.Email,
                RegistrationDate = companyDB.RegistrationDate,
                Website = companyDB.Website,
                BankAccountNumber = companyDB.BankAccountNumber,
                TIN = companyDB.TIN,
                PAN = companyDB.PAN
            };

            return View(viewmodel);
        }
    }
}
