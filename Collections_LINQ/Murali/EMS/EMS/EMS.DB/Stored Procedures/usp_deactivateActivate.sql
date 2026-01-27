CREATE PROCEDURE [dbo].[usp_deactivateActivate]
	@ActionType		VARCHAR(10),
	@UserName VARCHAR(50),
	@EmployeeIdPk INT,
	@OutputMessage VARCHAR(20) output
AS
BEGIN
	BEGIN TRY
	IF @ActionType = 'DELETE'
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
RETURN 0
