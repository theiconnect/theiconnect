using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMS.IDataAccess;
using EMS.IServices;
using EMS.Models;

namespace EMS.Services.Implementation.ADO
{
    public class CompanyServices : ICompanyService
    {
        private readonly ICompanyRepository ComService;
        public CompanyServices(ICompanyRepository _obj)
        {
            ComService = _obj;
        }

        public CompanyModel GetCompany()
        {
            var companyRepository = ComService.GetCompanyRepository();
            return companyRepository;
        }
    }
}
