using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Models
{
    public class EmployeeCTC
    {
        public int EmployeeCTCPk { get; set; }
        public int EmployeeIdFk { get; set; }
        public string SalaryCTC { get; set; }
        public DateTime EffectiveFrom { get; set; }
        public DateTime Enddate { get; set; }

    }
}
