namespace EMS.Web.Models
{
    public class DepartmentListViewModel
    {
        public int DepartmentId { get; set; }
        public string Code { get; set; }
        public string DeptName { get; set; }
        public string Location { get; set; }
        public bool IsActive { get; set; }
    }
}
