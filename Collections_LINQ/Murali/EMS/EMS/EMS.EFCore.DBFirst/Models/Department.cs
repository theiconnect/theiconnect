using System;
using System.Collections.Generic;

namespace EMS.EFCore.DBFirst.Models;

public partial class Department
{
    public int DepartmentIdPk { get; set; }

    public string DepartmentCode { get; set; } = null!;

    public string DepartmentName { get; set; } = null!;

    public string? DeptLocation { get; set; }

    public bool IsActive { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime? CreatedOn { get; set; }

    public string? LastUpdatedBy { get; set; }

    public DateTime? LastUpdatedOn { get; set; }
}
