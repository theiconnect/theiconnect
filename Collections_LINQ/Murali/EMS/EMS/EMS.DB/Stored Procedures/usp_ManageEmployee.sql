CREATE PROCEDURE [dbo].[usp_ManageEmployee]
	(
	@ActionType		VARCHAR(10),
	@EmployeeIdPk INT = NULL,
	@EmployeeCode	VARCHAR(50) = NULL,
	@FirstName	VARCHAR(512) = NULL,
	@LastName 	VARCHAR(512) = NULL,
	@BloodGroup 	INT = NULL,
	@Gender 	INT = NULL,
	@EmailId	VARCHAR(256) = NULL,
	@MobileNumber	VARCHAR(20) = NULL,
	@DateOfBirth	DATETIME = NULL,
	@Dateofjoining	DATETIME = NULL,
	@ExpInMonths	INT = NULL,
	@SalaryCtc		DECIMAL(18, 2) = NULL,
	@IsActive		BIT = NULL,
	@UserName		VARCHAR(256) = NULL,
	@OutputMessage	VARCHAR(1000) OUTPUT
	)
AS
BEGIN
	SET NOCOUNT ON;

	BEGIN TRY
	--ActionType: ADD, UPDATE,DELETE
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
	Dateofjoining,
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
	@Dateofjoining,
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
	EmployeeCode = @EmployeeCode,
	FirstName = @FirstName,
	LastName = @LastName,
	BloodGroup=@BloodGroup,
	@Gender=@Gender,
	EmailId = @EmailId,
	MobileNumber = @MobileNumber,
	DateOfBirth = @DateOfBirth,
	Dateofjoining = @Dateofjoining,
	ExpInMonths = @ExpInMonths,
	SalaryCtc = @SalaryCtc,
	IsActive = @IsActive,
	LastUpdatedBy = @UserName,
	LastUpdatedOn = GETDATE()
	WHERE EmployeeIdPk = @EmployeeIdPk;
      END

    END TRY
    BEGIN CATCH
        SET @OutputMessage = 'FAILED WITH ERROR: ' + ERROR_MESSAGE();
    END CATCH
END



	

