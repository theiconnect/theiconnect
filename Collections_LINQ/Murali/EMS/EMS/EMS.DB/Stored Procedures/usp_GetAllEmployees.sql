CREATE PROCEDURE [dbo].[usp_GetAllEmployees]
AS
BEGIN
	SELECT 
          EmployeeIdPk,
          EmployeeCode,
          FirstName,
          LastName,
          Bloodgroup,
          MobileNumber, 
          Gender,
          EmailId,
          DateOfBirth,
          DateOfJoining,
          IsActive,
          ExpInMonths,
          SalaryCtc
    FROM [dbo].[Employee] 
END 


