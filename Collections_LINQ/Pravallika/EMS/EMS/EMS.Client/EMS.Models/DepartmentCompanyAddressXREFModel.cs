using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Models
{
    internal class DepartmentCompanyAddressXREFModel
    {
        public int DepartmentCompanyAddressXREFIdPK {  get; set; }
        public int DepartmentIdFK {  get; set; }
        public int  CompanyAddressIdFK { get; set; }
    }
}
