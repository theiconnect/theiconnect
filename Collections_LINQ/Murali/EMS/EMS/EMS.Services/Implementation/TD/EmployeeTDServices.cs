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

        //public List<EmployeeAddressModel> GetAllEmployeeAddresses()
        //{
        //    throw new NotImplementedException();
        //}

        public List<EmployeeModel> GetAllEmployees()
        {
            List<EmployeeModel> employees = dbContext.Employees;

            return employees;
        }

        public EmployeeModel GetEmployeeByID(int empId)
        {
            return null;
        }

        public bool SaveEmployee(EmployeeModel inputEmployee, bool isNewEmployee,out string responseMessage)
        {
            responseMessage = "Success";

            try
            {
                var existingEmployee = dbContext.Employees
                    .FirstOrDefault(e => e.EmployeeIdPk == inputEmployee.EmployeeIdPk);

                if (existingEmployee == null)
                {
                    responseMessage = "Employee not found";
                    return false;
                }

                // Update fields
                existingEmployee.Employeecode = inputEmployee.Employeecode;
                existingEmployee.FirstName = inputEmployee.FirstName;
                existingEmployee.LastName = inputEmployee.LastName;
                existingEmployee.BloodGroup = inputEmployee.BloodGroup;
                existingEmployee.Gender = inputEmployee.Gender;
                existingEmployee.EmailId = inputEmployee.EmailId;
                existingEmployee.MobileNumber = inputEmployee.MobileNumber;
                existingEmployee.DateOfBirth = inputEmployee.DateOfBirth;
                existingEmployee.DateOfJoining = inputEmployee.DateOfJoining;
                existingEmployee.ExpInMonths = inputEmployee.ExpInMonths;
                existingEmployee.SalaryCtc = inputEmployee.SalaryCtc;
                existingEmployee.IsActive = inputEmployee.IsActive;

                dbContext.SaveChanges(); // ✅ MUST

                return true;
            }
            catch (Exception ex)
            {
                responseMessage = ex.Message;
                return false;
            }
        }

        public bool ActivateDeactivateEmployeee(int employeeId, bool isDeactivate, out string responseMessage)
        {
            if (dbContext.Employees.Count == 0)
                return 1;
            return dbContext.Employees.Max(e => e.EmployeeIdPk) + 1;
        }

        public List<EmployeeAddressModel> GetAllEmployeeAddresses()
        {
            throw new NotImplementedException();
        }

        public bool ActivateDeactivateEmployee(int employeeId, bool isDeactivate, out string responseMessage)
        {
            responseMessage = "Success";
            var employee = dbContext.Employees.FirstOrDefault(e => e.EmployeeIdPk == employeeId);

            if (employee != null)
            {
                //if (isDeactivate)
                //{
                //    if(dbContext.Employees.Any(e => e.DepartmentIdFk == departmentId && e.IsActive))
                //    {

                //        responseMessage = "Unable to delete department due to Active employees exists in this deapartment!";
                //        return false;
                //    }
                //}
                //department.IsActive = !isDeactivate;

                if (isDeactivate)
                {
                    employee.IsActive = false;
                }
                else
                {
                    employee.IsActive = true;
                }
                return true;
            }
            return false;
           
        }

    }
}

        public bool ActivateDeactivateEmployee(int employeeId, bool isDeactivate, out string responseMessage)
        {
            throw new NotImplementedException();
        }

        public bool SaveDepartment(EmployeeModel inputEmployee, bool isNewEmployee, string userName, out string responseMessage)
        {
            throw new NotImplementedException();
        }

        public bool SaveEmployee(EmployeeModel inputEmployee, bool isNewEmployee, string userName, out string responseMessage)
        {
            throw new NotImplementedException();
        }
    }
}
