
using EMS.Models;

namespace EMS.IServices
{
    public interface ICompanyService
    {
        CompanyModel GetCompanyDetails();
        bool DeleteCompanyAddress(int addressId);
        
    }

}
