using System;
using System.Collections.Generic;
using System.ComponentModel;
using EMS.Models;
using EMS.Models.Enums;

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
        public Genders Gender { get; set; }
        public string EmailId { get; set; }
        public string PersonalEmailId { get; set; }
        public string MobileNumber { get; set; }
        public string AlternateMobileNumber { get; set; }
        public int DepartmentIdFk { get; set; } //Current department
        //1e=> 1dept+history dept
        //1d=> m employees
        public DateTime? DateOfBirth { get; set; }
        public DateTime? DateOfJoining { get; set; }
        public int ExpInMonths { get; set; } = 0;//default value will be zero
        public int? QualificationIdFk { get; set; }
        public DesiginationTypes DesignationIdFk { get; set; }
        public decimal? SalaryCtc { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime? LWD { get; set; }

        public List<EmployeeAddressViewModel> Addresses { get; set; } = new List<EmployeeAddressViewModel>();
        public List<EmployeeDesignationModel> Designations { get; set; } = new List<EmployeeDesignationModel>();
    }
}
