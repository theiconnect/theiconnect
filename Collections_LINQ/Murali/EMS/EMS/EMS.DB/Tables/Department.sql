CREATE TABLE [dbo].[Department] (
    [DepartmentIdPk] INT           IDENTITY (1, 1) NOT NULL,
    [DepartmentCode] VARCHAR (50)  NOT NULL,
    [DepartmentName] VARCHAR (512) NOT NULL,
    [DeptLocation]   VARCHAR (512) NULL,
    [IsActive]       BIT           DEFAULT ((1)) NOT NULL,
    [CompanyIdFk]    INT           NOT NULL,
    [CreatedBy]      VARCHAR (512) NOT NULL,
    [CreatedOn]      DATETIME      DEFAULT (getdate()) NULL,
    [LastUpdatedBy]  VARCHAR (512) NULL,
    [LastUpdatedOn]  DATETIME      NULL,
    PRIMARY KEY CLUSTERED ([DepartmentIdPk] ASC)
);

