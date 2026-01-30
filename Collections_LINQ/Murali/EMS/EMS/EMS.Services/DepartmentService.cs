using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using EMS.IDataAccess;
using EMS.IServices;
using EMS.Models;

namespace EMS.Services
{
    public class DepartmentService : IDepartmentService
    {
        IDepartmentRespository departmentRepository;
        public DepartmentService(IDepartmentRespository repository)
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
            return departmentRepository.SaveDepartment(inputDepartment, isNewDepartment, userName, out responseMessage);
        }
        public bool ActivateDeactivateDepartment(int departmentId, bool isDeactivate, string userName, out string responseMessage)
        {
            return departmentRepository.ActivateDeactivateDepartment(departmentId, isDeactivate, userName, out responseMessage);
        }
        public List<DepartmentModel> GetAllDepartments(string deptName, string deptLocation)
        {
            return departmentRepository.GetAllDepartments(deptName, deptLocation);
        }
    }
}
