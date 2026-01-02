using EMS.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Models
{
    public  class EmployeeAddressModel
    {
        public EmployeeAddressModel() { }

        public EmployeeAddressModel(int employeeAddressIdPk,string addressLine1, string addressLine2, string state, string city, string pincode, AddressTypes addressTypeId, bool _isActive, int _EmployeeIdFk)
        {
            EmployeeAddressIdPk = employeeAddressIdPk;
            AddressLine1 = addressLine1;
            AddressLine2 = addressLine2;
            State = state;
            City = city;
            Pincode = pincode;
            AddressTypeIdFk = addressTypeId;
            EmployeeIdFk = _EmployeeIdFk;
            isActive = _isActive;
        }

        public int EmployeeAddressIdPk {get;set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Pincode { get; set; }
        public bool isActive { get; set; } = true;
        public int EmployeeIdFk { get; set; } 
        public AddressTypes AddressTypeIdFk { get; set; }   // 1 = Permanent, 2 = Present
    }
}
