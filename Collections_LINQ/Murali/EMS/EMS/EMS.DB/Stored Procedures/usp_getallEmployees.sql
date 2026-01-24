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
        GenderIdFk,
        BloodGroupIdFk,
        QualificationIdFk,
        DesignationIdFk,
        EmailId,
        PersonalEmailId,
        MobileNumber,
        AlternateMobileNumber,
        DateOfBirth,
        DateOfJoining,
        ExpInMonths,
        SalaryCTc,
        LWD
        from dbo.Employee
END
GO






