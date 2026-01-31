CREATE PROCEDURE [dbo].[Usp_GetEmployeeDetails]
	
AS
BEGIN
	SET NOCOUNT ON;
	SELECT 
	    EmployeeIdPk,
		Employeecode,
		FirstName,
		LastName,
		BloodGroup,
		Gender,
		EmailId,
		MobileNumber,
		DateOfBirth,
		DateOfJoining,
		ExpInMonths,
		SalaryCtc,
		IsActive
	FROM dbo.Employee
   
END
