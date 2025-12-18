using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMS.DataAccess;
using EMS.Models;

namespace EMS.Services.Implementation.TD
{
    public class DepartmentTDService : IServices.IDepartmentService
    {
        EMSDbContext dbContext;
        public DepartmentTDService()
        {
            dbContext = EMSDbContext.GetInstance();
        }

        public List<DepartmentModel> GetAllDepartments()
        {
            List<DepartmentModel> departments = dbContext.Departments;
            return departments;
        }

        public bool ActivateDeactivateDepartment(int departmentId, bool isDeactivate, out string responseMessage)
        {
            responseMessage = "Success";
            var department = dbContext.Departments.FirstOrDefault(d => d.DepartmentIdPk == departmentId);

            if (department != null)
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
                    department.IsActive = false;
                }
                else
                {
                    department.IsActive = true;
                }
                return true;
            }

            responseMessage = "Department not found";
            return false;
        }
    }
}

