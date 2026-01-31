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
        
        public List<DepartmentModel> GetAllDepartments(string deptName, string deptLocation)
        {
            List<DepartmentModel> departments = dbContext.Departments
                .Where(d => string.IsNullOrEmpty(deptName) || d.DepartmentName.ToLower().Contains(deptName.ToLower()))
                .Where(d => string.IsNullOrEmpty(deptLocation) || d.Location.ToLower().Contains(deptLocation.ToLower()))
                .ToList();
            return departments;
        }

        public DepartmentModel GetDepartmentById(int departmentId)
        {
            DepartmentModel department = dbContext.Departments.Where(a => a.DepartmentIdPk == departmentId).FirstOrDefault();
            return department;
        }

        public bool SaveDepartment(DepartmentModel inputDepartment, bool isNewDepartment, string userName, out string responseMessage)
        {
            responseMessage = "Success";
            try
            {
                if (isNewDepartment)
                {
                    inputDepartment.DepartmentIdPk = GenerateNewDepartmentId();
                    dbContext.Departments.Add(inputDepartment);
                }
                else
                {
                    var existingDepartment = dbContext.Departments.FirstOrDefault(d => d.DepartmentIdPk == inputDepartment.DepartmentIdPk);
                    if (existingDepartment != null)
                    {
                        existingDepartment.DepartmentCode = inputDepartment.DepartmentCode;
                        existingDepartment.DepartmentName = inputDepartment.DepartmentName;
                        existingDepartment.Location = inputDepartment.Location;
                        existingDepartment.IsActive = inputDepartment.IsActive;
                    }
                    else
                    {
                        responseMessage = "Department not found";
                        return false;
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                responseMessage = ex.Message;
                return false;
            }
        }

        public bool ActivateDeactivateDepartment(int departmentId, bool isDeactivate, string userName, out string responseMessage)
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

        private int GenerateNewDepartmentId()
        {
            if (dbContext.Departments.Count == 0)
                return 1;
            return dbContext.Departments.Max(d => d.DepartmentIdPk) + 1;
        }

        public List<DepartmentModel> GetAllDepartments_QueryWithSearch(string deptName, string deptLocation)
        {
            throw new NotImplementedException();
        }
    }
}

