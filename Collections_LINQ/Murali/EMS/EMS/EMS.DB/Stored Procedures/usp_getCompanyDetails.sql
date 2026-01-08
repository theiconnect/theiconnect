CREATE PROCEDURE [dbo].[usp_getCompanyDetails]
AS
BEGIN
	SELECT 
	CompanyIdPk,
		CompanyName,
		PhoneNumber,
		Email,
		RegistrationDate,
		Website,
		TIN,
		PAN,
		CreatedBy,
		CreatedOn,
		LastUpdatedBy,
		LastUpdatedOn
	FROM 
		[dbo].[Company];
END

