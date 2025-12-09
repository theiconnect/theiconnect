using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Models
{
    public class EmployeeCTCModel
    {
        public int EmployeeCTCPK { get; set; }
        public int EmployeeIdFK { get; set; }
        public Decimal SalaryCTC { get; set; }
        public DateTime EffectiveForm { get; set; }
        public DateTime EndDate { get; set; }
    }
}
