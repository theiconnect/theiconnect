using EMS.Models;
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
        public DepartmentModel DepartmentIdFk { get; set; }
        public CompanyAddressModel CompanyAddressIdFk { get; set; }



    }
}
