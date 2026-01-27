Create PROCEDURE [dbo].[usp_ManageEmployee]
(
    @ActionType      VARCHAR(10),
    @EmployeeIdPk    INT = NULL,
    @EmployeeCode    VARCHAR(50) = NULL,
    @FirstName       VARCHAR(512) = NULL,
    @LastName        VARCHAR(50) = NULL,
    @BloodGroup      INT = NULL,
    @Gender          INT = NULL,
    @EmailId         VARCHAR(50),
    @MobileNumber    VARCHAR(50),
    @DateOfBirth     DATE,
    @DateOfJoining   DATE,
    @ExpInMonths     INT,
    @SalaryCtc       DECIMAL(10,2),
    @IsActive        BIT,
    @UserName        VARCHAR(256) = NULL,
    @OutputMessage   VARCHAR(1000) OUTPUT
)
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        IF @ActionType = 'ADD'
        BEGIN
            INSERT INTO dbo.Employee
            (
                EmployeeCode,
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
                IsActive,
                CreatedBy,
                CreatedOn
            )
            VALUES
            (
                @EmployeeCode,
                @FirstName,
                @LastName,
                @BloodGroup,
                @Gender,
                @EmailId,
                @MobileNumber,
                @DateOfBirth,
                @DateOfJoining,
                @ExpInMonths,
                @SalaryCtc,
                @IsActive,
                @UserName,
                GETDATE()
            );
	SELECT SCOPE_IDENTITY() AS NewEmployeeId;
END
ELSE IF @ActionType = 'UPDATE'
		BEGIN
			UPDATE dbo.Employee
			SET 
		    EmployeeCode=@EmployeeCode,
            FirstName=@FirstName,
            LastName=@LastName,
            BloodGroup=@BloodGroup,
            Gender=@Gender,
            EmailId=@EmailId,
            MobileNumber=@MobileNumber,
            DateOfBirth=@DateOfBirth,
            DateOfJoining=@DateOfJoining,
            ExpInMonths=@ExpInMonths,
            SalaryCtc=@SalaryCtc,
            IsActive=@IsActive,
            LastUpdatedBy = @UserName,
			LastUpdatedOn = GETDATE()
			WHERE EmployeeIdPk = @EmployeeIdPk;
		END
	END TRY
	BEGIN CATCH
		SET @OutputMessage  = 'FAILED WITH ERROR: ' + ERROR_MESSAGE();
	END CATCH
END

