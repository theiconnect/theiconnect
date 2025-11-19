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

        public string EmployeeCode  { get; set; }
        public string FirstName { get; set; }
        public string LastName  { get; set; }

        public string BloodGroup  { get; set; }


         public  string Gender { get; set; }
        public string EmailId  { get; set; }

        public string PersonalEmailId  { get; set; }
        public string MobileNumber  { get; set; }

        public string AlternateMobileNumber  { get; set; }

        public DepartmentModel DepartmentIdFk  { get; set; }

        public DateTime DateOfBirth  { get; set; }
        public DateTime DateOfJoining  { get; set; }

        public int ExpInMonths { get; set; }
        
        public QualificationLookUpModel QualificationIdFk { get; set; }
        public DesignationLookUpModel DesignationIdFk { get; set; }
        public decimal SalaryCTC { get; set; }
        public System.Boolean IsActive { get; set; }
        public DateTime ? LWD { get; set; }

        List<QualificationLookUpModel> Qualifications { get; set; }
        List<DepartmentModel> Departments { get; set; }

        List<DesignationLookUpModel> designationLookUpModels { get; set; }
        List<EmployeeAddressModel> EmployeeAddresses { get; set; }
        List<EmployeeDesignation> EmployeeDesignations { get; set; }
    }
}
