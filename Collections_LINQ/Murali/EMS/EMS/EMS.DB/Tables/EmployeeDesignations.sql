CREATE TABLE [dbo].[EmployeeDesignations]
(
    [Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),

    [EmployeeIdFk] INT NOT NULL,
    [DesignationIdFk] INT NOT NULL,

    [EffectiveFrom] DATE NOT NULL,
    [EndDate] DATE NULL,

    -- 🔗 Foreign Keys
    CONSTRAINT FK_EmployeeDesignations_Employee
        FOREIGN KEY ([EmployeeIdFk]) REFERENCES [dbo].[Employee]([Id]),

    CONSTRAINT FK_EmployeeDesignations_Designation
        FOREIGN KEY ([DesignationIdFk]) REFERENCES [dbo].[DesiginationType]([Id])
);
