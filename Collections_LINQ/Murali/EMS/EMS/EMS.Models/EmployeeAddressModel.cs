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
        public int EmployeeAddressModelIdPk {get;set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Pincode { get; set; }
        public AddressTypes AddressTypeIdFk { get; set; }
        public int EmployeeIdFk { get; set; }
        public bool isActive { get; set; } = true;

    }
}
