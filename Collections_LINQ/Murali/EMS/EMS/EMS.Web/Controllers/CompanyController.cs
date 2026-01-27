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
        public static string userName = "admin";
        private ICompanyService companyservice;
        public CompanyController(ICompanyService _companyservice)
        {
            companyservice = _companyservice;
        }

        [Route("edit")]
        [Route("modify")]
        [HttpGet]
        public IActionResult EditCompany()
        {
            CompanyViewModel model = GetCompanyDetails();

            return View(model);
        }

        [Route("view")]
        [Route("details")]
        [Route("info")]
        [Route("")]
        [HttpGet]
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
                var addressViewModel = ConvertModelToViewModel(companyAddress);
                companyViewModel.CompanyAddresses.Add(addressViewModel);
            }
            return companyViewModel;
        }

        [HttpGet]
        [Route("deletecompanyaddress/{id}")]
        public JsonResult DeleteCompanAddress(int id)
        {
            bool isSuccess = companyservice.DeleteCompanyAddress(id, out string errorMessage);
            return Json(new { isSuccess = isSuccess, ErrorMessage = errorMessage });
        }

        [HttpPost]
        [Route("addcompanyaddress")]
        public JsonResult AddCompanAddress([FromBody]CompanyAddressViewModel addressViewModel)
        {
            var model = ConvertViewModelToModel(addressViewModel);

            bool isSuccess = companyservice.AddUpdateCompanyAddress(model, userName, out string errorMessage);
            return Json(new { isSuccess = isSuccess, ErrorMessage = errorMessage });
        }
        [HttpPost]
        [Route("edit")]
        public JsonResult SaveCompany([FromBody] CompanyViewModel companyViewModel)
        {
            try
            {
                var companyModel = new CompanyModel
                {
                    CompanyIdPk = companyViewModel.CompanyIdPk,
                    CompanyName = companyViewModel.CompanyName,
                    PhoneNumber = companyViewModel.PhoneNumber,
                    TIN = companyViewModel.TIN,
                    BankAccountNumber = companyViewModel.BankAccountNumber,
                    RegistrationDate = companyViewModel.RegistrationDate,
                    PAN = companyViewModel.PAN,
                    Website = companyViewModel.Website,
                    Email = companyViewModel.Email
                };

                string errorMsg;

                bool isSuccess = companyservice.SaveCompanyInfo(companyModel,"1",out errorMsg);

                return Json(new { isSuccess = true });
            }
            catch (Exception ex)
            {
                return Json(new { isSuccess = false, errorMessage = ex.Message });
            }
        }
        private CompanyAddressModel ConvertViewModelToModel(CompanyAddressViewModel ViewModel) 
        {
            CompanyAddressModel model = new CompanyAddressModel();
            model.AddressLine1 = ViewModel.AddressLine1;
            model.AddressLine2 = ViewModel.AddressLine2;
            model.City = ViewModel.City;
            model.State = ViewModel.State;
            model.Pincode = ViewModel.PinCode;
            model.AddressTypeIdFk = ViewModel.AddressTypeId;
            model.CompanyAddressIdPk = ViewModel.CompanyAddressIdPk;
            return model;
        }

        private CompanyAddressViewModel ConvertModelToViewModel(CompanyAddressModel model)
        {
            CompanyAddressViewModel ViewModel = new CompanyAddressViewModel();
            ViewModel.AddressLine1 = model.AddressLine1;
            ViewModel.AddressLine2 = model.AddressLine2;
            ViewModel.City = model.City;
            ViewModel.State = model.State;
            ViewModel.PinCode = model.Pincode;
            ViewModel.AddressTypeId = model.AddressTypeIdFk;
            ViewModel.AddressTypeName = model.AddressTypeName;
            ViewModel.CompanyAddressIdPk = model.CompanyAddressIdPk;
            return ViewModel;
        }
    }
}
