using System.Runtime.InteropServices;

namespace EMS.Models
{
    public class CompanyModel 
    {
    public int CompanyIdPk { get; set; }
    public string CompanyName { get; set; }
    public int PhoneNumber { get; set; }
    public string Email { get; set; }
    public DateTime RegistrationDate { get; set; }
    public string Website { get; set; }
    public string BankAccountNumber { get; set; }
    public int TIN { get; set; }

}
}