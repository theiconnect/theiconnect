using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMS.Model.Enums;

namespace EMS.Model
{
    public class EmployeeDesignation
    {
        public int EmployeeDesignationIdPk { get; set; }
        public DesignationLookUpEnum DesignationIdFk { get; set; }
        public int EmployeeIdFk { get; set; }
        public DateTime EffectiveFrom { get; set; }
        public DateTime EndDate { get; set; }
    }
}
