using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMS.IDataAccess;
using EMS.IServices;
using EMS.Models;

namespace EMS.Services.Implementation
{
    public class CompanyService : ICompanyService
    {
        ICompanyRepository companyRepository;
        public CompanyService(ICompanyRepository repository)
        {
            companyRepository = repository;
        }

        public bool DeleteCompany()
        {
            throw new NotImplementedException();
        }

        public CompanyModel GetCompanyDetails()
        {
            CompanyModel model = companyRepository.GetCompanyDetails();
            return model;
        }

        public bool SaveCompany(CompanyModel company)
        {
            throw new NotImplementedException();
        }
    }
}
