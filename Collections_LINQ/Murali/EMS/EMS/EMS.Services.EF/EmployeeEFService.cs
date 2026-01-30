using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMS.EFCore.DBFirst.Models;
using EMS.IServices;
using EMS.Models;

namespace EMS.Services.EF
{
    public class EmployeeEFService : IEmployeeService
    {
        private EMSDbContext eMSDbContext;
        public EmployeeEFService(EMSDbContext dbContext)
        {
            eMSDbContext = dbContext;
        }

        public bool ActivateDeactivateEmployee(int EmployeeId, bool isDeactivate, string userName, out string responseMessage)
        {
            throw new NotImplementedException();
        }

        public List<EmployeeModel> GetAllEmployees()
        {
            throw new NotImplementedException();
        }

        public EmployeeModel GetEmployeeDetailsById(int EmployeeId)
        {
            throw new NotImplementedException();
        }

        public bool SaveEmployee(EmployeeModel inputEmployee, bool isNewEmployee, string userName, out string responseMessage)
        {
            throw new NotImplementedException();
        }
    }
}
