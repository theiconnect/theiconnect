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
        public int EmployeeAddressIdPk {get;set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Pincode { get; set; }
        public bool isActive { get; set; } = true;
        public int EmployeeIdFk { get; set; } 
        public AddressTypes AddressTypeIdFk { get; set; }   // 1 = Permanent, 2 = Present
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string LastUpdatedBy { get; set; }
        public DateTime? LastUpdatedOn { get; set; }
    }
}
