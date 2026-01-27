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
        string errorMessage = string.Empty;

        public CompanyModel GetCompanyDetails()
        {
            CompanyModel model = companyRepository.GetCompanyDetails();
            return model;
        }
        public bool SaveCompanyInfo(CompanyModel companyModel, string userId, out string errorMessage)
        {
               
            return companyRepository.SaveCompanyInfo(companyModel, "1", out errorMessage);
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
