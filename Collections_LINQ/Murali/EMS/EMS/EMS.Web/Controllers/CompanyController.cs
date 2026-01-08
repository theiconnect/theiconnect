using EMS.Models;
using EMS.Services.Implementation.ADO;
using EMS.Services.Implementation.TD;
using Microsoft.AspNetCore.Mvc;
using EMS.Services;
using EMS.IServices;

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

        public IActionResult ViewCompany()
        {
            var companyDB = companyservice.GetCompany();

            //var companymodel = new CompanyModel(){
            //    companymodel.CompanyName = companyDB.CompanyName,
            //    companymodel.PhoneNumber = companyDB.PhoneNumber,
            //    companymodel.BankAccountNumber = companyDB.BankAccountNumber,

            //};

            var companymodel = new CompanyModel();
            companymodel.CompanyIdPk = companyDB.CompanyIdPk;
            companymodel.CompanyName = companyDB.CompanyName;
            companymodel.PhoneNumber = companyDB.PhoneNumber;
            companymodel.TIN = companyDB.TIN;
            companymodel.BankAccountNumber = companyDB.BankAccountNumber;
            companymodel.RegistrationDate = companyDB.RegistrationDate;
            companymodel.PAN = companyDB.PAN;
            companymodel.Website = companyDB.Website;
            companymodel.Email = companyDB.Email;

            return View(companymodel);
        }
    }
}
