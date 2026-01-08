
CREATE PROCEDURE [dbo].[usp_GetAllDepartments]
(
	@deptName		VARCHAR(512) = NULL,  
	@deptLocation	VARCHAR(512) = NULL
)
AS
BEGIN
	SET NOCOUNT ON;

	SELECT 
		DepartmentIdPk, 
		DepartmentCode, 
		DepartmentName, 
		IsActive, 
		DeptLocation, 
		CreatedOn,
		ISNULL(LastUpdatedOn, CreatedOn) LastUpdatedOn
	FROM dbo.Department
	WHERE
		(ISNULL(@deptName, '') = '' OR DepartmentName = @deptName)
		AND 
		(ISNULL(@deptLocation, '') = '' OR DeptLocation = @deptLocation)
	Order by LastUpdatedOn DESC
END