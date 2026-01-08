using EMS.Models;
using EMS.Services.Implementation.ADO;
using EMS.Services.Implementation.TD;
using Microsoft.AspNetCore.Mvc;
using EMS.Services;
using EMS.IServices;
using EMS.Web.Models;

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

            //var companymodel = new CompanyModel(){
            //    companymodel.CompanyName = companyDB.CompanyName,
            //    companymodel.PhoneNumber = companyDB.PhoneNumber,
            //    companymodel.BankAccountNumber = companyDB.BankAccountNumber,

            //};

            var ViewModel = new CompanyViewModel();
            ViewModel.CompanyIdPk = companyDB.CompanyIdPk;
            ViewModel.CompanyName = companyDB.CompanyName;
            ViewModel.PhoneNumber = companyDB.PhoneNumber;
            ViewModel.Email = companyDB.Email;
            ViewModel.RegistrationDate= companyDB.RegistrationDate;
            ViewModel.Website = companyDB.Website;
            ViewModel.BankAccountNumber = companyDB.BankAccountNumber;
            ViewModel.TIN = companyDB.TIN;
            ViewModel.PAN = companyDB.PAN;

            return View(ViewModel);
        }
    }
}
