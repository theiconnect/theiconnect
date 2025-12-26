using EMS.IServices;
using EMS.Models;
using EMS.Services.Implementation.TD;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace EMS.Web.Controllers
{
    [Route("Company")]
    public class CompanyController : Controller
    {
        private readonly ICompanyService _companyService;
        public CompanyController(ICompanyService CompanyTDService)
        {
            _companyService = CompanyTDService;

        }

        [Route("edit")]
        public IActionResult EditCompany()
        {
            var CompanyFromDb = _companyService.GetCompany();
            var EditCompanyModel = new CompanyModel();

            var company = _companyService.GetCompany();
            var viewModel = new CompanyModel();
            viewModel.CompanyIdPk = company.CompanyIdPk;
            viewModel.CompanyName = company.CompanyName;
            viewModel.PhoneNumber = company.PhoneNumber;
            viewModel.Email = company.Email;
            viewModel.BankAccountNumber = company.BankAccountNumber;
            viewModel.RegistrationDate = company.RegistrationDate;
            viewModel.TIN = company.TIN; ;
            viewModel.PAN = company.PAN;
            viewModel.Website = company.Website;
            viewModel.Addresses = company.Addresses;



            return View(viewModel);
        }

        public IActionResult addAddressCompany([FromBody] CompanyAddressModel companyAddressModel)
        {
            var Model = new CompanyAddressModel();

            Model.AddressLine1 = companyAddressModel.AddressLine1;
            Model.AddressLine2 = companyAddressModel.AddressLine2;
            Model.City = companyAddressModel.City;
            Model.State = companyAddressModel.State;
            Model.Pincode = companyAddressModel.Pincode;

            bool isSuccess = _companyService.addAddressCompany(Model, true,out string responseMessage);

            return Json(new { success = isSuccess, message = responseMessage     });
        }

        //[Route("info")]
        //[Route("")]
        //[Route("view")]
       //[Route("details")]
       public  IActionResult ViewCompany() 
        {
            var company = _companyService.GetCompany();
            var viewModel = new CompanyModel();
            viewModel.CompanyIdPk = company.CompanyIdPk;
            viewModel.CompanyName = company.CompanyName;
            viewModel.PhoneNumber = company.PhoneNumber;
            viewModel.Email = company.Email;
            viewModel.BankAccountNumber = company.BankAccountNumber;
            viewModel.RegistrationDate = company.RegistrationDate;
            viewModel.TIN = company.TIN; ;
            viewModel.PAN = company.PAN;
            viewModel.Website = company.Website;
            viewModel.Addresses = company.Addresses;
            




            return View(viewModel);

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