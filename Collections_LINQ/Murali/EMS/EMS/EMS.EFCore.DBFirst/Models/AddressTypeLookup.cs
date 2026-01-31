using System;
using System.Collections.Generic;

namespace EMS.EFCore.DBFirst.Models;

public partial class AddressTypeLookup
{
    public int AddressTypeIdPk { get; set; }

    public string AddressTypeCode { get; set; } = null!;

    public string AddressTypeDescription { get; set; } = null!;

    public virtual ICollection<CompanyAddress> CompanyAddresses { get; set; } = new List<CompanyAddress>();

    public virtual ICollection<DepartmentAddress> DepartmentAddresses { get; set; } = new List<DepartmentAddress>();

    public virtual ICollection<EmployeeAddress> EmployeeAddresses { get; set; } = new List<EmployeeAddress>();
}
