using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Models
{
    public class CompanyModel
    {
       
            public int CompanyIdPk { get; set; }
            public string CompanyName { get; set; }
            public string PhoneNumber { get; set; }
            public string Email { get; set; }
            public DateTime RegistrationDate { get; set; }
            public string Website { get; set; }
            public string BankAccountNumber { get; set; }
            public string TAN { get; set; }
            public string PAN { get; set; }
            List<CompanyAddressModel> Addressess { get; set; }



        }

    
}
