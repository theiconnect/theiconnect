using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMS.DataAccess;
using EMS.Models;

namespace EMS.Services
{
    public class EmployeeServices
    {
        private EMSDbContext dbContext;

        public EmployeeServices()
        {
            dbContext = EMSDbContext.GetInstance();
        }   

        public List<EmployeeModel> GetAllEmployees()
        {
            List<EmployeeModel> employees = dbContext.Employees;
            return employees;
        }

    }
}
