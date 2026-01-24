CREATE TABLE DepartmentAddress (
    DepartmentAddressIdPk INT IDENTITY(1,1) PRIMARY KEY,
    AddressLine1 VARCHAR(512) NOT NULL,
    AddressLine2 VARCHAR(512) NULL,
    State VARCHAR(128) NOT NULL,
    City VARCHAR(128) NOT NULL,
    PinCode CHAR(6) NOT NULL,
    AddressTypeIdFk INT NOT NULL,
    CONSTRAINT FK_DepartmentAddress_AddressType 
        FOREIGN KEY (AddressTypeIdFk) 
        REFERENCES AddressTypeLookup(AddressTypeIdPk)

);

