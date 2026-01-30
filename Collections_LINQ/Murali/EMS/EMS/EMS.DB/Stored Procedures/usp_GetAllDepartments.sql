CREATE PROCEDURE [dbo].[usp_GetAllDepartments]
	
AS
BEGIN
	SELECT 
		DepartmentIdPk, 
		DepartmentCode, 
		DepartmentName, 
		IsActive, 
		DeptLocation, 
		CreatedOn,
		CompanyIdFk,
		LastUpdatedOn
	FROM dbo.Department
END
RETURN 0
