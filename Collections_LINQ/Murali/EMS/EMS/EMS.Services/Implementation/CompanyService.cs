using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMS.IServices;
using EMS.Models;

namespace EMS.Services.Implementation
{
    public class CompanyService : ICompanyService
    {
        public List<CompanyModel> GetAllCompanies()
        {
            throw new NotImplementedException();
        }

        public CompanyModel GetCompany()
        {
            throw new NotImplementedException();
        }

        public bool AddUpdateCompanyAddress(CompanyAddressModel addressModel, string UserId, out string errorMessage)
        {
            return companyRepository.AddUpdateCompanyAddress(addressModel, UserId, out errorMessage);
        }
        public bool DeleteCompanyAddress(int id, out string errorMessage)
        {
            return companyRepository.DeleteCompanyAddress(id, out errorMessage);
        }
    }
}
