using EMS.Models;
using EMS.Services.Implementation.ADO;
using EMS.Services.Implementation.TD;
using Microsoft.AspNetCore.Mvc;
using EMS.Services;
using EMS.IServices;
using EMS.Web.Models;
using EMS.Services.Implementation;

namespace EMS.Web.Controllers
{
    [Route("company")]
    public class CompanyController : Controller
    {
        private ICompanyService companyservice;
        public CompanyController(ICompanyService _companyservice)
        {
            companyservice = _companyservice;
        }

        [Route("edit")]
        [Route("modify")]
        public IActionResult EditCompany()
        {
            CompanyViewModel model = GetCompanyDetails();

            return View(model);
        }

        [Route("view")]
        [Route("details")]
        [Route("info")]
        [Route("")]
        public IActionResult ViewCompany()
        {
            CompanyViewModel model = GetCompanyDetails();

            return View(model);
        }

        private CompanyViewModel GetCompanyDetails()
        {
            CompanyModel companyDB = companyservice.GetCompanyDetails();

            var companyViewModel = new CompanyViewModel();
            companyViewModel.CompanyIdPk = companyDB.CompanyIdPk;
            companyViewModel.CompanyName = companyDB.CompanyName;
            companyViewModel.PhoneNumber = companyDB.PhoneNumber;
            companyViewModel.TIN = companyDB.TIN;
            companyViewModel.BankAccountNumber = companyDB.BankAccountNumber;
            companyViewModel.RegistrationDate = companyDB.RegistrationDate;
            companyViewModel.PAN = companyDB.PAN;
            companyViewModel.Website = companyDB.Website;
            companyViewModel.Email = companyDB.Email;
            foreach (var companyAddress in companyDB.Addresses)
            {
                var addressViewModel = new CompanyAddressViewModel();
                addressViewModel.AddressLine1 = companyAddress.AddressLine1;
                addressViewModel.AddressLine2 = companyAddress.AddressLine2;
                addressViewModel.City = companyAddress.City;
                addressViewModel.State = companyAddress.State;
                addressViewModel.PinCode = companyAddress.Pincode;
                addressViewModel.AddressTypeId = companyAddress.AddressTypeIdFk;
                addressViewModel.AddressTypeName = companyAddress.AddressTypeName;

                companyViewModel.CompanyAddresses.Add(addressViewModel);
            }
            return companyViewModel;
        }

        public IActionResult Addadress([FromBody] CompanyAddressViewModel student)
        {

            return View();
        }
    }
}
