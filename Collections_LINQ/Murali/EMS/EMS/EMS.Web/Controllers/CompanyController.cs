using EMS.Models;
using EMS.Services.Implementation.ADO;
using EMS.Services.Implementation.TD;
using Microsoft.AspNetCore.Mvc;
using EMS.Services;




namespace EMS.Web.Controllers
{
    [Route("company")] 
    public class CompanyController : Controller
    {

        private CompanyService companyservice;
        public CompanyController(CompanyService _obj)
        {
            companyservice = _obj;
        }
        //[Route("edit")]
        public IActionResult EditCompany(int id)
        {
            var company = _companyADOService.GetCompany().FirstOrDefault(c => c.CompanyIdPk == id);
            return View();

        }
        private CompanyService CompanyService;
        public static string userName = "admin";

            object CompanyADOService = null;
            var company = CompanyADOService.GetCompany().FirstOrDefault(c => c.CompanyId == id);
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

