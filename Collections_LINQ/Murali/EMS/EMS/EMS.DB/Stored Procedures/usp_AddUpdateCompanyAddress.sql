CREATE PROCEDURE [dbo].[usp_AddUpdateCompanyAddress]
	@CompanyAddressIdPk INT = 0 OUTPUT,
	@AddressTypeIdFk	INT,
	@AddressLine1		VARCHAR(512),
	@AddressLine2		VARCHAR(512) = NULL,
	@City				VARCHAR(256),
	@State				VARCHAR(256),
	@PinCode			VARCHAR(20) = NULL,
	@UserId				VARCHAR(100)
AS
BEGIN
	IF @CompanyAddressIdPk > 0
	BEGIN
		UPDATE CompanyAddress
			SET AddressLine1  = @AddressLine1,
				AddressLine2 = @AddressLine2,
				City = @City,
				[State] = @State,
				PinCode = @PinCode,
				AddressTypeIdFk = @AddressTypeIdFk,
				LastUpdatedOn = GETDATE(),
				LastUpdatedBy = @UserId
		WHERE 
			CompanyAddressIdPk = @CompanyAddressIdPk
	END
	ELSE
	BEGIN
		DECLARE @CompanyIdPk INT
		
		SELECT TOP 1 @CompanyIdPk = CompanyIdPk FROM Company

		INSERT INTO dbo.CompanyAddress(CompanyIdFk, AddressTypeIdFk, AddressLine1, AddressLine2, City, [State], PinCode, CreatedBy, CreatedOn)
		VALUES(@CompanyIdPk, @AddressTypeIdFk, @AddressLine1, @AddressLine2, @City, @State, @PinCode, @UserId, GETDATE());

		SET @CompanyAddressIdPk = SCOPE_IDENTITY()
	END
END
