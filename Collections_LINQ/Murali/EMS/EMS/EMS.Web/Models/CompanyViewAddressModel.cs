using EMS.Models;
using EMS.Models.Enums;

namespace EMS.Web.Models
{
    public class CompanyViewAddressModel
    {

        public int CompanyAddressIdPk { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Pincode { get; set; }
        public AddressTypes AddressTypeIdFk { get; set; }//enum-Fixed//int-dynamic---> Fixed-> Enum(AddressTypes-> Emp/Comp)
        public int CompanyIdFk { get; set; }

        public List<DepartmentModel> Departments { get; set; } = new List<DepartmentModel>();
    }
}
