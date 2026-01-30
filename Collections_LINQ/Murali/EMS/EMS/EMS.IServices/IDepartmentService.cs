using EMS.Models;

namespace EMS.IServices
{
    public interface IDepartmentService
    {

        List<DepartmentModel> GetAllDepartments();
       
        public bool ActivateDeactivateDepartment(int departmentId, bool isDeactivate, string userName, out string responseMessage);

        bool SaveDepartment(DepartmentModel inputDepartment, bool isNewDepartment, string userName, out string responseMessage);

        public List<DepartmentModel> GetAllDepartments(string deptName, string deptLocation);
    }
}
