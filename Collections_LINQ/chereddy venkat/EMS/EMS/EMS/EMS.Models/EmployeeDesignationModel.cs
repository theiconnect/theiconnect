using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Models
{
    public class EmployeeDesignationModel
    {
        public int EmployeeDesignationIdPk { get; set; }
        public int DesignationIdFk { get; set; }
        public int EmployeeIdFk { get; set; }
        public DateTime EffectiveFrom { get; set; }
        public DateTime EndDate { get; set; }

    }
}
