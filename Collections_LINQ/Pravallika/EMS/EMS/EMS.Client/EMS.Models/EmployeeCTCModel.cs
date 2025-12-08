using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Models
{
    internal class EmployeeCTCModel
    {
        public int EmployeeCTCId { get; set; }
        public int EmployeeId { get; set; }
        public decimal SalaryCTC { get; set;}
        public DateTime EffectiveFrom { get; set; }
        public DateTime EndDate { get; set; }

    }
}
