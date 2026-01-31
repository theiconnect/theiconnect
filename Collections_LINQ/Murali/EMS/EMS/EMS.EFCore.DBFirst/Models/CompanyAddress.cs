using System;
using System.Collections.Generic;

namespace EMS.EFCore.DBFirst.Models;

public partial class CompanyAddress
{
    public int CompanyAddressIdPk { get; set; }

    public string AddressLine1 { get; set; } = null!;

    public string? AddressLine2 { get; set; }

    public string? City { get; set; }

    public string? State { get; set; }

    public string? PinCode { get; set; }

    public int CompanyIdFk { get; set; }

    public int AddressTypeIdFk { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime? CreatedOn { get; set; }

    public string? LastUpdatedBy { get; set; }

    public DateTime? LastUpdatedOn { get; set; }

    public virtual AddressTypeLookup AddressTypeIdFkNavigation { get; set; } = null!;

    public virtual Company CompanyIdFkNavigation { get; set; } = null!;
}
