using EMS.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace EMS.Web.Models
{
    public class EmployeeListViewModel
    {
        public EmployeeListViewModel()
        {
        }

        public EmployeeListViewModel(int employeeIdPk, string employeecode, string firstName, string middleName, string lastName, BloodGroups bloodGroup, Genders gender, string emailId, string mobileNumber, string alternateMobileNumber, DateTime dateOfBirth, DateTime dateOfJoining, int expInMonths, decimal? salaryCtc, bool isActive)
        {
            EmployeeId = employeeIdPk;
            Code = employeecode;
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
            BloodGroup = bloodGroup;
            Gender = gender;
            EmailId = emailId;
            MobileNumber = mobileNumber;
            AlternateMobileNumber = alternateMobileNumber;
            DateOfBirth = dateOfBirth;
            DateOfJoining = dateOfJoining;
            ExpInMonths = expInMonths;
            IsActive = isActive;
        }
        public int EmployeeId { get; set; }
        public string Code { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public BloodGroups BloodGroup { get; set; }

        [DisplayName("Gender")]
        public Genders Gender { get; set; }
        public string EmailId { get; set; }
        public string MobileNumber { get; set; }
        public string AlternateMobileNumber { get; set; }
        //1e=> 1dept+history dept
        //1d=> m employees
        public DateTime DateOfBirth { get; set; }

        [DisplayName("Date Of Joining")]
        public DateTime DateOfJoining { get; set; }

        [DisplayName("Experience (Months)")]
        public int ExpInMonths { get; set; } = 0;

        [DisplayName("Salary")]
        public decimal? SalaryCtc { get; set; }

        [DisplayName("Is Active")]
        public bool IsActive { get; set; } = true;

        public List<EmployeeAddressViewModel> Addresses { get; set; } = new List<EmployeeAddressViewModel>();
        public string AddressLine1 { get; }
        public string AddressLine2 { get; }
        public string State { get; }
        public string City { get; }
        public string Pincode { get; }
        public AddressTypes AddressTypeId { get; }
        public int EmployeeIdFk { get; }
        public bool IsActive1 { get; }
    }
}
//    public class EmployeeViewModel
//    {
//        internal object id;

//        public EmployeeViewModel()
//        {
//        }

//        public EmployeeViewModel(int employeeIdPk, string employeecode, string firstName, string middleName, string lastName, BloodGroups bloodGroup, Genders gender, string emailId, string mobileNumber, string alternateMobileNumber, DateTime dateOfBirth, DateTime dateOfJoining, int expInMonths, decimal? salaryCtc, bool isActive)
//        {
//            EmployeeId = employeeIdPk;
//            Code = employeecode;
//            FirstName = firstName;
//            MiddleName = middleName;
//            LastName = lastName;
//            BloodGroup = bloodGroup;
//            Gender = gender;
//            EmailId = emailId;
//            MobileNumber = mobileNumber;
//            AlternateMobileNumber = alternateMobileNumber;
//            DateOfBirth = dateOfBirth;
//            DateOfJoining = dateOfJoining;
//            ExpInMonths = expInMonths;
//            IsActive = isActive;
//        }
//        public int EmployeeId { get; set; }
//        public string Code { get; set; }
//        public string FirstName { get; set; }
//        public string MiddleName { get; set; }
//        public string LastName { get; set; }
//        public BloodGroups BloodGroup { get; set; }

//        [DisplayName("Gender")]
//        public Genders Gender { get; set; }
//        public string EmailId { get; set; }
//        public string MobileNumber { get; set; }
//        public string AlternateMobileNumber { get; set; }
//        //1e=> 1dept+history dept
//        //1d=> m employees
//        public DateTime DateOfBirth { get; set; }

//        [DisplayName("Date Of Joining")]
//        public DateTime DateOfJoining { get; set; }

//        [DisplayName("Experience (Months)")]
//        public int ExpInMonths { get; set; } = 0;

//        [DisplayName("Salary")]
//        public decimal? SalaryCtc { get; set; }

//        [DisplayName("Is Active")]
//        public bool IsActive { get; set; } = true;

//        public List<EmployeeAddressViewModel> Addresses { get; set; } = new List<EmployeeAddressViewModel>();
//    }
//}
