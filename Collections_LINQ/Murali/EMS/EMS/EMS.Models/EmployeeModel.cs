using EMS.Models.Enums;

namespace EMS.Models
{
    public class EmployeeModel
    {
        public int EmployeeIdPk { get; set; }
        public string Employeecode { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public BloodGroups BloodGroup { get; set; }
        public Genders Gender { get; set; }
        public string EmailId { get; set; }
        public string PersonalEmailId { get; set; }
        public string MobileNumber { get; set; }
        public string AlternateMobileNumber { get; set; }
        public int DepartmentIdFk { get; set; } //Current department
        //1e=> 1dept+history dept
        //1d=> m employees
        public DateTime DateOfBirth { get; set; }
        public DateTime DateOfJoining { get; set; }
        public int ExpInMonths { get; set; } = 0;//default value will be zero
        public int? QualificationIdFk { get; set; }
        public DesiginationTypes DesignationIdFk { get; set; }
        public decimal? SalaryCtc { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime? LWD { get; set; }

        public List<EmployeeAddressModel> Addresses { get; set; } = new List<EmployeeAddressModel>();
        public List<EmployeeDesignationModel> Designations { get; set; } = new List<EmployeeDesignationModel>();
    }
}
