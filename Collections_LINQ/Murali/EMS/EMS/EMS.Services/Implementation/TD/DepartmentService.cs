using EMS.IDataAccess;
using EMS.IServices;
using EMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Services.Implementation.TD
{
    public class DepartmentService:IDepartmentService
    {
        IDepartmentRepository departmentRepository;
        public DepartmentService(IDepartmentRepository repository)
        {
            departmentRepository = repository;
        }
        public List<DepartmentModel> GetAllDepartments()
        {
            List<DepartmentModel> model = departmentRepository.GetAllDepartments();
            return model;
        }

        public bool SaveDepartment(DepartmentModel inputDepartment, bool isNewDepartment, string userName, out string responseMessage)
        {
            return departmentRepository.SaveDepartment(inputDepartment,isNewDepartment, userName, out responseMessage
           );
        }
        public bool ActivateDeactivateDepartment(int departmentId, bool isDeactivate, string userName, out string responseMessage)
        {
            return departmentRepository.ActivateDeactivateDepartment(departmentId, isDeactivate, userName, out responseMessage
           );
        }

        public List<DepartmentModel> GetAllDepartments_QueryWithSearch(string deptName, string deptLocation)
        {
            return departmentRepository.GetAllDepartments_QueryWithSearch(deptName, deptLocation);
        }
        public List<DepartmentModel> GetAllDepartments(string deptName, string deptLocation)
        {
            return departmentRepository.GetAllDepartments(deptName, deptLocation);
        }
    }
}

