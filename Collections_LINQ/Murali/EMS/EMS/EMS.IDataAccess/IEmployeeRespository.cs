using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMS.Models;
using Microsoft.Data.SqlClient;

namespace EMS.IDataAccess
{
    public interface IEmployeeRepository
    {
        bool ActivateDeactivateEmployee(int employeeId, bool isDeactivate,string userNmae, out string errorMesssage);
        List<EmployeeModel> GetEmployeeDetails();
        //EmployeeModel GetEmployeeById(int employeeId);
        bool SaveEmployee(EmployeeModel employee, bool isNewEmployee, string userName, out string responseMessage);
    }
}
