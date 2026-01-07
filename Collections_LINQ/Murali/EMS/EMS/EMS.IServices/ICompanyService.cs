
using EMS.Models;

namespace EMS.IServices
{
    public interface ICompanyService
    {
        CompanyModel GetCompany();
        List<CompanyModel> GetAllCompanies();
    }

}
