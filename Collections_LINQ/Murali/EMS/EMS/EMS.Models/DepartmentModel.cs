using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Models
{
    public class DepartmentModel
    {
        public int DepartmentIdPk { get; set; }
        public string DepartmentCode { get; set; }
        public string DepartmentName { get; set; }
        public string Location { get; set; }
        public int CompanyIdFk  { get; set; }
        public bool IsActive { get; set; } 

        public List<EmployeeModel> Employees { get; set; } = new List<EmployeeModel>();
    }
}
