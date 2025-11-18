using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Models
{
    public class EmployeeCTCModel
    {
        public int EmployeeCTCIdPk { get; set; }
        public EmployeeModel EmployeeIdFk { get; set; }
        public decimal SalaryCTC { get; set; }
        public DateTime EffectiveFrom { get; set; }
        public DateTime EndDate { get; set; }
    }
}
