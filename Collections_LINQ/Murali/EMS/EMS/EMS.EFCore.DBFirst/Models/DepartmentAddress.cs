using System;
using System.Collections.Generic;

namespace EMS.EFCore.DBFirst.Models;

public partial class DepartmentAddress
{
    public int DepartmentAddressIdPk { get; set; }

    public string AddressLine1 { get; set; } = null!;

    public string? AddressLine2 { get; set; }

    public string State { get; set; } = null!;

    public string City { get; set; } = null!;

    public string PinCode { get; set; } = null!;

    public int AddressTypeIdFk { get; set; }

    public virtual AddressTypeLookup AddressTypeIdFkNavigation { get; set; } = null!;
}
