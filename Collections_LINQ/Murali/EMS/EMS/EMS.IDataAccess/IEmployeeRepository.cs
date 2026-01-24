using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMS.Models;

namespace EMS.IDataAccess
{
    public interface IEmployeeRepository
    {
        List<EmployeeModel> GetEmployeeDetails();
        bool AddUpdateEmployeeAddress(EmployeeModel Model, string UserId, out string errorMessage);
        bool DeleteEmployeeAddress(int id, out string errorMessage);

        

    }
}
