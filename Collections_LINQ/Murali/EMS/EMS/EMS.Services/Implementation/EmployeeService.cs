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
        IEmployeeRepository EmployeeRepository;
        public EmployeeService(IEmployeeRepository repository)
        {
            EmployeeRepository = repository;
        }
        public List<EmployeeModel> GetAllEmployees()
        {
            List<EmployeeModel> model = EmployeeRepository.GetAllEmployees();
            return model;
        }
        public bool SaveEmployee(EmployeeModel inputEmployee, bool isNewEmployee, string userName, out string responseMessage)
        {
            return EmployeeRepository.SaveEmployee(inputEmployee, isNewEmployee, userName, out responseMessage
            );
        }
        public bool ActivateDeactivateEmployee(int EmployeeId, bool isDeactivate, String userName, out string responseMessage)
        {
            return EmployeeRepository.ActivateDeactivateEmployee(EmployeeId, isDeactivate, userName, out responseMessage);
        }

    }
}
