using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Models
{
    internal class EmployeeModel
    {
        public int EmployeeIdPk { get; set; }
        public string Employeecode { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string BloodGroup { get; set; }
        public char Gender { get; set; }
        public string EmailId { get; set; }
        public string PersonalEmailId { get; set; }
        public int ManagerIdFk { get; set; }
        public string MobileNumber { get; set; }
        public string AlternateMobileNumber { get; set; }
        public int DeptIdFk { get; set; }
        public DateTime DOJ { get; set; }
        public int ExpInMonths { get; set; }
        public DateTime DOB { get; set; }
        public int QualificationIdFk { get; set; }
        public int DesignationIdFk { get; set; }
        public decimal SalaryCTC { get; set; }
        public bool IsActive { get; set; }
        public DateTime LWD { get; set; }


    }
}
