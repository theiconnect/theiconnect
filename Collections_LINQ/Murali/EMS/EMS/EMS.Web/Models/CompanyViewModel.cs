namespace EMS.Web.Models
{
    public class CompanyViewModel
    {
        public int CompanyIdPk { get; set; }
        public string CompanyName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public string RegistrationDateDisplayValue
        {
            get
            {
                if (RegistrationDate.HasValue)
                {
                    return RegistrationDate.Value.ToString("dd-MMM-yyyy");
                }
                else
                {
                    return string.Empty;
                }
            }
        }
        public string Website { get; set; }
        public string BankAccountNumber { get; set; }
        public string TIN { get; set; }
        public string PAN { get; set; }

        public List<CompanyAddressViewModel> CompanyAddresses { get; set; } = new List<CompanyAddressViewModel>();
    }
}
