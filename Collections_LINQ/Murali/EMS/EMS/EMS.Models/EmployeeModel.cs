using EMS.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Models
{
    public class EmployeeModel
    {
        public int EmployeeIdPk { get; set; }
        public string Employeecode { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string BloodGroup { get; set; }
        public Gender Gender { get; set; }
        public string EmailId { get; set; }
        public string PersonEmailId { get; set; }
        public string MobileNumber { get; set; }
        public string AlternateMobileNumber { get; set; }
        public int DepartmentIdFk { get; set; } 
        public DateTime DateOfBirth { get; set; }
        public DateTime DateOfJoining { get; set; }
        public int ExpInMonths { get; set; }
        public QualificationLookupModel QualificationIdFk { get; set; }
        public DesignationLookupModel DesignationIdFk { get; set; }
        public decimal SalaryCtc { get; set; }
        public Boolean IsActive { get; set; }
        public DateTime LWD { get; set; }
        List<int> DepartmentModel = new List<int>();



    }
}
