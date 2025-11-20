using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EMS.Models
{
    public class EmployeeModel
    {
        public int EmployeeIdPk { get; set; }
        public string EmployeeCode { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string BloodGroup { get; set; }
        public char Gender { get; set; }
        public string EmailId { get; set; }
        public string PersonalEmailId { get; set; }
        public string MobileNumber { get; set; }
        public string AlternateMobileNumber { get; set; }
        public DepartmentModel DepartmentIdFk { get; set; }
        public DateTime DOJ { get; set; }
        public int ExpInMonths { get; set; }
        public DateTime DOB { get; set; }
        public int QualificationIdFk { get; set; }
        public int DesignationIdFk { get; set; }
        public decimal SalaryCTC { get; set; }
        public System.Boolean IsActive { get; set; }
        public DateTime? LWD { get; set; }

       
        List<QualificationLookUpModel> Qualifications { get; set; } = new List<QualificationLookUpModel>();
        List<DepartmentModel> Departments { get; set; }

        List<DesignationLookUpModel> designationLookUpModels { get; set; }
        List<EmployeeAddressModel> EmployeeAddresses { get; set; }
    }
}
