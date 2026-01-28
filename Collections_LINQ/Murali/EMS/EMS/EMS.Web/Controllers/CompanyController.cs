using EMS.Models;
using EMS.Services.Implementation.TD;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace EMS.Web.Controllers
{

   
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
          

        [Route("view")]
        [Route("details")]
        [Route("info")]
        [Route("")]
        [HttpGet]
        public IActionResult ViewCompany()
        {
            CompanyViewModel model = GetCompanyDetails();



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