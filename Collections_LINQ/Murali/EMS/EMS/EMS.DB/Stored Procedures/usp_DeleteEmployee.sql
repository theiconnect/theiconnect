CREATE PROCEDURE [dbo].[usp_DeleteEmployee]
    @ActionType Varchar(50),
	@EmployeeIdPk int,
	@UserName Varchar(50),
	@OutputMessage varchar(50) Output
AS
Begin

Begin try
	IF @ActionType = 'DELETE'
		BEGIN
		
			UPDATE dbo.Employee
			SET 
				IsActive = 0,
				LastUpdatedBy = @UserName,
				LastUpdatedOn = GETDATE()
			WHERE EmployeeIdPk = @EmployeeIdPk;
		END
		ELSE IF @ActionType = 'ACTIVATE'
		BEGIN
			UPDATE dbo.Employee
			SET 
				IsActive = 1,
				LastUpdatedBy = @UserName,
				LastUpdatedOn = GETDATE()
			WHERE @EmployeeIdPk = @EmployeeIdPk;
		END

		SET @OutputMessage  = 'Success';
	END TRY
	BEGIN CATCH
		SET @OutputMessage  = 'FAILED WITH ERROR: ' + ERROR_MESSAGE();
	END CATCH
end
	