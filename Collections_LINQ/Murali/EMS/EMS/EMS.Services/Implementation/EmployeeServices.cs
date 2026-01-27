using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMS.IDataAccess;
using EMS.IServices;
using EMS.Models;

namespace EMS.Services.Implementation
{
    public class EmployeeServices : IEmployeeService
    {
        IEmployeeRepository EmployeeRepository;
        public EmployeeServices(IEmployeeRepository _obj)
        {
            EmployeeRepository = _obj;
        }
        public bool ActivateDeactivateEmployee(int employeeId, bool isDeactivate,string userName,  out string responseMessage)
        {
            if (isDeactivate)
            {
                return EmployeeRepository.ActivateDeactivateEmp(employeeId, true, userName, out responseMessage);

            }
            return EmployeeRepository.ActivateDeactivateEmp(employeeId, false, userName, out responseMessage);
        }

      

        public List<EmployeeAddressModel> GetAllEmployeeAddresses()
        {
            throw new NotImplementedException();
        }

        public List<EmployeeModel> GetAllEmployees()
        {
            return EmployeeRepository.GetEmployeeDetails();
        }

        public EmployeeModel GetEmployeeByID(int empId)
        {
            throw new NotImplementedException();
        }

        public bool SaveEmployee(EmployeeModel inputEmployee, bool isNewEmployee,string userName, out string responseMessage)
        {
            if (isNewEmployee)
            {
                return EmployeeRepository.SaveEmployee(inputEmployee, true, userName, out responseMessage);
            }
            return EmployeeRepository.SaveEmployee(inputEmployee, false,userName, out responseMessage);
        }

    }
}
