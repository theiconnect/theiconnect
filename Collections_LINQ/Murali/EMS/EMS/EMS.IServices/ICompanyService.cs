
using EMS.Models;

namespace EMS.IServices
{
    public interface ICompanyService
    {
        CompanyModel GetCompanyDetails();
        bool AddUpdateCompanyAddress(CompanyAddressModel addressModel, string userId, out string errorMessage);
        bool DeleteCompanyAddress(int id, out string errorMessage);

    }

}
