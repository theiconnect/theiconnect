using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using EMS.DataAccess;
using EMS.IServices;
using EMS.Models;
using EMS.IServices;


namespace EMS.Services.Implementation.TD
{
    public class EmployeeTDServices : IEmployeeService
    {
        private EMSDbContext dbContext;

        public EmployeeTDServices()
        {
            dbContext = EMSDbContext.GetInstance();
        }

        public List<EmployeeModel> GetAllEmployees()
        {
            List<EmployeeModel> employees = dbContext.Employees;

            return employees;
        }
        public List<EmployeeAddressViewModel> GetAllEmployeeAddresses()
        {
            List<EmployeeAddressViewModel> addresses = dbContext.EmployeeAddresses;

            return addresses;
        }

        public bool SaveEmployeedetails(EmployeeModel inputEmployee, bool isNewEmployee, out string responseMessage)
        {
            responseMessage = "Success";
            try
            {
                if (isNewEmployee)
                {
                    inputEmployee.EmployeeIdPk = GenerateNewEmpId();
                    dbContext.Employees.Add(inputEmployee);
                }
                else
                {
                    var existingEmployee = dbContext.Employees.FirstOrDefault(e => e.EmployeeIdPk == inputEmployee.EmployeeIdPk);
                    if (existingEmployee != null)
                    {
                        existingEmployee.Employeecode = inputEmployee.Employeecode;
                        existingEmployee.FirstName = inputEmployee.FirstName;
                        existingEmployee.MiddleName = inputEmployee.MiddleName;
                        existingEmployee.LastName = inputEmployee.LastName;
                        existingEmployee.BloodGroup = inputEmployee.BloodGroup;
                        existingEmployee.Gender = inputEmployee.Gender;
                        existingEmployee.EmailId = inputEmployee.EmailId;
                        existingEmployee.MobileNumber = inputEmployee.MobileNumber;
                        existingEmployee.AlternateMobileNumber = inputEmployee.AlternateMobileNumber;
                        existingEmployee.DateOfBirth = inputEmployee.DateOfBirth;
                        existingEmployee.DateOfJoining = inputEmployee.DateOfJoining;
                        existingEmployee.ExpInMonths = inputEmployee.ExpInMonths;
                        existingEmployee.SalaryCtc = inputEmployee.SalaryCtc;
                        existingEmployee.IsActive = inputEmployee.IsActive;
                    }
                    else
                    {
                        responseMessage = "Employee not found";
                        return false;
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                responseMessage = ex.Message;
                return false;
            }
        }

        private int GenerateNewEmpId()
        {
            if (dbContext.Employees.Count == 0)
                return 1;
            return dbContext.Employees.Max(e => e.EmployeeIdPk) + 1;
        }

    }
}
