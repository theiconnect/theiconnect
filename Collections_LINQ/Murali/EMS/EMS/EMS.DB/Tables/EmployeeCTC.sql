CREATE TABLE EmployeeCTC (
    EmployeeCTCPk INT IDENTITY(1,1) PRIMARY KEY,
    EmployeeIdFk INT NOT NULL,
    SalaryCTC DECIMAL(10,2) NOT NULL,
    EffectiveFrom DATETIME NOT NULL,
    EndDate DATETIME NULL,

    CONSTRAINT FK_EmployeeCTC_Employee
        FOREIGN KEY (EmployeeIdFk)
        REFERENCES Employee(EmployeeIdPk)
);

