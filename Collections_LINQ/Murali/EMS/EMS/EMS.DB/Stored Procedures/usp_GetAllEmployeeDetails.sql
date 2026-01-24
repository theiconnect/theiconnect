CREATE PROCEDURE usp_getallEmployees
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        -- Employee
        EmployeeIdPk,
        EmployeeCode,
        FirstName,
        MiddleName,
        LastName,
        EmailId,
        PersonalEmailId,
        MobileNumber,
        AlternateMobileNumber,
        DateOfBirth,
        DateOfJoining,
        ExpInMonths,
        LWD
        from dbo.Employee
END
GO






