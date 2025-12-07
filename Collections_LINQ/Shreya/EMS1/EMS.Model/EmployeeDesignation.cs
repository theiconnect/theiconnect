using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Model
{
    public class EmployeeDesignation
    {
        public int EmployeeDesignationIdPK {get; set; }
        public int DesignationIdFK { get; set; }
        public string EmployeeIdFk { get; set; }
        public DateTime EffectiveFrom { get; set; }
        public DateTime EndDate
        { get; set; }
    }
}
