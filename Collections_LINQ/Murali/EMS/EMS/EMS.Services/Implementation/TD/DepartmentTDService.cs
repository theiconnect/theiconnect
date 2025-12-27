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

        public DepartmentModel GetDepartmentById(int departmentId)
        {
            DepartmentModel department = dbContext.Departments.Where(a => a.DepartmentIdPk == departmentId).FirstOrDefault();
            return department;
        }

        public bool SaveDepartment(DepartmentModel inputDepartment, bool isNewDepartment, out string responseMessage)
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

        public bool EditDepartmentSave(DepartmentModel departmentModel, out string responseMessage)
        {
            responseMessage = "Success";
            try
            {
                var existingDepartment = dbContext.Departments.FirstOrDefault(d => d.DepartmentIdPk == departmentModel.DepartmentIdPk);
                if (existingDepartment != null)
                {
                    existingDepartment.DepartmentCode = departmentModel.DepartmentCode;
                    existingDepartment.DepartmentName = departmentModel.DepartmentName;
                    existingDepartment.Location = departmentModel.Location;
                    existingDepartment.IsActive = departmentModel.IsActive;
                }
                else
                {
                    responseMessage = "Department not found";
                    return false;
                }
            }
            catch (Exception ex)
            {
                responseMessage = ex.Message;
                return false;
            }
            return true;

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

        private int GenerateNewDepartmentId()
        {
            if (dbContext.Departments.Count == 0)
                return 1;
            return dbContext.Departments.Max(d => d.DepartmentIdPk) + 1;
        }
    }
}

