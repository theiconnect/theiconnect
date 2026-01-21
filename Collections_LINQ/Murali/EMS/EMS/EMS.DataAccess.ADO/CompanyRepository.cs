using EMS.IDataAccess;
using EMS.Models;

namespace EMS.DataAccess
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly ICompanyRepository _companyRepository;
        public CompanyRepository(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public CompanyModel Getcompanydetails()
        {
            throw new NotImplementedException();
        }
    }
}
