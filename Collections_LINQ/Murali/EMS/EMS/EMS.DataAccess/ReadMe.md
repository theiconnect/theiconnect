 Company = new CompanyModel();
Company.CompanyIdPk = 1;
Company.CompanyName = "ABC Pvt Ltd";
Company.PhoneNumber = "1234567890";
Company.BankAccountNumber = "9876543210";

(OR)

Company = new CompanyModel
{
    CompanyIdPk =1,
    CompanyName = "ABC Pvt Ltd",
    PhoneNumber = "1234567890",
    BankAccountNumber = "9876543210",
    Website = "www.abc.com",
    Email   ="abc.pvt.ltd@gmail.com",
    PAN = "ABCDE1234F",
    TIN = "12ABCDE3456F7Z8",
};