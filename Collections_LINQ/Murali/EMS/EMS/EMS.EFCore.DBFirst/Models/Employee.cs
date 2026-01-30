using System;
using System.Collections.Generic;

namespace EMS.EFCore.DBFirst.Models;

public partial class Employee
{
    public int EmployeeIdPk { get; set; }

    public string? EmployeeCode { get; set; }

    public string? FirstName { get; set; }

    public string? MiddleName { get; set; }

    public string? LastName { get; set; }

    public int? Bloodgroup { get; set; }

    public int? Gender { get; set; }

    public string? EmailId { get; set; }

    public string? PersonalEmailId { get; set; }

    public string? MobileNumber { get; set; }

    public string? AlternateMobileNumber { get; set; }

    public DateOnly? DateOfBirth { get; set; }

    public DateOnly? DateOfJoining { get; set; }

    public int? ExpInMonths { get; set; }

    public decimal? SalaryCtc { get; set; }

    public bool IsActive { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? LastUpdatedBy { get; set; }

    public DateTime? LastUpdatedOn { get; set; }
}
