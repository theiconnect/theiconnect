using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Models.Enums
{
    public enum AddressTypes
    {
        [Description("Corporate Office")]
        CORP_OFFICE = 1,
        [Description("Branch Office")]
        BRANCH_OFFICE = 2,
        [Description("Present Address")]
        PRESENT_ADDR = 3,
        [Description("Permanent Address")]
        PERM_ADDR = 4
    }    
}
