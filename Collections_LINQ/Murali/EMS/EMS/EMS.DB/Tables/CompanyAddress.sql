CREATE TABLE [dbo].[CompanyAddress]
(
CompanyAddressIdPk int identity(1,1) NOT NULL,
AddressLine1 varchar(50) NOT NULL,
AddressLine2 varchar(50) NOT NULL,
City varchar(50)         NULL,
[State] varchar(50)      NULL,
Pincode varchar(50)      NULL,
AddressTypeIdFk int      NOT NULL,
CompanyIdFk int     NOT NULL
);
