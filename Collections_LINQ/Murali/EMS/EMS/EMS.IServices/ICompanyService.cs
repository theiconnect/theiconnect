
using EMS.Models;

namespace EMS.IServices
{
    public interface ICompanyService
    {
        CompanyModel GetCompany();
        bool addAddressCompany(CompanyAddressModel companyAddressModel, bool isPrimary, out String responseMessage);

    }
   

}
