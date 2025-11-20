using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Models
{

    public enum CompanyAddressTypeModel
    {
        HeadOffice = 1,
        BranchOffice = 2,

    }
    public enum EmployeeAddressTypeModel
    {

        PermanentAddress = 1,
        TemporaryAddress = 2
    }

    public enum EmployeeGender
    {
        Male = 1,
        Female = 2,
        Trans = 3,
        Not Willing to disclose = 4

    }

}
