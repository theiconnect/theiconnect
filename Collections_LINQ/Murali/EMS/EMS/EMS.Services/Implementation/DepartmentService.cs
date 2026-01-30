using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMS.IDataAccess;
using EMS.IServices;
using EMS.Models;

namespace EMS.Services.Implementation
{
    public class DepartmentService : IDepartmentService
    {
        IDepartmentRepository DepartmentRepository;
        public DepartmentService(IDepartmentRepository _obj)
        {
            DepartmentRepository = _obj;
        }
        public bool ActivateDeactivateDepartment(int departmentId, bool isDeactivate, string userName, out string responseMessage)
        {
            if (isDeactivate)
            {
                return DepartmentRepository.ActivateDeactivateDepartment(departmentId, true, userName, out responseMessage);

            }
            return DepartmentRepository.ActivateDeactivateDepartment(departmentId, false, userName, out responseMessage);
        }

        public List<DepartmentModel> GetAllDepartments()
        {
            return DepartmentRepository.GetAllDepartments();
        }

        public List<DepartmentModel> GetAllDepartments(string deptName, string deptLocation)
        {
            return DepartmentRepository.GetAllDepartments(deptName,deptLocation);
        }

        public DepartmentModel GetDepartmentById(int departmentId)
        {
            return DepartmentRepository.GetDepartmentById(departmentId);
        }

        public bool SaveDepartment(DepartmentModel inputDepartment, bool isNewDepartment, string userName, out string responseMessage)
        {
            if (isNewDepartment)
            {
                return DepartmentRepository.SaveDepartment(inputDepartment, true, userName, out responseMessage);
            }
            return DepartmentRepository.SaveDepartment(inputDepartment, false, userName, out responseMessage);
        }
    }
}

