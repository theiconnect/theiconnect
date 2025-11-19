using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Models
{
    public class CompanyAddressModel
    {
        public int CompanyAddressIdPk { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Pincode { get; set; }
        public int AddressTypeIdFk { get; set; }

        List<int> CompanyAddressTypes = new List<int>();
    }
}
