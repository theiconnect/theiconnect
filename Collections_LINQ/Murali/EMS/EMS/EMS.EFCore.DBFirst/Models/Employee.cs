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

    public int? BloodGroupIdFk { get; set; }

    public int? GenderIdFk { get; set; }

    public string? EmailId { get; set; }

    public string? PersonalEmailId { get; set; }

    public string? MobileNumber { get; set; }

    public string? AlternateMobileNumber { get; set; }

    public int? DepartmentIdFk { get; set; }

    public DateOnly? DateOfBirth { get; set; }

    public DateOnly? DateOfJoining { get; set; }

    public int? ExpInMonths { get; set; }

    public int? QualificationIdFk { get; set; }

    public int? DesignationIdFk { get; set; }

    public decimal? SalaryCtc { get; set; }

    public bool? IsActive { get; set; }

    public DateOnly? Lwd { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime? CreatedOn { get; set; }

    public string? LastUpdatedBy { get; set; }

    public DateTime? LastUpdatedOn { get; set; }

    public virtual BloodGroup? BloodGroupIdFkNavigation { get; set; }

    public virtual Department? DepartmentIdFkNavigation { get; set; }

    public virtual Designation? DesignationIdFkNavigation { get; set; }

    public virtual ICollection<EmployeeCtc> EmployeeCtcs { get; set; } = new List<EmployeeCtc>();

    public virtual Gender? GenderIdFkNavigation { get; set; }

    public virtual Qualification? QualificationIdFkNavigation { get; set; }
}
