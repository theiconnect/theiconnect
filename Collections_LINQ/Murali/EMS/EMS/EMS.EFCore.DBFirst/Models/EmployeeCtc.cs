using System;
using System.Collections.Generic;

namespace EMS.EFCore.DBFirst.Models;

public partial class EmployeeCtc
{
    public int EmployeeCtcpk { get; set; }

    public int EmployeeIdFk { get; set; }

    public decimal SalaryCtc { get; set; }

    public DateTime EffectiveFrom { get; set; }

    public DateTime? EndDate { get; set; }

    public virtual Employee EmployeeIdFkNavigation { get; set; } = null!;
}
