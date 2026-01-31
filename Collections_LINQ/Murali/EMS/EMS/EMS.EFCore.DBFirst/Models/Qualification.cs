using System;
using System.Collections.Generic;

namespace EMS.EFCore.DBFirst.Models;

public partial class Qualification
{
    public int QualificationIdPk { get; set; }

    public string QualificationName { get; set; } = null!;

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
