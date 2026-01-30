using System.ComponentModel;

namespace EMS.Web.Models
{
    public class DepartmentViewModel
    {
        public DepartmentViewModel() { }
        public DepartmentViewModel(int _departmentId, string _code, string _name, string _location, bool _isActive)
        {
            DepartmentId = _departmentId;
            Code = _code;
            DeptName = _name;
            Location = _location;
            IsActive = _isActive;
        }
        public int DepartmentId { get; set; }

        [DisplayName("Department Code")]
        public string Code { get; set; }

        [DisplayName("Department Name")]
        public string DeptName { get; set; }

        [DisplayName("Location")]
        public string Location { get; set; }
        public bool IsActive { get; set; }

        [DisplayName("Active")]
        public string Active
        {
            get
            {
                return IsActive ? "Yes" : "No";
            }
        }
        public int CompanyId { get; set; }
        }
}
