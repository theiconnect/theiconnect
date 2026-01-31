using System;
using System.Collections.Generic;

namespace EMS.EFCore.DBFirst.Models;

public partial class BloodGroup
{
    public int BloodGroupIdPk { get; set; }

    public string BloodGroupName { get; set; } = null!;

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
