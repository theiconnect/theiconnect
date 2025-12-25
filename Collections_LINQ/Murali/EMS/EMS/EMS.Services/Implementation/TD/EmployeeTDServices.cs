using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using EMS.DataAccess;
using EMS.IServices;
using EMS.Models;


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

    }
}
