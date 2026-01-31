using System;
using System.Collections.Generic;

namespace EMS.EFCore.DBFirst.Models;

public partial class Designation
{
    public int DesignationIdPk { get; set; }

    public string DesignationName { get; set; } = null!;

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
