using EMS.Models;
using EMS.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Mono.TextTemplating;

namespace EMS.Web.Models
{   
    public class EmployeeViewModel
    {
        public EmployeeViewModel()
        {
            Addresses = new List<EmployeeAddressModel>();
        }

        public List<EmployeeAddressModel> Addresses { get; set; }

        public EmployeeViewModel(
            int employeeIdPk,
            string employeeCode,
            string firstName,
            string lastName,
            BloodGroups bloodGroup,
            Genders gender,
            string emailId,
            string mobileNumber,
            DateTime dateOfBirth,
            DateTime dateOfJoining,
            int expInMonths,
            decimal? salaryCtc,
            bool isActive,
            List<EmployeeAddressModel> addresses
        )
        {
            EmployeeId = employeeIdPk;
            Code = employeeCode;
            FirstName = firstName;
            LastName = lastName;
            BloodGroup = bloodGroup;
            Gender = gender;
            EmailId = emailId;
            MobileNumber = mobileNumber;
            DateOfBirth = dateOfBirth;
            DateOfJoining = dateOfJoining;
            ExpInMonths = expInMonths;
            SalaryCtc = salaryCtc;
            IsActive = isActive;


            Addresses = addresses ?? new List<EmployeeAddressModel>();
        }

        public int EmployeeId { get; set; }
        public string Code { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public BloodGroups BloodGroup { get; set; }
        public Genders Gender { get; set; }
        public string EmailId { get; set; }
        public string MobileNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateOfJoining { get; set; }
        public int ExpInMonths { get; set; }
        public decimal? SalaryCtc { get; set; }
        public bool IsActive { get; set; }
    }
}


