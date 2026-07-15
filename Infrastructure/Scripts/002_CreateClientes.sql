USE ScoreAPIClient;
GO

IF OBJECT_ID('dbo.Clients', 'U') IS NOT NULL
BEGIN
    DROP TABLE dbo.Clients;
END;
GO

CREATE TABLE dbo.Clients
(
    Id UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,

    Name NVARCHAR(150) NULL,

    Email NVARCHAR(150) NULL,

    BirthDate DATE NULL,

    CPF CHAR(11) NOT NULL,

    AnnualIncome DECIMAL(18,2) NOT NULL,

    AreaCode CHAR(2) NOT NULL,

    PhoneNumber VARCHAR(20) NOT NULL,

    Street NVARCHAR(200) NULL,

    AddressNumber NVARCHAR(20) NULL,

    AddressComplement NVARCHAR(150) NULL,

    ZipCode CHAR(8) NULL,

    State CHAR(2) NOT NULL,

    CreatedAt DATETIME2 NOT NULL
        DEFAULT(GETDATE())
);
GO

CREATE UNIQUE INDEX UX_Clients_CPF
ON dbo.Clients(CPF);
GO
