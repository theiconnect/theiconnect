using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMS.Models;

namespace EMS.IDataAccess
{
    public interface IDepartmentRepository
    {
        List<DepartmentModel> GetAllDepartments();
        List<DepartmentModel> GetAllDepartments(string deptName, string deptLocation);
        DepartmentModel GetDepartmentById(int departmentId);
        bool ActivateDeactivateDepartment(int departmentId, bool isDeactivate, string userName, out string responseMessage);
        bool SaveDepartment(DepartmentModel inputDepartment, bool isNewDepartment, string userName, out string responseMessage);
    }
}
