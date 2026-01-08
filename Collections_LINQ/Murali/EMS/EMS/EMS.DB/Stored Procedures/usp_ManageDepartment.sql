CREATE PROCEDURE [dbo].[usp_ManageDepartment]
(
	@ActionType		VARCHAR(10),
	@DepartmentIdPk INT = NULL,
	@DepartmentCode	VARCHAR(50) = NULL,
	@DepartmentName	VARCHAR(512) = NULL,
	@IsActive		BIT = NULL,
	@DeptLocation	VARCHAR(512) = NULL,
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
			INSERT INTO dbo.Department
			(
				DepartmentCode,
				DepartmentName,
				IsActive,
				DeptLocation,
				CreatedBy,
				CreatedOn
			)
			VALUES
			(
				@DepartmentCode,
				@DepartmentName,
				@IsActive,
				@DeptLocation,
				@UserName,
				GETDATE()
			);
			SELECT SCOPE_IDENTITY() AS NewDepartmentId;
		END
		ELSE IF @ActionType = 'UPDATE'
		BEGIN
			UPDATE dbo.Department
			SET 
				DepartmentCode = @DepartmentCode,
				DepartmentName = @DepartmentName,
				IsActive = @IsActive,
				DeptLocation = @DeptLocation,
				LastUpdatedBy = @UserName,
				LastUpdatedOn = GETDATE()
			WHERE DepartmentIdPk = @DepartmentIdPk;
		END
		ELSE IF @ActionType = 'DELETE'
		BEGIN
			--DELETE FROM dbo.Department
			--WHERE DepartmentIdPk = @DepartmentIdPk;

			-- Soft Delete
			UPDATE dbo.Department
			SET 
				IsActive = 0,
				LastUpdatedBy = @UserName,
				LastUpdatedOn = GETDATE()
			WHERE DepartmentIdPk = @DepartmentIdPk;
		END
		ELSE IF @ActionType = 'ACTIVATE'
		BEGIN
			UPDATE dbo.Department
			SET 
				IsActive = 1,
				LastUpdatedBy = @UserName,
				LastUpdatedOn = GETDATE()
			WHERE DepartmentIdPk = @DepartmentIdPk;
		END

		SET @OutputMessage  = 'Success';
	END TRY
	BEGIN CATCH
		SET @OutputMessage  = 'FAILED WITH ERROR: ' + ERROR_MESSAGE();
	END CATCH

END


/*
public object ManageDepartment(string actionType, DeparmtneModel model){

	if( actionType == 'ADD')
	{--EXCEPT ID 
		dEPARTMENT dept = new DEPARTMENT();
		dept.DepartmentName = model.DepartmentName;
		...
		dbContext.DEPARTMENTS.Add(dept);

		return scope_identity() as newDepartmentId
	}

	else if (action_type == 'Update')
	{
		ALL
		update Department set DepartmentCode = DepartmentCode, jsdflkjsdlkfjlkj
		where DepartmentIdPk = model.DepartmentIdPk
	}
	else if (action_type == 'DELETE')
	{ --ONLY ID
		delete from Department where DepartmentIdPk = model.DepartmentIdPk
	}else if (action_type == 'getall'){
	--NO PARAMTERS
		select * from Department
	}
	else if (action_type == 'getallwithsearch'){
	--PARAMETERS DEPTNAME, DEPTLOCATION
		select * from Department
		where 
		(ISNULL(@deptName, '') = '' OR DepartmentName = @deptName)
		AND
		(ISNULL(@deptLocation, '') = '' OR DeptLocation = @deptLocation)
		
	}
}
*/