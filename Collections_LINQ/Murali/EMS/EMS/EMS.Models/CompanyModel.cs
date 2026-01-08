using System.Runtime.InteropServices;

namespace EMS.Models
{
    public class CompanyModel
    {
        public int CompanyIdPk { get; set; }
        public string CompanyName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public string Website { get; set; }
        public string BankAccountNumber { get; set; }
        public string TIN { get; set; }
        public string PAN { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string LastUpdatedBy { get; set; }
        public DateTime? LastUpdatedOn { get; set; }

        public List<CompanyAddressModel> Addresses { get; set; } = new List<CompanyAddressModel>();
        public List<DepartmentModel> Departments { get; set; }
    }
}