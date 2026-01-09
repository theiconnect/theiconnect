CREATE TABLE [dbo].[AddressTypeLookup]
(
	[AddressTypeIdPk] INT NOT NULL PRIMARY KEY,
	[AddressTypeCode] VARCHAR(100) NOT NULL,
	[AddressTypeDescription] VARCHAR(512) NOT NULL
)
