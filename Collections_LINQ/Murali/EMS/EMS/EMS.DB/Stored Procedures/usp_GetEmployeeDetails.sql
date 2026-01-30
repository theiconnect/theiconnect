CREATE PROCEDURE [dbo].[usp_GetEmployeeDetails]
AS
begin
	select 
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
end
	
