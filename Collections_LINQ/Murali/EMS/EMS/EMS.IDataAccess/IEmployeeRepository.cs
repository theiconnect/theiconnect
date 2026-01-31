using EMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.IDataAccess
{
    public interface IEmployeeRepository
    {
        List<EmployeeModel> GetEmployeeDetails();
        public bool SaveEmployee(EmployeeModel inputEmployee, bool isNewEmployee, string userName, out string responseMessage);

        bool ActivateDeactivateEmployee(int employeeId, bool isDeactivate, string userName,out string responseMessage);


    }
}
