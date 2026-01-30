CREATE TABLE [dbo].[Employee](
EmployeeIdPk int Identity(1,1) NOT NULL PRIMARY KEY,
EmployeeCode  varchar(50),
FirstName varchar(50),
MiddleName Varchar(50),
LastName Varchar(50),
Bloodgroup int,
Gender int,
EmailId varchar(50),
PersonalEmailId varchar(50),
MobileNumber varchar(50),
AlternateMobileNumber varchar(50),
DateOfBirth Date,
DateOfJoining Date,
ExpInMonths int,
SalaryCtc decimal(10,2),
IsActive Bit Not null default(1),
[CreatedBy] VARCHAR(512) NOT NULL, 
[CreatedOn] DATETIME NOT NULL DEFAULT GETDATE(), 
[LastUpdatedBy] VARCHAR(512) NULL, 
[LastUpdatedOn] DATETIME NULL
);

