using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMS.Models.Enums;

namespace EMS.Models
{
    public class CompanyAddressModel
    {
        public int CompanyAddressIdPK {  get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string PinCode { get; set; }
        public CompanyAddressTypes AddressTypeIdFK { get; set; }


    }
}
