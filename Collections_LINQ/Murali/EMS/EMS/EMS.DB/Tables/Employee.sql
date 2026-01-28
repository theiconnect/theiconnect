CREATE TABLE [dbo].[Employee]
(
    [Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),

    [EmployeeCode] NVARCHAR(50) NULL,
    [FirstName] NVARCHAR(100) NOT NULL,
    [MiddleName] NVARCHAR(100) NULL,
    [LastName] NVARCHAR(100) NOT NULL,

    [BloodGroupIdFk] INT NOT NULL,
    [GenderIdFk] INT NOT NULL,

    [EmailId] NVARCHAR(150) NULL,
    [PersonalEmailId] NVARCHAR(150) NULL,
    [MobileNumber] NVARCHAR(20) NULL,
    [AlternateMobileNumber] NVARCHAR(20) NULL,

    [DepartmentIdFk] INT NOT NULL,  -- FK now matches DepartmentIdPk

    [DateOfBirth] DATE NOT NULL,
    [DateOfJoining] DATE NOT NULL,

    [ExpInMonths] INT NOT NULL DEFAULT 0,

    [QualificationIdFk] INT NULL,
    [DesignationIdFk] INT NOT NULL,

    [SalaryCtc] DECIMAL(18,2) NULL,

    [IsActive] BIT NOT NULL DEFAULT 1,
    [LWD] DATE NULL,

    /* =====================
       FOREIGN KEYS
       ===================== */

    CONSTRAINT FK_Employee_BloodGroups
        FOREIGN KEY ([BloodGroupIdFk])
        REFERENCES [dbo].[BloodGroups]([Id]),

    CONSTRAINT FK_Employee_Gender
        FOREIGN KEY ([GenderIdFk])
        REFERENCES [dbo].[Gender]([Id]),

    CONSTRAINT FK_Employee_Qualification
        FOREIGN KEY ([QualificationIdFk])
        REFERENCES [dbo].[Qualifications]([Id]),

    CONSTRAINT FK_Employee_Designation
        FOREIGN KEY ([DesignationIdFk])
        REFERENCES [dbo].[DesiginationType]([Id]),

    CONSTRAINT FK_Employee_Department
        FOREIGN KEY ([DepartmentIdFk])
        REFERENCES [dbo].[Department]([DepartmentIdPk])
);
