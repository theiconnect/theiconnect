using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EMS.Model
{
    public class CompanyModel
    {
        public int CompanyIdPk { get;set;}
public string CompanyName {  get;set;}
public string PhoneNumber {  get;set;}
public string Email {  get;set;}
public DateTime RegistrationDate {  get;set;} 
public string Website {  get;set;}
public string BankAccountNumer {  get;set;}
public string TAN {  get;set;}
public string PAN {  get;set;}
List<CompanyAddressModel> Addressess { get; set;}



    }
}
