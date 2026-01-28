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

        List<EmployeeModel> GetAllEmployees();
        bool SaveEmployee(EmployeeModel employeeModel, bool v, out string responseMessage);


        bool SavenewEmployee(EmployeeModel employeeModel, bool v, out string responseMessage);
    }
}
