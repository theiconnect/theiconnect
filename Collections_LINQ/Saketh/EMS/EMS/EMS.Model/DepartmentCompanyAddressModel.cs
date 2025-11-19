using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Model
{
    public class DepartmentCompanyAddressModel
    {
        public int DepartmentCompanyAddressXREFIDPk { get; set; }
        public int DepartmentIdFk { get; set; }
        public int CompanyAddressIdFk { get; set; }
    }
}
