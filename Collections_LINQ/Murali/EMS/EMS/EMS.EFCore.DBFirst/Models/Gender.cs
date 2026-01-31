using System;
using System.Collections.Generic;

namespace EMS.EFCore.DBFirst.Models;

public partial class Gender
{
    public int GenderIdPk { get; set; }

    public string GenderName { get; set; } = null!;

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
