using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Model
{
    public class EmployeeDesignation
    {
        EmployeeModel EmployeeDesignationIdPk {  get; set; }
        DesignationLookUpModel DesignationIdFk {  get; set; }
        int EmployeeIdFk {  get; set; }
        DateTime    EffectiveFrom {  get; set; } 
        DateTime    EndDate {  get; set; }

    }
}
