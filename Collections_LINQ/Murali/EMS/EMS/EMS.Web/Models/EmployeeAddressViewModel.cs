namespace EMS.Web.Models
{
    public class EmployeeAddressViewModel
    {
       
            public EmployeeAddressViewModel() { }
            public EmployeeAddressViewModel(string? _AddressLine1, string? _AddressLine2, string? _State, string? _City, string _Pincode, AddressTypes _AddressTypeIdFk, int _EmployeeIdFk, bool _IsActive, string _AddressTypeText)
            {

                AddressLine1 = _AddressLine1;
                AddressLine2 = _AddressLine2;
                State = _State;
                City = _City;
                Pincode = _Pincode;
                AddressTypeIdFk = _AddressTypeIdFk;
                EmployeeIdFk = _EmployeeIdFk;
                IsActive = _IsActive;
            

            }


            public string? AddressLine1 { get; set; }

            public string? AddressLine2 { get; set; }

            public string? State { get; set; }

            public string? City { get; set; }

            public string? Pincode { get; set; }

            public AddressTypes AddressTypeIdFk { get; set; }

            public int EmployeeIdFk { get; set; }
            public bool IsActive { get; set; } = true;



        }
    }


