CREATE PROCEDURE [dbo].[usp_GetDepartmentById]
	@DepartmentId	INT
AS
BEGIN
	SELECT 
		DepartmentIdPk, 
		DepartmentCode, 
		DepartmentName, 
		IsActive, 
		DeptLocation, 
		CreatedOn,
		ISNULL(LastUpdatedOn, CreatedOn) LastUpdatedOn
	FROM dbo.Department
	WHERE DepartmentIdPk = @DepartmentId
END
