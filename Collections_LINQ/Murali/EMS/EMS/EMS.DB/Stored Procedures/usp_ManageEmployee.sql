Create PROCEDURE [dbo].[usp_ManageEmployee]
(
    @ActionType           VARCHAR(10),
    @EmployeeIdPk         INT = NULL,
    @EmployeeCode         VARCHAR(50) = NULL,
    @FirstName            VARCHAR(512) = NULL,
    @LastName             VARCHAR(50) = NULL,
    @BloodGroup           INT = NULL,
    @Gender               INT = NULL,
    @EmailId              VARCHAR(50),
    @MobileNumber         VARCHAR(50),
    @DateOfBirth          DATE,
    @DateOfJoining        DATE,
    @ExpInMonths          INT,
    @SalaryCtc            DECIMAL(10,2),
    @IsActive             BIT,
    @UserName             VARCHAR(256) = NULL,
    
    @PERM_AddressLine1    VARCHAR(512),
    @PERM_AddressLine2    VARCHAR(512) = NULL,
    @PERM_City            VARCHAR(512),
    @PERM_State           VARCHAR(512),
    @PERM_PIN             VARCHAR(512) = NULL,

    @Pres_AddressLine1    VARCHAR(512),
    @Pres_AddressLine2    VARCHAR(512) = NULL,
    @Pres_City            VARCHAR(512),
    @Pres_State           VARCHAR(512),
    @Pres_PIN             VARCHAR(512) = NULL,

    @OutputMessage   VARCHAR(1000) OUTPUT
)
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
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
                DateOfJoining,
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
                @DateOfJoining,
                @ExpInMonths,
                @SalaryCtc,
                @IsActive,
                @UserName,
                GETDATE()
            );

            SET @EmployeeIdPk = SCOPE_IDENTITY();

        END
        ELSE IF @ActionType = 'UPDATE'
		BEGIN
			UPDATE dbo.Employee
			SET 
		    EmployeeCode=@EmployeeCode,
            FirstName=@FirstName,
            LastName=@LastName,
            BloodGroup=@BloodGroup,
            Gender=@Gender,
            EmailId=@EmailId,
            MobileNumber=@MobileNumber,
            DateOfBirth=@DateOfBirth,
            DateOfJoining=@DateOfJoining,
            ExpInMonths=@ExpInMonths,
            SalaryCtc=@SalaryCtc,
            IsActive=@IsActive,
            LastUpdatedBy = @UserName,
			LastUpdatedOn = GETDATE()
			WHERE EmployeeIdPk = @EmployeeIdPk;
		END

        --employee details saved successfully.
        --Now add or update addresses
        --ADD
            --no addresses will be presetn
            --no need to check for existing address
            --just directly add new address records( 1. perm and another for present)
        DECLARE @PermAddressTypeId INT = 3
        DECLARE @PRESAddressTypeId INT = 4

        IF @ActionType = 'ADD'
        BEGIN
            INSERT INTO [dbo].[EmployeeAddress](EmployeeIDFk, AddressTypeIdFk, AddressLine1, AddressLine2,
            City, State, PINCode, IsActive, CreatedBy, CreatedOn)
            VALUES(@EmployeeIdPk, @PermAddressTypeId, @PERM_AddressLine1, @PERM_AddressLine2,
            @PERM_City, @PERM_State, @PERM_PIN, 1, @UserName, GETDATE())

            INSERT INTO [dbo].[EmployeeAddress](EmployeeIDFk, AddressTypeIdFk, AddressLine1, AddressLine2,
            City, State, PINCode, IsActive, CreatedBy, CreatedOn)
            VALUES(@EmployeeIdPk, @PRESAddressTypeId, @PRES_AddressLine1, @PRES_AddressLine2,
            @PRES_City, @PRES_State, @PRES_PIN, 1, @UserName, GETDATE())

        END
        ELSE
        BEGIN
            --Update
                --addresses will be present already
                --WE NEED TO CONFIRM WHETHER THE ADDRESS DETAILS MODIFIED OR NOT
                --IF MODIFIED
                    -- OLD RECORD - INACTIVE
                    --NEW DETAILS - NEW RECORD
                --IF NOT MODIFIED
                    -- REMAIN SAME
                    --NO ACTION REQUIRED.
            --PERMANANT ADDRESS
            DECLARE @PERM_OLD_ADDRESSLINE1 VARCHAR(512)
            DECLARE @PERM_OLD_ADDRESSLINE2 VARCHAR(512)
            DECLARE @PERM_OLD_City VARCHAR(512)
            DECLARE @PERM_OLD_State VARCHAR(512)
            DECLARE @PERM_OLD_PIN VARCHAR(512)

            SELECT 
                @PERM_OLD_ADDRESSLINE1 = AddressLine1, 
                @PERM_OLD_ADDRESSLINE2 = AddressLine2, 
                @PERM_OLD_city = CITY, 
                @PERM_OLD_State = State, 
                @PERM_OLD_PIN = PINCode
            FROM EmployeeAddress 
            WHERE EmployeeIDFk = @EmployeeIdPk AND AddressTypeIdFk = @PermAddressTypeId
                AND IsActive = 1

            IF @PERM_AddressLine1 != @PERM_OLD_ADDRESSLINE1 OR
                @PERM_AddressLine2 <> @PERM_OLD_ADDRESSLINE2 OR
                @PERM_City <> @PERM_OLD_city OR
                @PERM_State <> @PERM_OLD_State OR
                @PERM_PIN <> @PERM_OLD_PIN
            BEGIN
                -- SOME THING IS UPDATED
                -- OLD RECORD - INACTIVE
                UPDATE DBO.EmployeeAddress
                    SET IsActive = 0,
                        LastUpdatedBy = @UserName,
                        LastUpdatedOn = GETDATE()
                WHERE EmployeeIDFk = @EmployeeIdPk AND AddressTypeIdFk = @PermAddressTypeId
                    AND IsActive = 1
                    --NEW DETAILS - NEW RECORD
                
                INSERT INTO [dbo].[EmployeeAddress](EmployeeIDFk, AddressTypeIdFk, AddressLine1, AddressLine2,
                City, State, PINCode, IsActive, CreatedBy, CreatedOn)
                VALUES(@EmployeeIdPk, @PermAddressTypeId, @PERM_AddressLine1, @PERM_AddressLine2,
                @PERM_City, @PERM_State, @PERM_PIN, 1, @UserName, GETDATE())
            END

             --PRESENT ADDRESS
            DECLARE @PRES_OLD_ADDRESSLINE1 VARCHAR(512)
            DECLARE @PRES_OLD_ADDRESSLINE2 VARCHAR(512)
            DECLARE @PRES_OLD_City VARCHAR(512)
            DECLARE @PRES_OLD_State VARCHAR(512)
            DECLARE @PRES_OLD_PIN VARCHAR(512)

            SELECT 
                @PRES_OLD_ADDRESSLINE1 = AddressLine1, 
                @PRES_OLD_ADDRESSLINE2 = AddressLine2, 
                @PRES_OLD_city = CITY, 
                @PRES_OLD_State = State, 
                @PRES_OLD_PIN = PINCode
            FROM EmployeeAddress 
            WHERE EmployeeIDFk = @EmployeeIdPk AND AddressTypeIdFk = @PRESAddressTypeId
                AND IsActive = 1

            IF  @Pres_AddressLine1 <> @PRES_OLD_ADDRESSLINE1 OR
                @Pres_AddressLine2 <> @PRES_OLD_ADDRESSLINE2 OR
                @Pres_City <> @PRES_OLD_City OR
                @Pres_State <> @PRES_OLD_State OR
                @Pres_PIN <> @PRES_OLD_PIN
            BEGIN
                -- SOME THING IS UPDATED
                -- OLD RECORD - INACTIVE
                UPDATE DBO.EmployeeAddress
                    SET IsActive = 0,
                        LastUpdatedBy = @UserName,
                        LastUpdatedOn = GETDATE()
                WHERE EmployeeIDFk = @EmployeeIdPk AND AddressTypeIdFk = @PRESAddressTypeId
                    AND IsActive = 1
                    --NEW DETAILS - NEW RECORD
                
                INSERT INTO [dbo].[EmployeeAddress](EmployeeIDFk, AddressTypeIdFk, AddressLine1, AddressLine2,
                City, State, PINCode, IsActive, CreatedBy, CreatedOn)
                VALUES(@EmployeeIdPk, @PRESAddressTypeId, @PRES_AddressLine1, @PRES_AddressLine2,
                @PRES_City, @PRES_State, @PRES_PIN, 1, @UserName, GETDATE())
            END
        END

	END TRY
	BEGIN CATCH
		SET @OutputMessage  = 'FAILED WITH ERROR: ' + ERROR_MESSAGE();
	END CATCH
END

