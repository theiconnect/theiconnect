using EMS.IDataAccess;
using EMS.IServices;
using EMS.Models;
using EMS.Services.Implementation.TD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Services
{
    public class DepartmentService : IDepartmentService
    {
        IDepartmentRepository DepartmentRepository;
        public DepartmentService(IDepartmentRepository repository)
        {
            DepartmentRepository = repository;
        }
        public List<DepartmentModel> GetAllDepartments()
        {
            List<DepartmentModel> model = DepartmentRepository.GetAllDepartments();
            return model;
        }

        public bool SaveDepartment(DepartmentModel inputDepartment, bool isNewDepartment, string userName, out string responseMessage)
        {
            return DepartmentRepository.SaveDepartment(inputDepartment, isNewDepartment, userName, out responseMessage
            );
        }

        public bool ActivateDeactivateDepartment(int DepartmentId, bool isDeactivate, String userName, out string responseMessage)
        {
            return DepartmentRepository.ActivateDeactivateDepartment(DepartmentId, isDeactivate, userName, out responseMessage);
        }

        public List<DepartmentModel> GetAllDepartments_QueryWithSearch(string deptName, string deptLocation)
        {
          return DepartmentRepository.GetAllDepartments_QueryWithSearch(deptName, deptLocation);
        }

        public List<DepartmentModel> GetAllDepartments(string deptName, string deptLocation)
        {
            return DepartmentRepository.GetAllDepartments(deptName, deptLocation);
        }

    }
}

