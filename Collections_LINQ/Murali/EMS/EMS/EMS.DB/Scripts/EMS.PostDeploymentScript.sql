IF NOT EXISTS (SELECT * FROM dbo.Company)
BEGIN
	INSERT INTO dbo.Company(CompanyName, PhoneNumber, Email, RegistrationDate, Website, BankAccountNumber, TIN, PAN, CreatedBy)
	VALUES('iConnect Tech Solutions', '1111111111', 'hr@iconnecttechsolutions.com', GETDATE(), 'www.iconnecttechsolutions.com', '1234567890', 'TIN1234567', 'PAN1234567', 'System');
END
GO

IF NOT EXISTS(SELECT * FROM dbo.AddressTypeLookup WHERE AddressTypeIdPk = 1 AND AddressTypeCode = 'CORP_OFFICE')
BEGIN
	INSERT INTO dbo.AddressTypeLookup(AddressTypeIdPk, AddressTypeCode, AddressTypeDescription)
	VALUES(1, 'CORP_OFFICE', 'Corporate Office');
END
ELSE
BEGIN
	UPDATE dbo.AddressTypeLookup
	SET AddressTypeDescription = 'Corporate Office'
	WHERE AddressTypeIdPk = 1 AND AddressTypeCode = 'CORP_OFFICE';
END
GO

IF NOT EXISTS(SELECT * FROM dbo.AddressTypeLookup WHERE AddressTypeIdPk = 2 AND AddressTypeCode = 'BRANCH_OFFICE')
BEGIN
	INSERT INTO dbo.AddressTypeLookup(AddressTypeIdPk, AddressTypeCode, AddressTypeDescription)
	VALUES(2, 'BRANCH_OFFICE', 'Branch Office');
END
ELSE
BEGIN
	UPDATE dbo.AddressTypeLookup
	SET AddressTypeDescription = 'Branch Office'
	WHERE AddressTypeIdPk = 2 AND AddressTypeCode = 'BRANCH_OFFICE';
END
GO

IF NOT EXISTS(SELECT * FROM dbo.AddressTypeLookup WHERE AddressTypeIdPk = 3 AND AddressTypeCode = 'PERM_ADDR')
BEGIN
	INSERT INTO dbo.AddressTypeLookup(AddressTypeIdPk, AddressTypeCode, AddressTypeDescription)
	VALUES(3, 'PERM_ADDR', 'Permanent Address');
END
ELSE
BEGIN
	UPDATE dbo.AddressTypeLookup
	SET AddressTypeDescription = 'Permanent Address'
	WHERE AddressTypeIdPk = 3 AND AddressTypeCode = 'PERM_ADDR';
END
GO

IF NOT EXISTS(SELECT * FROM dbo.AddressTypeLookup WHERE AddressTypeIdPk = 4 AND AddressTypeCode = 'PRESENT_ADDR')
BEGIN
	INSERT INTO dbo.AddressTypeLookup(AddressTypeIdPk, AddressTypeCode, AddressTypeDescription)
	VALUES(4, 'PRESENT_ADDR', 'Present Address');
END
ELSE
BEGIN
	UPDATE dbo.AddressTypeLookup
	SET AddressTypeDescription = 'Present Address'
	WHERE AddressTypeIdPk = 4 AND AddressTypeCode = 'PRESENT_ADDR';
END
GO

IF NOT EXISTS (SELECT * FROM dbo.CompanyAddress WHERE AddressTypeIdFk = 1)
BEGIN
	INSERT INTO dbo.CompanyAddress(CompanyIdFk, AddressTypeIdFk, AddressLine1, AddressLine2, City, [State], PinCode)
	VALUES(1, 1, '123 Corporate Blvd', 'Suite 100', 'Metropolis', 'Stateville', '12345');
END