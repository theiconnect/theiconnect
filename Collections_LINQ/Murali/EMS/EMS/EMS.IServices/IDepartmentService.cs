using EMS.Models;

namespace EMS.IServices
{
    public interface IDepartmentService
    {
        List<DepartmentModel> GetAllDepartments();
        DepartmentModel GetDepartmentById(int departmentId);

        bool ActivateDeactivateDepartment(int departmentId, bool isDeactivate, out string responseMessage);
        bool SaveDepartment(DepartmentModel inputDepartment, bool isNewDepartment, out string responseMessage);
    }

}
