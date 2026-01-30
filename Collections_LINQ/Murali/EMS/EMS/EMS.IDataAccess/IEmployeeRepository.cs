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
        EmployeeModel GetEmployeeDetailsById(int EmployeeId);
        bool SaveEmployee(EmployeeModel inputEmployee, bool isNewEmployee, string userName, out string responseMessage);
        bool ActivateDeactivateEmployee(int EmployeeId, bool isDeactivate, String userName, out string responseMessage);
    }
}
