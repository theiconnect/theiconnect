using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Models
{
    public class DesignationLookupModel
    {
        public int EmployeeDesignationIdPk { get; set; }
        public int DesignationIdF { get; set; }
        public int EmployeeIdFk { get; set; }
        public string EffectiveFrom { get; set; }
        public string EndDate { get; set; }
    }
}
