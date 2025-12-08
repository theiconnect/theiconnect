using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Models
{
    public class EmployeeDesignationModel
    {
        public int EmployeeDesignationIdPK { get; set; }
        public int DesignationIdFk{ get; set; }
        public int  EmployeeIdFK { get; set; }
        public DateTime EffectiveForm { get; set; }
        public DateTime EndDate { get; set; }
    }
}
