using EMS.IDataAccess;
using EMS.IServices;
using EMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Services.Implementation
{
    public class EmployeeService:IEmployeeService
    {
        private IEmployeeRepository employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        public List<EmployeeModel> GetAllEmployees()
        {
            return employeeRepository.GetAllEmployees();
            
        }

        public bool SaveEmployee(EmployeeModel employeeModel, bool v, out string responseMessage)
        {
            return employeeRepository.SaveEmployee(employeeModel, v, out responseMessage);
        }

        public bool SavenewEmployee(EmployeeModel employeeModel, bool v, out string responseMessage)
        {
            return employeeRepository.SavenewEmployee(employeeModel, v, out responseMessage);
        }
    }
}
