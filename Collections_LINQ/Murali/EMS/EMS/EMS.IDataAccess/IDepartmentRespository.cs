using EMS.Models;



namespace EMS.IDataAccess
{
    public interface IDepartmentRespository
    {
        List<DepartmentModel> GetAllDepartments();
       bool SaveDepartment(DepartmentModel inputDepartment, bool isNewDepartment, string userName, out string responseMessage);
        bool ActivateDeactivateDepartment(int departmentId, bool isDeactivate, string userName, out string responseMessage);
        List<DepartmentModel> GetAllDepartments(string deptName, string deptLocation);
    }
}
