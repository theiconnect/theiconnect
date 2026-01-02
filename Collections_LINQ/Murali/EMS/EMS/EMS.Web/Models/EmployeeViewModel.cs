using EMS.Models.Enums;
using EMS.Web.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace EMS.Web.Models
{

    public class EmployeeViewModel
    {
        public EmployeeViewModel()
        { }
        public  EmployeeViewModel(int employeeIdPk, string employeecode, string firstName,string middleName, string lastName, BloodGroups bloodGroup, Genders gender, string emailId, string mobileNumber,string alternateMobileNumber, DateTime dateOfBirth, DateTime dateOfJoining, int expInMonths, decimal? salaryCtc, bool isActive, EmployeeAddressViewModel Addresses)
        {
            EmployeeIdPk = employeeIdPk;
            Employeecode = employeecode;
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
            SalaryCtc = salaryCtc;
            IsActive = isActive;
            Addresses = Addresses;
        }
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
       
        //1e=> 1dept+history dept
        //1d=> m employees
        public DateTime DateOfBirth { get; set; }
        public DateTime DateOfJoining { get; set; }
        public int ExpInMonths { get; set; } = 0;//default value will be zero
        public decimal? SalaryCtc { get; set; }
        public bool IsActive { get; set; } = true;

        public List<EmployeeAddressViewModel> Addresses = new List<EmployeeAddressViewModel>();








































        //public EmployeeViewModel(int employeeIdPk, string employeecode)
        //{
        //    Addresses = new List<EmployeeAddressViewModel>();
        //    EmployeeIdPk = employeeIdPk;
        //    Employeecode = employeecode;
        //}

        //public List<EmployeeAddressViewModel> Addresses { get; set; }

        //public EmployeeViewModel(
        //    int employeeIdPk,
        //    string employeeCode,
        //    string firstName,
        //    string lastName,
        //    BloodGroups bloodGroup,
        //    Genders gender,
        //    string emailId,
        //    string mobileNumber,
        //    DateTime dateOfBirth,
        //    DateTime dateOfJoining,
        //    int expInMonths,
        //    decimal? salaryCtc,
        //    bool isActive,
        //    List<EmployeeAddressViewModel> addresses
        //)
        //{
        //    EmployeeId = employeeIdPk;
        //    Code = employeeCode;
        //    FirstName = firstName;
        //    LastName = lastName;
        //    BloodGroup = bloodGroup;
        //    Gender = gender;
        //    EmailId = emailId;
        //    MobileNumber = mobileNumber;
        //    DateOfBirth = dateOfBirth;
        //    DateOfJoining = dateOfJoining;
        //    ExpInMonths = expInMonths;
        //    SalaryCtc = salaryCtc;
        //    IsActive = isActive;


        //    Addresses = addresses ?? new List<EmployeeAddressViewModel>();
        //}

        //public EmployeeViewModel(int employeeIdPk, string employeecode, string firstName, string lastName, BloodGroups bloodGroup, Genders gender, string emailId, string mobileNumber, DateTime dateOfBirth, DateTime dateOfJoining, int expInMonths, decimal? salaryCtc, bool isActive, object var)
        //{
        //    EmployeeIdPk = employeeIdPk;
        //    Employeecode = employeecode;
        //    FirstName = firstName;
        //    LastName = lastName;
        //    BloodGroup = bloodGroup;
        //    Gender = gender;
        //    EmailId = emailId;
        //    MobileNumber = mobileNumber;
        //    DateOfBirth = dateOfBirth;
        //    DateOfJoining = dateOfJoining;
        //    ExpInMonths = expInMonths;
        //    SalaryCtc = salaryCtc;
        //    IsActive = isActive;
        //}

        //public EmployeeViewModel()
        //{
        //}

        //public EmployeeViewModel(int employeeIdPk, string employeecode, string firstName, string lastName, BloodGroups bloodGroup, Genders gender, string emailId, string mobileNumber, DateTime dateOfBirth, DateTime dateOfJoining, int expInMonths, decimal? salaryCtc, bool isActive) : this(employeeIdPk, employeecode)
        //{
        //}

        //public int EmployeeId { get; set; }
        //public string Code { get; set; }
        //public string FirstName { get; set; }
        //public string LastName { get; set; }
        //public BloodGroups BloodGroup { get; set; }
        //public Genders Gender { get; set; }
        //public string EmailId { get; set; }
        //public string MobileNumber { get; set; }
        //public DateTime DateOfBirth { get; set; }
        //public DateTime DateOfJoining { get; set; }
        //public int ExpInMonths { get; set; }
        //public decimal? SalaryCtc { get; set; }
        //public bool IsActive { get; set; }
        //public int EmployeeIdPk { get; }
        //public string Employeecode { get; }

        //public EmployeeAddressModel PermanentAddress { get; set; }
        //public EmployeeAddressModel PresentAddress { get; set; }

    }
}

