using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMS.DataAccess;
using EMS.Models;

namespace EMS.Services
{
    public class DepartmentService
    {
        EMSDbContext dbContext;
        public DepartmentService()
        {
            dbContext = EMSDbContext.GetInstance();
        }

        public List<DepartmentModel> GetAllDepartments()
        {
            List<DepartmentModel> departments = dbContext.Departments;
            return departments;
        }
    }
}
