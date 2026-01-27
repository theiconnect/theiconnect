using EMS.Models;

namespace EMS.IDataAccess
{
    public interface ICompanyRepository
    {
        CompanyModel GetCompanyDetails();
        bool AddUpdateCompanyAddress(CompanyAddressModel addressModel, string UserId, out string errorMessage);
        bool SaveCompanyInfo(CompanyModel companyModel, string userId, out string errorMessage);
        bool DeleteCompanyAddress(int id, out string errorMessage);
    }
}
