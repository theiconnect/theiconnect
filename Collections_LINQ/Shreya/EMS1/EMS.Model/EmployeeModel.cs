using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Model
{
    public class EmployeeModel
    {
        public int EmployeeCode { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string BloodGroup { get; set; }
        public string Gender { get; set; }
        public string EmailId { get; set; }
        public string PersonalEmailId { get; set; }
        public string ManagerIdFk { get; set; }
        public string MobileNumber { get; set; }
        public string AlternateMobileNumber { get; set; }
        public int DeptIdFk { get; set; }
        public DateTime DOJ { get; set; }
        public int ExpInMonths { get; set; }
        public DateTime DOB { get; set; }
        public int QualificationIdFk { get; set; }
        public int DesignationIdFk { get; set; }
        public decimal SalaryCTC { get; set; }
        public Boolean IsActive { get; set; }
        public DateTime LWD { get; set; }
        List<EmployeeAddressModel> EmployeeAddressModels { get; set; }
        List<EmployeeDesignation> EmployeeDesignations { get; set; }
        List<EmployeeCTC> EmployeeCTC { get; set; }

    }
}
