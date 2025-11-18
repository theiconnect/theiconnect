using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Model
{
    public class EmployeeAddressModel
    {
        public int EmployeeAddressIdPk { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string PinCode { get; set; }
        public EmployeeAddressTypeModel AddressTypeIdFk { get; set; }

        List<EmployeeAddressModel> Employees { get; set; }
    }
}
