using EMS.EFCore.DBFirst.Models;
using EMS.IServices;
using EMS.Models;

namespace EMS.Services.EF
{
    public class CompanyEFService : ICompanyService
    {
        private EMSDbContext eMSDbContext;
        public CompanyEFService(EMSDbContext dbContext)
        {
            eMSDbContext = dbContext;
        }

        public bool AddUpdateCompanyAddress(CompanyAddressModel addressModel, string userId, out string errorMessage)
        {
            throw new NotImplementedException();
        }

        public bool DeleteCompanyAddress(int id, out string errorMessage)
        {
            throw new NotImplementedException();
        }

        public CompanyModel GetCompanyDetails()
        {
            throw new NotImplementedException();
        }
    }
}
