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
    public class EmployeeService : IEmployeeService
    {
        IEmployeeRepository employeeRepository;
        public EmployeeService(IEmployeeRepository repository)
        {
            employeeRepository = repository;
        }
        public List<EmployeeModel> GetAllEmployees()
        {
            List<EmployeeModel> model = employeeRepository.GetAllEmployees();
            return model;
        }

        public EmployeeModel GetEmployeeDetailsById(int EmployeeId)
        {
            return employeeRepository.GetEmployeeDetailsById(EmployeeId);
        }

        public bool SaveEmployee(EmployeeModel inputEmployee, bool isNewEmployee, string userName, out string responseMessage)
        {
            return employeeRepository.SaveEmployee(inputEmployee, isNewEmployee, userName, out responseMessage
            );
        }
        public bool ActivateDeactivateEmployee(int EmployeeId, bool isDeactivate, String userName, out string responseMessage)
        {
            return employeeRepository.ActivateDeactivateEmployee(EmployeeId, isDeactivate, userName, out responseMessage);
        }

    }
}
