using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMS.IDataAccess;
using EMS.Models;

namespace EMS.IDataAccess
{
    public interface IEmployeeRepository
    {
        List<EmployeeModel> GetAllEmployees();
        public bool SaveEmployee(EmployeeModel inputEmployee, bool isNewEmployee, string userName, out string responseMessage);
        public bool ActivateDeactivateEmployee(int EmployeeId, bool isDeactivate, String userName, out string responseMessage);
    }
}
