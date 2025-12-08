using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Models
{
    public class DepartmentCompanyAddressXREFModel
    {
        public int DepartmentCompanyAddressXREFIdpk { get; set; }
        public int DepartmentIdFK { get; set; }
        public int CompanyAddressIdFK { get; set; }

        
    }
}
