namespace EMS.Web.Models
{
    public class CompanyAddressViewModel
    {
        public CompanyAddressViewModel() { }
        public CompanyAddressViewModel(string _addressLine1, string _addressLine2, string _city, string _state, string _pinCode, string _country)
        {
            AddressLine1 = _addressLine1;
            AddressLine2 = _addressLine2;
            City = _city;
            State = _state;
            PinCode = _pinCode;
            Country = _country;
        }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PinCode { get; set; }
        public string Country { get; set; }
    }
}
