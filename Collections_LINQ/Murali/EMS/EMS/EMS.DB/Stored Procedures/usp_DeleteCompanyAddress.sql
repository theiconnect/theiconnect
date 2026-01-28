CREATE PROCEDURE [dbo].[usp_DeleteCompanyAddress]
	@CompanyAddressIdPk INT
AS
BEGIN
	DELETE FROM dbo.CompanyAddress
	WHERE CompanyAddressIdPk = @CompanyAddressIdPk
END
