CREATE PROCEDURE [dbo].[usp_getcompany]
	
AS
	SELECT 
	CompanyIdPk ,       
	CompanyName ,       
	PhoneNumber ,       
	Email     ,         
	RegistrationDate,   
	Website      ,      
	[BankAccountNumber],
	TIN          ,      
	PAN           from dbo.Company     
RETURN 0
