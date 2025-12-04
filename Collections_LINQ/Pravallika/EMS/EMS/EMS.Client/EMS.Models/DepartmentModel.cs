using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Models
{
    public class DepartmentModel
    {
        public int DepartmentId { get; set; }
        public string DepartmentCode{ get; set; }
        public string DepartmentName { get; set; }
        public string Location { get; set; }
        public bool Isactive{ get; set; }
        

    }
}
