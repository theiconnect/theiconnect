Create PROCEDURE [dbo].[Company]
AS
Begin
	SELECT 
     CompanyIdPk,
	 CompanyName,
	 PhoneNumber,
	 Email,
	 RegistrationDate,
	 Website,
	 [BankAccountNumber],
	 TIN,
	 PAN
	 From [dbo].[Company];
End