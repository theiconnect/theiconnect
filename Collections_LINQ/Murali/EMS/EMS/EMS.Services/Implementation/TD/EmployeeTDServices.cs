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

        public List<EmployeeAddressModel> GetAllEmployeeAddresses()
        {
            List<EmployeeAddressModel> addresses = dbContext.EmployeeAddresses;
            return addresses;
        }

    }
}
