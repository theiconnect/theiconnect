CREATE PROCEDURE [dbo].[CompanyAddressSP]

AS
begin
	select 
AddressLine1,
AddressLine2,
City,
[State],
Pincode,
AddressTypeIdFk,
CompanyIdFk
FROM dbo.[companyAddress];
end
