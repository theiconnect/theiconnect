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
        EmployeeModel GetEmployeeByID(int empId);


        //List<EmployeeAddressModel> GetAllEmployeeAddresses();

        //bool SaveEmployeedetails(EmployeeViewModel inputEmployee, bool isNewEmployee, out string responseMessage);
        //bool SaveEmployeedetails(EMS.Web.Models.EmployeeListViewModel empModel, bool v, out string responseMessage);
    }

}
    

