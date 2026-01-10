using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMS.IDataAccess;
using EMS.IServices;
using EMS.Models;
using EMS.DataAccess.ADO;
using Microsoft.IdentityModel.Tokens;

namespace EMS.Services.Implementation
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;

        public CompanyService(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }
        public List<CompanyModel> GetAllCompanies()
        {
            throw new NotImplementedException();
        }

        public CompanyModel GetCompany()
        {
            var company = _companyRepository.GetCompany();
            return company;
        }
    }
}
