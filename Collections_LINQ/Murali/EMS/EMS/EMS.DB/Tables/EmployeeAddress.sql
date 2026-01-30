CREATE TABLE [dbo].[EmployeeAddress](
	EmployeeAddressIdPk INT IDENTITY(1,1) NOT NULL PRIMARY KEY,

	EmployeeIDFk INT NOT NULL, --foreign key
	AddressTypeIdFk INT NOT NULL,

	AddressLine1 VARCHAR(512) NOT NULL,
	AddressLine2 VARCHAR(512) NULL,
	City VARCHAR(512) NOT NULL,
	[State] VARCHAR(512) NOT NULL,
	[PINCode] VARCHAR(512) NULL,
	IsActive BIT NOT NULL DEFAULT(1),

	[CreatedBy] VARCHAR(512) NOT NULL, 
	[CreatedOn] DATETIME NOT NULL DEFAULT GETDATE(), 
	[LastUpdatedBy] VARCHAR(512) NULL, 
	[LastUpdatedOn] DATETIME NULL

	--CONSTRAINT fk_EmployeeIdFk FOREIGN KEY (EmployeeIdFk) REFERENCES EmployeeAddress (EmployeeAddressIdPk)
);

