using System;
using System.Collections.Generic;

namespace EMS.EFCore.DBFirst.Models;

public partial class EmployeeAddress
{
    public int EmployeeAddressIdPk { get; set; }

    public int EmployeeIdfk { get; set; }

    public int AddressTypeIdFk { get; set; }

    public string AddressLine1 { get; set; } = null!;

    public string? AddressLine2 { get; set; }

    public string City { get; set; } = null!;

    public string State { get; set; } = null!;

    public string? Pincode { get; set; }

    public bool IsActive { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? LastUpdatedBy { get; set; }

    public DateTime? LastUpdatedOn { get; set; }
}
