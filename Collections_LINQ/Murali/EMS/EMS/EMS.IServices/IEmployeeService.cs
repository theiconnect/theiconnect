using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMS.Models;


namespace EMS.IServices
{
    public  interface IEmployeeService
    {
        List<EmployeeModel> GetAllEmployees();
        List<EmployeeAddressModel> GetAllEmployeeAddresses();
        EmployeeModel GetEmployeeByID(int empId);
        bool ActivateDeactivateEmployee(int employeeId, bool isDeactivate, out string responseMessage);
        bool SaveEmployee(EmployeeModel inputEmployee,bool isNewEmployee,out string responseMessage);

    }
}
    

