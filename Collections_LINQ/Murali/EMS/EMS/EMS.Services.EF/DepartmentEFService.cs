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
            var existingDepartment = eMSDbContext.Departments
                .FirstOrDefault(d => d.DepartmentIdPk == departmentId);
            if (existingDepartment == null){
                responseMessage = "Department not found.";
                return false;
            }
            existingDepartment.IsActive = !isDeactivate;
            existingDepartment.LastUpdatedBy = userName;
            existingDepartment.LastUpdatedOn = DateTime.Now;
            eMSDbContext.SaveChanges();
            responseMessage = isDeactivate ? "Department deactivated successfully." : "Department activated successfully.";
            return true;
        }

        public List<DepartmentModel> GetAllDepartments()
        {
            var dbDepartments = eMSDbContext.Departments.ToList();
            List<DepartmentModel> departmentModels = new List<DepartmentModel>();
            foreach (var dbDept in dbDepartments)
            {
                DepartmentModel model = new DepartmentModel();
                model.DepartmentIdPk = dbDept.DepartmentIdPk;
                model.DepartmentCode = dbDept.DepartmentCode;
                model.DepartmentName = dbDept.DepartmentName;
                model.Location = dbDept.DeptLocation;
                model.IsActive = dbDept.IsActive;
                departmentModels.Add(model);
            }
            return departmentModels;
        }

        public List<DepartmentModel> GetAllDepartments(string deptName, string deptLocation)
        {
            var query = eMSDbContext.Departments.AsQueryable();
            if (!string.IsNullOrEmpty(deptName))
            {
                query = query.Where(d => d.DepartmentName.Contains(deptName));
            }
            if (!string.IsNullOrEmpty(deptLocation))
            {
                query = query.Where(d => d.DeptLocation.Contains(deptLocation));
            }
            var dbDepartments = query.ToList();
            List<DepartmentModel> departmentModels = new List<DepartmentModel>();
            foreach (var dbDept in dbDepartments)
            {
                DepartmentModel model = new DepartmentModel();
                model.DepartmentIdPk = dbDept.DepartmentIdPk;
                model.DepartmentCode = dbDept.DepartmentCode;
                model.DepartmentName = dbDept.DepartmentName;
                model.Location = dbDept.DeptLocation;
                model.IsActive = dbDept.IsActive;
                departmentModels.Add(model);
            }
            return departmentModels;
        }

        public List<DepartmentModel> GetAllDepartments_QueryWithSearch(string deptName, string deptLocation)
        {
            throw new NotImplementedException();
        }

        public DepartmentModel GetDepartmentById(int departmentId)
        {
            var DbDepartment = eMSDbContext.Departments.FirstOrDefault(f => f.DepartmentIdPk == departmentId);
            DepartmentModel model = new DepartmentModel();
            model.DepartmentIdPk = DbDepartment.DepartmentIdPk;
            model.DepartmentCode = DbDepartment.DepartmentCode;
            model.DepartmentName = DbDepartment.DepartmentName;
            model.Location = DbDepartment.DeptLocation;
            model.IsActive = DbDepartment.IsActive;
            return model;
        }

        public bool SaveDepartment(DepartmentModel inputDepartment, bool isNewDepartment, string userName, out string responseMessage)
        {
            var existingDepartment = eMSDbContext.Departments
                .FirstOrDefault(d => d.DepartmentIdPk == inputDepartment.DepartmentIdPk);
            if (isNewDepartment)
            {
                if (existingDepartment != null)
                {
                    responseMessage = "Department with the same ID already exists.";
                    return false;
                }
                Department newDepartment = new Department
                {
                    DepartmentCode = inputDepartment.DepartmentCode,
                    DepartmentName = inputDepartment.DepartmentName,
                    DeptLocation = inputDepartment.Location,
                    CompanyIdFk = inputDepartment.CompanyIdFk,
                    IsActive = true,
                    CreatedBy = userName,
                    CreatedOn = DateTime.Now
                };
                eMSDbContext.Departments.Add(newDepartment);
                eMSDbContext.SaveChanges();
                responseMessage = "Department created successfully.";
                return true;
            }
            else
            {
                if (existingDepartment == null)
                {
                    responseMessage = "Department not found.";
                    return false;
                }
                existingDepartment.DepartmentCode = inputDepartment.DepartmentCode;
                existingDepartment.DepartmentName = inputDepartment.DepartmentName;
                existingDepartment.DeptLocation = inputDepartment.Location;
                existingDepartment.IsActive = inputDepartment.IsActive;
                existingDepartment.LastUpdatedBy = userName;
                existingDepartment.CompanyIdFk = inputDepartment.CompanyIdFk;
                existingDepartment.LastUpdatedOn = DateTime.Now;
                eMSDbContext.SaveChanges();
                responseMessage = "Department updated successfully.";
                return true;
            }
        }
    }
}
