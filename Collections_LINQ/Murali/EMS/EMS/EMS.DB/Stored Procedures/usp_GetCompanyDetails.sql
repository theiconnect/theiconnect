CREATE PROCEDURE [dbo].[usp_GetCompanyDetails]
AS
BEGIN
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
		ISNULL(LastUpdatedBy, CreatedBy) AS LastUpdatedBy,
		ISNULL(LastUpdatedOn, CreatedOn) AS LastUpdatedOn
	FROM dbo.Company

	SELECT
		CompanyAddressIdPk,
		CompanyIdFk,
		AddressLine1,
		AddressLine2,
		City,
		[State],
		PinCode,
		AddressTypeIdFk,
		atl.AddressTypeCode,
		atl.AddressTypeDescription
	FROM dbo.CompanyAddress ca
	JOIN dbo.AddressTypeLookup atl
		ON ca.AddressTypeIdFk = atl.AddressTypeIdPk

END