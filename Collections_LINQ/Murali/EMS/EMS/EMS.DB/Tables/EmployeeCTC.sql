CREATE TABLE [dbo].[EmployeeCTC]
(
    [Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),

    [EmployeeIdFk] INT NOT NULL,
    [SalaryCTC] DECIMAL(18,2) NOT NULL,

    [EffectiveFrom] DATE NOT NULL,
    [EndDate] DATE NOT NULL,

    -- 🔗 Foreign Key
    CONSTRAINT FK_EmployeeCTC_Employee
        FOREIGN KEY ([EmployeeIdFk]) REFERENCES [dbo].[Employee]([Id])
);

