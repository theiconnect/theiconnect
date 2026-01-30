
CREATE PROCEDURE [dbo].[usp_GetAllDepartments_Search]
(
	@deptName		VARCHAR(512) = NULL,  
	@deptLocation	VARCHAR(512) = NULL,
	@companyId		INT
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
		CompanyIdFk,
		ISNULL(LastUpdatedOn, CreatedOn) LastUpdatedOn
	FROM dbo.Department
	WHERE
		(ISNULL(@deptName, '') = '' OR DepartmentName = @deptName)
		AND 
		(ISNULL(@deptLocation, '') = '' OR DeptLocation = @deptLocation)
	Order by LastUpdatedOn DESC
END