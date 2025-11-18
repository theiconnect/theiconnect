namespace EMS.Models
{
    public class Company
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string CompanyDescription { get; set; }
        public string CompanyPhoneNumber { get; set; }
        public string CompanyEmail { get; set; }
        public DateTime CompanyRegistrationDate { get; set; }
        public string CompanyWebsite { get; set; }
        public string CompanyBankAccountNumber { get; set; }
    }
}
