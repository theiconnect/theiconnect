using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMS.DataAccess;
using EMS.IServices;
using EMS.Models;

namespace EMS.Services.Implementation.EFCore
{
    public class DepartmentEFCOREService : IDepartmentService
    {
        EMSDbContext dbContext;
        public DepartmentEFCOREService()
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

        public bool SaveDepartment(DepartmentModel inputDepartment, bool isNewDepartment, out string responseMessage)
        {
            throw new NotImplementedException();
        }
        public bool EditDepartmentSave(DepartmentModel departmentModel, out string responseMessage)
        {
            responseMessage = "Success";
            try
            {
                if (departmentModel == null)
                {
                    responseMessage = "Invalid department data";
                    return false;
                }
                else
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
            }
            catch (Exception ex)
            {
                responseMessage = ex.Message;
                return false;
            }
            return true;
        }
    }
}

