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
	[CreatedBy]      VARCHAR (512) NOT NULL,
    [CreatedOn]      DATETIME      DEFAULT (GETDATE()) NULL,
    [LastUpdatedBy]  VARCHAR (512) NULL,
    [LastUpdatedOn]  DATETIME      NULL 
)
GO

ALTER TABLE [dbo].[CompanyAddress]  WITH CHECK ADD  CONSTRAINT [FK_CompanyAddress_Company] FOREIGN KEY([CompanyIdFk])
REFERENCES [dbo].[Company] ([CompanyIdPk])
GO
