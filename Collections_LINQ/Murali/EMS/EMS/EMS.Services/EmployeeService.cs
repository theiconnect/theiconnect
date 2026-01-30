using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using EMS.IDataAccess;
using EMS.IServices;
using EMS.Models;
using Intuit.Ipp.Data;


namespace EMS.Services.Implementation
{
    public class EmployeeService : IEmployeeService
    {
        IEmployeeRepository employeeRepository;
        public EmployeeService(IEmployeeRepository repository)
        {
            employeeRepository = repository;
        }


        public List<EmployeeModel> GetEmployeeDetails()
        {
            List<EmployeeModel> model = employeeRepository.GetEmployeeDetails();
            return model;
        }
        public bool ActivateDeactivateEmployee(int employeeId, bool isDeactivate, string userName, out string responseMessage)
        {
           
            return employeeRepository.ActivateDeactivateEmployee(employeeId, isDeactivate,userName,out responseMessage);

        }

        public bool SaveEmployee(EmployeeModel inputEmployee, bool isNewEmployee, string userName, out string responseMessage)
        {
            
           return employeeRepository.SaveEmployee(inputEmployee, isNewEmployee, userName, out responseMessage);
        }
    }
}




    

