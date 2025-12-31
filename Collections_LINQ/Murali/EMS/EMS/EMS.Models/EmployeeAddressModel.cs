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

        public EmployeeAddressModel(int employeeAddressModelIdPk,string addressLine1, string addressLine2, string state, string city, string pincode, int addressTypeId, bool _isActive ,int _EmployeeIdFk )
        public EmployeeAddressModel(int employeeAddressModelIdPk,string addressLine1, string addressLine2, string state, string city, string pincode, AddressTypes addressTypeId, bool _isActive)
        {
            EmployeeAddressModelIdPk = employeeAddressModelIdPk;
            AddressLine1 = addressLine1;
            AddressLine2 = addressLine2;
            State = state;
            City = city;
            Pincode = pincode;
            AddressTypeId = addressTypeId;
            EmployeeIdFk = _EmployeeIdFk;
            isActive = _isActive;
        }

        public int EmployeeAddressModelIdPk {get;set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Pincode { get; set; }

        //public int EmployeeIdFk { get; set; }
        public bool isActive { get; set; } = true;
        public int EmployeeIdFk { get; set; } 
        public int AddressTypeId { get; set; }   // 1 = Permanent, 2 = Present
        //public string AddressTypeText { get; set; }
        //public int AddressTypeIdFk { get; set; }
       
    }
}
