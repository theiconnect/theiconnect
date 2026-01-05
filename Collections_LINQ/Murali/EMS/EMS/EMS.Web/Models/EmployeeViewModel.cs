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
        {
        }

        public int EmployeeId { get; set; }
        public string Code { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public BloodGroups? BloodGroup { get; set; }
        public Genders Gender { get; set; }
        public string? EmailId { get; set; }
        public string? MobileNumber { get; set; }
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
    }
}

