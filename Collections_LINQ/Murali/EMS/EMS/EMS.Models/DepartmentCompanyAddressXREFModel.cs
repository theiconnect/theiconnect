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
        public int DepartmentCompanyAddressXREFIdPk { get; set; }
        public DepartmentModel DepartmentIdFk { get; set; }
        public CompanyAddressTypes CompanyAddressIdFk { get; set; }

        List<int> CompanyAddressTypes = new List<int>();
        List<int> DepartmentModel = new List<int>();
    }
}
