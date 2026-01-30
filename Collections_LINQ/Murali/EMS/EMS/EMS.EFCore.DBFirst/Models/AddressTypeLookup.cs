using System;
using System.Collections.Generic;

namespace EMS.EFCore.DBFirst.Models;

public partial class AddressTypeLookup
{
    public int AddressTypeIdPk { get; set; }

    public string AddressTypeCode { get; set; } = null!;

    public string AddressTypeDescription { get; set; } = null!;
}
