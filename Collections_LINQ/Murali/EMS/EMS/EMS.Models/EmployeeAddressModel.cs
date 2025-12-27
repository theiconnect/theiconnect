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

        public EmployeeAddressModel(int employeeAddressModelIdPk,string addressLine1, string addressLine2, string state, string city, string pincode, AddressTypes addressTypeId, bool _isActive)
        {
            EmployeeAddressModelIdPk = employeeAddressModelIdPk;
            AddressLine1 = addressLine1;
            AddressLine2 = addressLine2;
            State = state;
            City = city;
            Pincode = pincode;
            AddressTypeId = addressTypeId;
            isActive = _isActive;
        }

        public int EmployeeAddressModelIdPk {get;set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Pincode { get; set; }
        public AddressTypes AddressTypeId { get; set; }
        //public int EmployeeIdFk { get; set; }
        public bool isActive { get; set; } = true;
        public int EmployeeIdFk { get; set; }
        public AddressTypes AddressTypeIdFk { get; set; }
    }
}
