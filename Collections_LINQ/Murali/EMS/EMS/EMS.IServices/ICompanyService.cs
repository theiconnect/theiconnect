using EMS.Models;
using System;
using EMS.Models.Enums;
using EMS.IServices;

namespace EMS.IServices
{
    public interface ICompanyService
    {
        CompanyModel GetCompanyDetails();
        bool DeleteCompany();
    }
}

public class CompanyService : ICompanyService
{
    public CompanyModel GetCompanyDetails()
    {
        CompanyModel company = new CompanyModel();
        return company;
    }

    public bool DeleteCompany()
    {
     
        throw new NotImplementedException();
    }
}
