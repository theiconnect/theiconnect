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
        private ICompanyRepository companyrepo;
        public CompanyService(ICompanyRepository _obj)
        {
            companyrepo = _obj;
        }
        public CompanyModel GetCompany()
        {
            var company = companyrepo.GetCompanyDetails();
            return company;
        }
    }
}
