using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Model
{
    public class DepartmentModel
    {
        public int DepartmentIdPk { get; set; }
        public string DepartmentCode { get; set; }
        public string DepartmentName { get; set; }
        public string Location { get; set; }
        public Boolean IsActive { get; set; }
        List<DepartmentCompanyAddressModel> DepartmentCompanyAddressModels { get; set; }

    }
}
