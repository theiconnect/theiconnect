using System;
using System.Collections.Generic;

namespace EMS.EFCore.DBFirst.Models;

public partial class Company
{
    public int CompanyIdPk { get; set; }

    public string? CompanyName { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Email { get; set; }

    public DateTime? RegistrationDate { get; set; }

    public string? Website { get; set; }

    public string? BankAccountNumber { get; set; }

    public string? Tin { get; set; }

    public string? Pan { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? LastUpdatedBy { get; set; }

    public DateTime? LastUpdatedOn { get; set; }

    public virtual ICollection<CompanyAddress> CompanyAddresses { get; set; } = new List<CompanyAddress>();
}
