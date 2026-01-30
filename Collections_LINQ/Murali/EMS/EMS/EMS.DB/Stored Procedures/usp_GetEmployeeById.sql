CREATE PROCEDURE [dbo].[usp_GetEmployeeById]
	@EmployeeId	INT
AS
BEGIN
   SELECT 
	EmployeeIdPk,
	EmployeeCode,
	FirstName,
	LastName,
	MobileNumber,
	Gender,
	EmailId,
	DateOfBirth,
	IsActive,
	ISNULL(LastUpdatedOn, CreatedOn) LastUpdatedOn
   FROM dbo.Employee
   WHERE EmployeeIdPk = @EmployeeId
   END

		

