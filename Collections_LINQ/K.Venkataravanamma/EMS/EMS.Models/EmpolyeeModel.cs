using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Models
{
    public class EmployeeModel
    {
        public int EmployeeCode { get; set; }
     public string FirstName { get; set; }
     public string MiddleName { get; set; }
     public string LastName { get; set; }
     public string BloodGroup {  get; set; }
     public string  Gender { get; set; }
     public string EmailId { get; set; }
     public string PersonalEmailId { get; set; }
     public int ManagerIdFk { get; set; }
     public int MobileNumber { get; set; }
     public int AlternateMobileNumber { get; set; }
     public int DeptIdFk { get; set; }
     public DateTime DOJ {  get; set; }
      public int ExpInMonths { get; set; }
     public DateTime DOB { get; set; }
     public int QualificationIdFk { get; set; }
     public int DesignationIdFk { get; set; }
     public decimal SalaryCTC { get; set; }
     public Boolean IsActive { get; set; }
     public DateTime LWD { get; set; } 



    }
}
