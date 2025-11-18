using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Models
{
    public  class EmployeeDesignationModel
    {
        public int EmployeeDesignationIdPk { get; set; }
        public EmployeeModel EmployeeIdFk { get; set; }
        public DesignationLookupModel DesignationIdFk { get; set; }
        public DateTime EffectiveFrom { get; set; }
        public DateTime EndDate { get; set; }
    }
}
