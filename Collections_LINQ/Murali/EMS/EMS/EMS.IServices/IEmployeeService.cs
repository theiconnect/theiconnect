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
        List<EmployeeModel> GetEmployeeDetails();
        //List<EmployeeAddressModel> GetAllEmployeeAddresses();
        //EmployeeModel GetEmployeeByID(int empId);
        bool ActivateDeactivateEmployee(int employeeId, bool isDeactivate, string userName, out string responseMessage);

     
        bool SaveEmployee(EmployeeModel inputEmployee,bool isNewEmployee, string userName, out string responseMessage);

    }
}
    

