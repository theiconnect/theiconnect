CREATE TABLE Designation (
    DesignationIdPk INT IDENTITY(1,1) PRIMARY KEY,
    DesignationName VARCHAR(100) NOT NULL UNIQUE
);
