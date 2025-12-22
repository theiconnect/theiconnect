using EMS.Models;

namespace EMS.IServices
{
    public interface IDepartmentService
    {
        List<DepartmentModel> GetAllDepartments();
        bool ActivateDeactivateDepartment(int departmentId, bool isDeactivate, out string responseMessage);
    }

}
