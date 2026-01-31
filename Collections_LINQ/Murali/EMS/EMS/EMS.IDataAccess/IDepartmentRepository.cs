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
        List<DepartmentModel> GetAllDepartments();
        public List<DepartmentModel> GetAllDepartments_QueryWithSearch(string deptName, string deptLocation);
        
        public List<DepartmentModel> GetAllDepartments(string deptName, string deptLocation);

        public bool SaveDepartment(DepartmentModel inputDepartment, bool isNewDepartment, string userName, out string responseMessage);

        bool ActivateDeactivateDepartment(int departmentId, bool isDeactivate, string userName, out string responseMessage);
    }
}
