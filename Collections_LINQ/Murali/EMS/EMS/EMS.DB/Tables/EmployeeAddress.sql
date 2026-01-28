CREATE TABLE [dbo].[EmployeeAddress]
(
    [Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),

    [AddressLine1] NVARCHAR(200) NOT NULL,
    [AddressLine2] NVARCHAR(200) NULL,
    [State] NVARCHAR(100) NOT NULL,
    [City] NVARCHAR(100) NOT NULL,
    [Pincode] NVARCHAR(20) NOT NULL,

    [IsActive] BIT NOT NULL DEFAULT 1,

    [EmployeeIdFk] INT NOT NULL,
    [AddressTypeIdFk] INT NOT NULL,

    -- 🔗 Foreign Keys
    CONSTRAINT FK_EmployeeAddress_Employee
        FOREIGN KEY ([EmployeeIdFk]) REFERENCES [dbo].[Employee]([Id]),

    CONSTRAINT FK_EmployeeAddress_AddressType
        FOREIGN KEY ([AddressTypeIdFk]) REFERENCES [dbo].[AddressTypes]([Id])
);

