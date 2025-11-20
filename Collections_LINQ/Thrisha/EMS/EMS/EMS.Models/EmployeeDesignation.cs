using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Models
{
    public class EmployeeDesignation
    {
      public int EmployeeDesignationIdPk { get; set; }
       public  DesignationLookUpModel DesignationIdFk { get; set; }
       public  int EmployeeIdFk { get; set; }
        public new DateTime EffectiveFrom { get; set; }
       public  new DateTime EndDate { get; set; }
    }
}
