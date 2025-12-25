using EMS.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace EMS.Models {
    public class EmployeeViewModel
    {
        public EmployeeViewModel()
        {}

        public EmployeeViewModel(int employeeIdPk, string employeecode, string? firstName, string? lastName, BloodGroups bloodGroup, Genders gender, string? emailId, string? mobileNumber, DateTime dateOfBirth, DateTime dateOfJoining, int expInMonths,decimal? salary,bool isActive)
        {
            EmployeeIdPK = employeeIdPk;
            Employeecode = employeecode;
            FirstName = firstName;
            LastName = lastName;
            BloodGroup = bloodGroup;
            Gender = gender;
            EmailId = emailId;
            MobileNumber = mobileNumber;
            DateOfBirth = dateOfBirth;
            DateOfJoining = dateOfJoining;
            ExpInMonths = expInMonths;
            SalaryCtc = salary;
            IsActive = isActive;
        }

        public EmployeeViewModel(int employeeIdPk, string employeecode, string? firstName, string? lastName, BloodGroups bloodGroup, Genders gender, string? emailId, string? mobileNumber, DateTime dateOfBirth, DateTime dateOfJoining, int expInMonths, decimal? salary, bool isActive, string addressLine1, string addressLine2, string state, string city, string pincode, AddressTypes addressTypeId, int employeeIdFk, bool isActive1) : this(employeeIdPk, employeecode, firstName, lastName, bloodGroup, gender, emailId, mobileNumber, dateOfBirth, dateOfJoining, expInMonths, salary, isActive)
        {
            AddressLine1 = addressLine1;
            AddressLine2 = addressLine2;
            State = state;
            City = city;
            Pincode = pincode;
            AddressTypeId = addressTypeId;
            EmployeeIdFk = employeeIdFk;
            IsActive1 = isActive1;
        }

        [DisplayName("Employee Id")]
        public int EmployeeIdPK { get; set; }

        [DisplayName("Employee Code")]
        public string? Employeecode { get; set; }

        [DisplayName("First Name")]
        public string? FirstName { get; set; }

        [DisplayName("Last Name")]
        public string? LastName { get; set; }

        [DisplayName("Blood Group")]
        public BloodGroups BloodGroup { get; set; }

        [DisplayName("Gender")]
        public Genders Gender { get; set; }

        [DisplayName("Email Id")]
        public string? EmailId { get; set; }

        [DisplayName("Mobile Number")]
        public string? MobileNumber { get; set; }

        [DisplayName("Date Of Birth")]
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
