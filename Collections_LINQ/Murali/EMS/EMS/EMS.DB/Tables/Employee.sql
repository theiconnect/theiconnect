CREATE TABLE EMPLOYEE(
	EmployeeIdPk INT PRIMARY KEY IDENTITY(1,1),
	EmployeeCode VARCHAR(20) UNIQUE,
	FirstName VARCHAR(128),
	MiddleName VARCHAR(128),
	LastName VARCHAR(128),
	BloodGroupIdFk int ,
	GenderIdFk int ,
	EmailId VARCHAR(256),
	PersonalEmailId VARCHAR(256),
	MobileNumber CHAR(10),
	AlternateMobileNumber CHAR(10),
	DepartmentIdFk INT,
	DateOfBirth Date,
	DateOfJoining Date,
	ExpInMonths Int,
	QualificationIdFk int,
	DesignationIdFk int,
	SalaryCTc Decimal(10,2),
	IsActive BIT,
	LWD Date,
	[CreatedBy]      VARCHAR (512) NOT NULL,
    [CreatedOn]      DATETIME      DEFAULT (getdate()) NULL,
    [LastUpdatedBy]  VARCHAR (512) NULL,
    [LastUpdatedOn]  DATETIME      NULL,
	CONSTRAINT fk_DepartmentIdFk FOREIGN KEY (DepartmentIdFk)
		REFERENCES DEPARTMENT(DepartmentIdPk),	

	CONSTRAINT fk_GenderIdFk FOREIGN KEY (GenderIdFk)
		REFERENCES Gender(GenderIdPk),
	
	CONSTRAINT fk_BloodGroupIdFk FOREIGN KEY (BloodGroupIdFk)
		REFERENCES BloodGroup(BloodGroupIdPk),

	CONSTRAINT fk_QualificationIdFk FOREIGN KEY (QualificationIdFk)
		REFERENCES Qualification(QualificationIdPk),

	CONSTRAINT fk_DesignationIdFk FOREIGN KEY (DesignationIdFk)
		REFERENCES Designation(DesignationIdPk)
)
