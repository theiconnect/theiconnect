
using System.ComponentModel;
using EMS.Web.Models;

namespace EMS.Web.Models
{
    public class CompanyViewModel
    {
        public CompanyViewModel()
        { }
            public  CompanyViewModel( int _CompanyIdPk, string _CompanyName,string _PhoneNumber, string _Email,DateTime _RegistrationDate , string _Website,string _BankAccountNumber, string _TIN,  string _PAN )

            {
            CompanyIdPk = _CompanyIdPk;
            CompanyName = _CompanyName;

            PhoneNumber = _PhoneNumber;
            Email = _Email;
            RegistrationDate = _RegistrationDate;
            Website = _Website;
            BankAccountNumber = _BankAccountNumber;
            TIN = _TIN;
            PAN = _PAN;


             }
        public int CompanyIdPk { get; set; }
        public string CompanyName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public string Website { get; set; }
        public string BankAccountNumber { get; set; }
        public string TIN { get; set; }
        public string PAN { get; set; }

    }
}
