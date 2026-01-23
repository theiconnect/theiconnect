using EMS.Models;
using System;
using EMS.Models.Enums;
using EMS.IServices;

namespace EMS.IServices
{
    public interface ICompanyService
    {
        CompanyModel GetCompanyDetails();
        bool SaveCompany(CompanyModel company);
        bool DeleteCompany();
    }
}
