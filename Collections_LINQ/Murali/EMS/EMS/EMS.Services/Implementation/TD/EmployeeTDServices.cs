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
           
                return false;
            }
        }
        public bool ActivateDeactivateEmployeee(int employeeId, bool isDeactivate, out string responseMessage)
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
            return dbContext.Employees.FirstOrDefault(e => e.EmployeeIdPk == empId);
        }




        //public List<EmployeeAddressViewModel> GetAllEmployeeAddresses()
        //{
        //    List<EmployeeAddressViewModel> addresses = dbContext.EmployeeAddresses;

            responseMessage = "Employee not found";
            return false;
        }


        private int GenerateNewEmpId()
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
            throw new NotImplementedException();
        }

        public bool ActivateDeactivatEmployee(object id, bool isDeactivate, out string responseMessage)
        {
            throw new NotImplementedException();
        }
        //    return addresses;
    }

        public bool ActivateDeactivateEmployee(int employeeId, bool isDeactivate, out string responseMessage)
        {
            throw new NotImplementedException();
        }

        public bool ActivateDeactivatEmployee(object id, bool isDeactivate, out string responseMessage)
        {
            throw new NotImplementedException();
        }
    }
