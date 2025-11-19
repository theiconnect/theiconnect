using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMS.Model.Enums;

namespace EMS.Model
{
    public class CompanyAddressModel
    {
        public int CompanyAddressIdPk { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string PinCode { get; set; }
        public CompanyAddressTypes AddressTypeIdFk { get; set; }

        public int CompanyIdFk { get; set; }

        List<DepartmentCompanyAddressModel> DepartmentCompanyAddresses { get; set; }
    }
}
