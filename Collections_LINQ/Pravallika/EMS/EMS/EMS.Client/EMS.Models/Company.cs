using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Models
{
    public class CompanyModel
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string CompanyPhoneNumber { get; set; }
        public string CompanyEmail { get; set; }
        public string CompanyRegistrationDate { get; set; }
        public DateTime CompanyRegistrationName { get; set; }
        public string Website { get; set; }
        public string BankAccountNumber { get; set; }
        public string TAN { get; set; }
        public string PAN { get; set; }

    }
}
