using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Model
{
    public class EmployeeDesignation
    {
        public EmployeeModel EmployeeDesignationIdPk {  get; set; }
        public DesignationLookUpModel DesignationIdFk {  get; set; }
        public int EmployeeIdFk {  get; set; }
        public DateTime    EffectiveFrom {  get; set; } 
        public DateTime    EndDate {  get; set; }

        List<EmployeeDesignation> EmployeeDesignations { get; set; }    
    }
}
