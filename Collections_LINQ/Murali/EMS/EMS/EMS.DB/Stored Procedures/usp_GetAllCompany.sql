CREATE PROCEDURE [dbo].[usp_GetAllCompany]
AS
BEGIN
	SET NOCOUNT ON;
	SELECT 
		CompanyIdPk,
		CompanyName,
		PhoneNumber,
		Email,
		RegistrationDate,
		Website,
		BankAccountNumber,
		TIN,
		PAN,
		CreatedBy,
		CreatedOn,
		LastUpdatedBy,
		LastUpdatedOn
	FROM 
		dbo.Company;
END
