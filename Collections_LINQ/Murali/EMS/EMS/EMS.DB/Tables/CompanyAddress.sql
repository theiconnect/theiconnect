CREATE TABLE [dbo].[CompanyAddress]
(
	[CompanyAddressIdPk] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[CompanyIdFk] INT NOT NULL,
	[AddressTypeIdFk] INT NOT NULL,
	[AddressLine1] VARCHAR(512) NOT NULL,
	[AddressLine2] VARCHAR(512) NULL,
	[City] VARCHAR(256) NOT NULL,
	[State] VARCHAR(256) NOT NULL,
	[PinCode] VARCHAR(20) NULL,
)
