using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Model
{
    public class EmployeeCTC
    {
public int EmployeeCTCPk {  get; set; }
public EmployeeModel EmployeeIdFk {  get; set; }
public string SalaryCTC { get; set; }
public DateTime EffectiveFrom {  get; set; }
public DateTime Enddate {  get; set; }

    }
}
