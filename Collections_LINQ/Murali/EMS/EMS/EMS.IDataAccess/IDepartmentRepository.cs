using EMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.IDataAccess
{
    public interface IDepartmentRepository
    {
        bool ActivateDeactivateDepartment(int departmentId, bool isDeactivate, string userName, out string responseMessage);
        List<DepartmentModel> GetAllDepartments();
        DepartmentModel GetDepartmentById(int departmentId);

        bool SaveDepartment(DepartmentModel inputDepartment, bool isNewDepartment, string userName, out string responseMessage);
    }
}
