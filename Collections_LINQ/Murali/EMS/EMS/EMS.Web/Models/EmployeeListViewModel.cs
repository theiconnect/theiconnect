using EMS.Models.Enums;

namespace EMS.Web.Models
{   
    public class EmployeeListViewModel
    { 
        public string Code { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public BloodGroups BloodGroup { get; set; }
        public Genders Gender { get; set; }
        public string EmailId { get; set; }
        public string PersonEmailId { get; set; }
        public string MobileNumber { get; set; }
        public string AlternateMobileNumber { get; set; }
        //1e=> 1dept+history dept
        //1d=> m employees
        public DateTime DateOfBirth { get; set; }
        public DateTime DateOfJoining { get; set; }
        public int ExpInMonths { get; set; } = 0;//default value will be zero
        public decimal? Salary { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
