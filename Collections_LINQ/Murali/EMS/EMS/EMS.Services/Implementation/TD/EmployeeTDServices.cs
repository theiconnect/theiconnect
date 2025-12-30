using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMS.DataAccess;
using EMS.Models;

namespace EMS.Services.Implementation.TD
{
    public class EmployeeTDServices : IServices.IEmployeeService
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
        public bool ActivateDeactivateEmployee(int EmployeeId, bool isDeactivate, out string responseMessage)
        {
            responseMessage = "Success";
            var employee = dbContext.Employees.FirstOrDefault(d => d.EmployeeIdPk == EmployeeId);

            if (employee != null)
            {
                //    employee.IsActive = !isDeactivate;
                //    return true;
                //}
                //else
                //{
                //    responseMessage = "Employee not found";
                //    return false;

                //}
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
             responseMessage = "Employee not found";
                return false; 
        }
       


    }
}



