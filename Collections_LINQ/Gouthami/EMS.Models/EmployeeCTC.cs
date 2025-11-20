using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Models
{
    public class EmployeeCTC
    {
        public int EmployeeCTCIdPk { get; set; }

        public EmployeeModel  EmployeeIdFk { get; set; }

        public string SalaryCTC { get; set; }

        public DateTime EffectiveForm { get; set; }

        public DateTime EndDate  { get;  set; }

    }
}
