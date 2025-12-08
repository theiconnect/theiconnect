using EMS.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Models
{
    public class DepartmentCompanyAddressXREFModel
    {
        public int DepartmentCompanyAddressIdPK { get; set; }
        public int DepartmentIdFk { get; set; }
        public int CompanyAddressIdFk { get; set; }
    }
}
