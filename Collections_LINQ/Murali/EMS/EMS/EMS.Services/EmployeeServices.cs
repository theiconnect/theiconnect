using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMS.DataAccess;

namespace EMS.Services
{
    public class EmployeeServices
    {
        EMSDbContext dbContext;

        public EmployeeServices()
        {
            dbContext = EMSDbContext.GetInstance();
        }   

        public List<Models.EmployeeModel> GetAllEmployees()
        {
            List<Models.EmployeeModel> employees = dbContext.Employees;
            return employees;
        }
    }
}
