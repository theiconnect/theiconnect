using EMS.Models;

namespace EMS.IDataAccess
{
    public interface ICompanyRepository
    {
        CompanyModel GetCompanyDetails();
    }
}
