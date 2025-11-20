using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Models
{
       public class CompanyAddressModel
       {
       public string CompanyAddressModelIdPk { get; set; }

       public string AddressLine1 { get; set; }

       public string AddressLine2 { get; set; }

       public string City { get; set; }

       public string State { get; set; }

       public string Pincode { get; set; }

       public string Country { get; set; }

       public AddressType  AddressTypeIdFk { get; set; }
       
        public int  CompanyIdFk { get; set; }

        List<DepartmentCompanyAddressModel> DepartmentCompanyAddressModel { get; set; }
  
    }

}
