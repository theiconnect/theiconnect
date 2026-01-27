using EMS.IServices;
using EMS.Models;
using EMS.Services;
using EMS.Services.Implementation;
using EMS.Services.Implementation.ADO;
using EMS.Services.Implementation.TD;
using EMS.Web.Models;
using Humanizer;
using Microsoft.AspNetCore.Mvc;

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
        [HttpPost]
        public IActionResult SaveCompany(CompanyViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { isSuccess = false, errorMessage = "Invalid data" });
            }

            CompanyModel companyModel = new CompanyModel
            {
                CompanyIdPk = model.CompanyIdPk,
                CompanyName = model.CompanyName,
                PhoneNumber = model.PhoneNumber,
                TIN = model.TIN,
                BankAccountNumber = model.BankAccountNumber,
                RegistrationDate = model.RegistrationDate,
                PAN = model.PAN,
                Website = model.Website,
                Email = model.Email,
                Addresses = new List<CompanyAddressModel>()
            };
            

            return Json(new { isSuccess = true });
        }
        public IActionResult EditCompany(CompanyViewModel model)
        {
            if (ModelState.IsValid)
            {
                
                CompanyModel companyModel = new CompanyModel
                {
                    CompanyIdPk = model.CompanyIdPk,
                    CompanyName = model.CompanyName,
                    PhoneNumber = model.PhoneNumber,
                    TIN = model.TIN,
                    BankAccountNumber = model.BankAccountNumber,
                    RegistrationDate = model.RegistrationDate,
                    PAN = model.PAN,
                    Website = model.Website,
                    Email = model.Email,
                    Addresses = new List<CompanyAddressModel>()
                };

                foreach (var addressViewModel in model.CompanyAddresses)
                {
                    var addressModel = new CompanyAddressModel
                    {
                        AddressLine1 = addressViewModel.AddressLine1,
                        AddressLine2 = addressViewModel.AddressLine2,
                        City = addressViewModel.City,
                        State = addressViewModel.State,
                        Pincode = addressViewModel.PinCode,
                        AddressTypeIdFk = addressViewModel.AddressTypeId
                    };
                    companyModel.Addresses.Add(addressModel);
                }
                
                return RedirectToAction("ViewCompany");
            }
            return View(model);
        }
        [HttpPost]
        [Route("delete")]
        public IActionResult DeleteCompany()
        {
            var result = companyservice.DeleteCompany();

            return RedirectToAction("ViewCompany");
        }
    }
}


