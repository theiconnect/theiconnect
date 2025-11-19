using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Models
{
    public class DepartmentCompanyAddressModel
    {
        public int DepartmentCompanyAddressIdPk { get; set; }
        public  int CompanyAddressIdFk { get; set; }
        public int DepartmentIdFk { get; set; }
    }
}
