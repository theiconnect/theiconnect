using EMS.Models;
using EMS.Services;
using EMS.Services.Implementation;
//using EMS.Services.Implementation.EFCore;
using EMS.Services;
using EMS.Web.Models;
using Microsoft.AspNetCore.Mvc;
using EMS.Services;




namespace EMS.Web.Controllers
{


    [Route("Company")]
    public class CompanyController : Controller
    {

        private CompanyService companyservice;
        public CompanyController(CompanyService _obj)
        {
            companyservice = _obj;
        }
        //[Route("edit")]
        public IActionResult EditCompany()
        {
            return View();

        }
        private CompanyService CompanyService;
        public static string userName = "admin";

        //[Route("info")]
        //[Route("")]
        //[Route("view")]
        //[Route("details")]
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

        //[Route("list")]
        //public IActionResult CompanyList()
        //{
        //    // Replace with real data retrieval (repository/service) as needed.
        //    IEnumerable<CompanyModel> companies = Enumerable.Empty<CompanyModel>();
        //    return View(companies);
        //}

