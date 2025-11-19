using EMS.DataAccess;
using EMS.Models;

namespace EMS.Services
{
    public class CompanyService
    {
        public void test()
        {
            EMSDbContext dbContext = new EMSDbContext();

           var companyInfo = dbContext.Company;
           var addresses=  dbContext.CompanyAddresses;
            var depts = dbContext.Departments;



        }
    }
}
