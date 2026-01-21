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
        private ICompanyRepository companyRepository;
        public CompanyService(ICompanyRepository repository)
        {
            companyRepository = repository;
        }

        public CompanyModel GetCompanyDetails()
        {
            CompanyModel model = companyRepository.GetCompanyDetails();
            return model;
        }

        public bool DeleteCompanyAddress(int addressId)
        {
            // Business rules can go here later
            return companyRepository.DeleteCompanyAddress(addressId);
        }
    }
}
