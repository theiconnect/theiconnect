CREATE PROCEDURE [dbo].[usp_GetEmployeeDetailsById]
@EmployeeId INT
AS
BEGIN
    --Employee Info
	SELECT 
          EmployeeIdPk,
          EmployeeCode,
          FirstName,
          LastName,
          Bloodgroup,
          MobileNumber, 
          Gender,
          EmailId,
          DateOfBirth,
          DateOfJoining,
          IsActive,
          ExpInMonths,
          SalaryCtc
    FROM [dbo].[Employee] 
    WHERE EmployeeIdPk = @EmployeeId

    DECLARE @PERM_ADDR_TYPE_ID  INT = 3
    DECLARE @PRES_ADDR_TYPE_ID  INT = 4

    --Employee Permanat Address and Present Address
    SELECT EmployeeAddressIdPk, AddressTypeIdFk, AddressLine1, AddressLine2, City, [State], [PINCode] 
    FROM EmployeeAddress EA
    WHERE EmployeeIDFk = @EmployeeId
        AND IsActive = 1

    --Employee Address History
    SELECT EmployeeAddressIdPk, AddressTypeIdFk, AddressLine1, AddressLine2, City, [State], [PINCode] 
    FROM EmployeeAddress EA
    WHERE EmployeeIDFk = @EmployeeId
        AND IsActive = 0


END 


