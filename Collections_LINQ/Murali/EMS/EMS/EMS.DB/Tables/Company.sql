CREATE TABLE [dbo].[Company] (
    CompanyIdPk         INT IDENTITY(1,1)   NOT NULL PRIMARY KEY,
    CompanyName         VARCHAR(50)         NOT NULL,
    PhoneNumber         VARCHAR(15)         NULL,
    Email               VARCHAR(100)        NULL,
    RegistrationDate    DATETIME            NULL,
    Website             VARCHAR(100)        NULL,
    [BankAccountNumber]         VARCHAR(512)              NULL,
    TIN                 VARCHAR(20)         NULL,
    PAN                 VARCHAR(10)         NULL, 
    [CreatedBy] VARCHAR(512) NOT NULL, 
    [CreatedOn] DATETIME NOT NULL DEFAULT GETDATE(), 
    [LastUpdatedBy] VARCHAR(512) NULL, 
    [LastUpdatedOn] DATETIME NULL
);

Go

INSERT INTO [dbo].[Company] (CompanyName, PhoneNumber, Email, RegistrationDate, Website, BankAccountNumber, TIN, PAN, CreatedBy)
VALUES ('IConnect Solutions', '123-456-7890', 'iconnect@gmail.com', '2020-01-15', 'www.iconnectsolutions.com', '1234567890123456', 'TIN1234567', 'PAN1234A', 'system');