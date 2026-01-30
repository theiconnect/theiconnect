CREATE TABLE [dbo].[Employee]
(
    [EmployeeIdPk]            INT           IDENTITY (1, 1) NOT NULL,
    [EmployeeCode]            VARCHAR (50)  ,
    [FirstName]               VARCHAR (512), 
    [MiddleName]              VARCHAR (512),
    [LastName]                VARCHAR (512),  
    [BloodGroup]              int,
    [Gender]                  int,
    [EmailId]                 VARCHAR (256),
    [PersonalEmailId]         VARCHAR (256),
    [MobileNumber]            VARCHAR (20),
    [AlternateMobileNumber]   VARCHAR (20),
    [DateOfBirth]             DATETIME,
    [Dateofjoining]           DATETIME,
    [ExpInMonths]             INT,
    [SalaryCtc]               DECIMAL (18, 2),
    [IsActive]                BIT   DEFAULT ((1)) NOT NULL,
    [CreatedBy]               VARCHAR (512) NOT NULL,
    [CreatedOn]               DATETIME      DEFAULT (getdate()) NOT NULL,
    [LastUpdatedBy]           VARCHAR (512) NULL,
    [LastUpdatedOn]           DATETIME      NULL
)
