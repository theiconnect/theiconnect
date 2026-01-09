using EMS.Models.Enums;

namespace EMS.Web.Models
{
    public class CompanyAddressViewModel
    {
        public int CompanyAddressIdPk { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PinCode { get; set; }
        public AddressTypes AddressTypeId { get; set; }
        public string AddressTypeName { get; set; }
    }
}
