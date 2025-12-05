using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Model
{
    public class DepartmentCompanyAddressModel
    {
        public int DepartmentCompanyAddressModelIdPk { get; set;  }
        public int DepartmentIdPk { get; set; }
        public int CompanyAddressIdFK
        { get; set; }

    }

}
