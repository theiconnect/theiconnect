using EMS.Models.Enums;
using System.ComponentModel;

namespace EMS.Web.Models
{
    public class EmployeeAddressViewModel
    {
        public EmployeeAddressViewModel() { }
        public EmployeeAddressViewModel(int _EmployeeAddressModelId, string? _AddressLine1, string? _AddressLine2, string? _State, string? _City, string _Pincode, AddressTypes _AddressTypeIdFk, int _EmployeeIdFk, bool _IsActive)
        {
            EmployeeAddressModelId = _EmployeeAddressModelId;
            AddressLine1 = _AddressLine1;
            AddressLine2 = _AddressLine2;
            State = _State;
            City = _City;
            Pincode = _Pincode;
            AddressTypeIdFk = _AddressTypeIdFk;            
            EmployeeIdFk = _EmployeeIdFk;
            IsActive = _IsActive;

        }
        [DisplayName("Address Id")]
        public int EmployeeAddressModelId { get; set; }
        [DisplayName("AddressLine1")]
        public string? AddressLine1 { get; set; }
        [DisplayName("AddressLine2")]
        public string? AddressLine2 { get; set; }
        [DisplayName("state")]
        public string? State { get; set; }
        [DisplayName("City")]
        public string? City { get; set; }
        [DisplayName("PinCode")]
        public string? Pincode { get; set; }
        [DisplayName("Type")]
        public AddressTypes AddressTypeIdFk { get; set; }
        [DisplayName("IsActive")]
        public int EmployeeIdFk { get; set; }
        public bool IsActive { get; set; } = true;
        


    }
}
