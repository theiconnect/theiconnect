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
    public class DepartmentEFService : IDepartmentService
    {
        private EMSDbContext eMSDbContext;
        public DepartmentEFService(EMSDbContext dbContext)
        {
            eMSDbContext = dbContext;
        }

        public bool ActivateDeactivateDepartment(int departmentId, bool isDeactivate, string userName, out string responseMessage)
        {
            throw new NotImplementedException();
        }

        public List<DepartmentModel> GetAllDepartments()
        {
            throw new NotImplementedException();
        }

        public List<DepartmentModel> GetAllDepartments(string deptName, string deptLocation)
        {
            throw new NotImplementedException();
        }

        public List<DepartmentModel> GetAllDepartments_QueryWithSearch(string deptName, string deptLocation)
        {
            throw new NotImplementedException();
        }

        public DepartmentModel GetDepartmentById(int departmentId)
        {
            throw new NotImplementedException();
        }

        public bool SaveDepartment(DepartmentModel inputDepartment, bool isNewDepartment, string userName, out string responseMessage)
        {
            throw new NotImplementedException();
        }
    }
}
