CREATE PROCEDURE [dbo].[usp_ManageEmployee]
(
	@ActionType		VARCHAR(10),
	@EmployeeIdPk Int,
	@EmployeeCode VARCHAR(50),
	@firstName VARCHAR(100),
	@lastName VARCHAR(100),
	@genderIdFk INT,
	@bloodGroupIdFk INT,
	@emailId VARCHAR(256),
	@mobileNumber VARCHAR(15),
	@dateOfBirth DATE,
	@dateOfJoining DATE,
	@expInMonths INT,
	@salaryCTc DECIMAL(18,2),
	@isActive BIT,
	@UserName		VARCHAR(256) = NULL,
	@OutputMessage	VARCHAR(1000) OUTPUT
)
AS
BEGIN
	SET NOCOUNT ON;

	BEGIN TRY
		-- ActionType: ADD, UPDATE, DELETE
		IF @ActionType = 'ADD'
		BEGIN
			INSERT INTO dbo.Employee
	(
		EmployeeCode,
		FirstName,
		LastName,
		GenderIdFk,
		BloodGroupIdFk,
		EmailId,
		MobileNumber,
		DateOfBirth,
		DateOfJoining,
		ExpInMonths,
		SalaryCTc,
		IsActive,
		CreatedOn,
		CreatedBy
	)
	VALUES
	(
		@EmployeeCode,
		@firstName,
		@lastName,
		@genderIdFk,
		@bloodGroupIdFk,
		@emailId,
		@mobileNumber,
		@dateOfBirth,
		@dateOfJoining,
		@expInMonths,
		@salaryCTc,
		@isActive,
		GETDATE(),
		@UserName
	)
		SELECT SCOPE_IDENTITY() AS NewEmployeeId;
		END
		ELSE IF @ActionType = 'UPDATE'
		BEGIN
			Update dbo.Employee 
			SET 
				EmployeeCode = @EmployeeCode,
				FirstName = @firstName,
				LastName = @lastName,
				GenderIdFk = @genderIdFk,
				BloodGroupIdFk = @bloodGroupIdFk,
				EmailId = @emailId,
				MobileNumber = @mobileNumber,
				DateOfBirth = @dateOfBirth,
				DateOfJoining = @dateOfJoining,
				ExpInMonths = @expInMonths,
				SalaryCTc = @salaryCTc,
				IsActive = @isActive,
				LastUpdatedBy = @UserName,
				LastUpdatedOn = GETDATE()
			WHERE EmployeeIdPk = @EmployeeIdPk
		END
		ELSE IF @ActionType = 'DELETE'
		BEGIN
			--DELETE FROM dbo.Department
			--WHERE DepartmentIdPk = @DepartmentIdPk;

			-- Soft Delete
			UPDATE dbo.Employee
			SET 
				IsActive = 0,
				LastUpdatedBy = @UserName,
				LastUpdatedOn = GETDATE()
			WHERE EmployeeIdPk = @EmployeeIdPk
		END
		ELSE IF @ActionType = 'ACTIVATE'
		BEGIN
			UPDATE dbo.Employee
			SET 
				IsActive = 0,
				LastUpdatedBy = @UserName,
				LastUpdatedOn = GETDATE()
			WHERE EmployeeIdPk = @EmployeeIdPk
		END

		SET @OutputMessage  = 'Success';
	END TRY
	BEGIN CATCH
		SET @OutputMessage  = 'FAILED WITH ERROR: ' + ERROR_MESSAGE();
	END CATCH

END
