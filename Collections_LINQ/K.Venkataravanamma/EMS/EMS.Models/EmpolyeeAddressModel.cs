using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMS.Models.Enums;

namespace EMS.Models
{
    public class EmployeeAddressModel
    {
        public int CompanyAddressIdpk { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string state { get; set; }
        public string city { get; set; }
        public string pincode { get; set; }
        public EmployeeAddressTypes AddressTypeIdFk { get; set; }

    }
}
