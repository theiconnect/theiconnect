using EMS.Models;

namespace EMS.IServices
{
    public interface IDepartmentService
    {
        List<DepartmentModel> GetAllDepartments();
        List<DepartmentModel> GetAllDepartments(string deptName, string deptLocation);
        DepartmentModel GetDepartmentById(int departmentId);
        bool ActivateDeactivateDepartment(int departmentId, bool isDeactivate, string userName, out string responseMessage);
        bool SaveDepartment(DepartmentModel inputDepartment, bool isNewDepartment, string userName, out string responseMessage);
    }
}
