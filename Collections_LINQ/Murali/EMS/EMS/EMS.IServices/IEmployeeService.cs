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
        List<EmployeeAddressViewModel> GetAllEmployeeAddresses();

    }

}
    

