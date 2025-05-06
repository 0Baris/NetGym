CREATE TABLE Roles (
    RoleId INT IDENTITY(1,1) NOT NULL,
    RoleName NVARCHAR(50) NOT NULL,
    Description NVARCHAR(255)
);

CREATE TABLE Users (
    UserId INT IDENTITY(1,1) NOT NULL,
    Email NVARCHAR(100) NOT NULL,
    FirstName NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50) NOT NULL,
    PhoneNumber NVARCHAR(20),
    PasswordHash VARBINARY(500) NOT NULL,
    PasswordSalt VARBINARY(500) NOT NULL,
    CreatedAt DATETIME2 DEFAULT GETDATE(),
    Status BIT
);

CREATE TABLE UserRoles (
    Id INT PRIMARY KEY IDENTITY(1,1),
    UserId INT NOT NULL,
    RoleId INT NOT NULL,
);

CREATE TABLE Members (
    MemberId INT IDENTITY(1,1),
    UserId INT NOT NULL,
    IdentityNumber NVARCHAR(11) NOT NULL UNIQUE,
    BirthDate DATE,
    Gender CHAR(1),
    RegistrationDate DATETIME2 DEFAULT GETDATE(),
    Notes NVARCHAR(MAX)
);

CREATE TABLE Packages (
    PackageId INT IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL,
    Description NVARCHAR(255),
    DurationDays INT NOT NULL,
    Price DECIMAL(10,2) NOT NULL,
    IsActive BIT DEFAULT 1
);

CREATE TABLE Subscriptions (
    SubscriptionId INT IDENTITY(1,1),
    MemberId INT NOT NULL,
    PackageId INT NOT NULL,
    StartDate DATETIME2 NOT NULL,
    EndDate DATETIME2 NOT NULL,
    AutoRenew BIT DEFAULT 0,
    Status NVARCHAR(20)
);

CREATE TABLE Payments (
    PaymentId INT IDENTITY(1,1),
    SubscriptionId INT NOT NULL,
    Amount DECIMAL(10,2) NOT NULL,
    PaymentDate DATETIME2 DEFAULT GETDATE(),
    PaymentMethod NVARCHAR(50),
    TransactionId NVARCHAR(100),
    Status NVARCHAR(20)
);

CREATE TABLE Dealers (
    DealerId INT IDENTITY(1,1),
    UserId INT NOT NULL,
    CompanyName NVARCHAR(100) NOT NULL,
    TaxNumber NVARCHAR(50),
    CommissionRate DECIMAL(5,2) DEFAULT 10.00,
    Region NVARCHAR(100),
    ContractStartDate DATE NOT NULL
);

CREATE TABLE DealerMembers (
    Id INT IDENTITY(1,1),
    DealerId INT NOT NULL,
    MemberId INT NOT NULL,
    RegistrationDate DATETIME2 DEFAULT GETDATE()
);

CREATE TABLE Equipment (
    EquipmentId INT IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL,
    PurchaseDate DATE,
    MaintenanceInterval INT,
    LastMaintenanceDate DATE,
    DealerId INT NOT NULL
);

CREATE TABLE Trainers (
    TrainerId INT IDENTITY(1,1),
    UserId INT NOT NULL,
    DealerId INT NOT NULL,
    Specialization NVARCHAR(100),
    CertificationNumber NVARCHAR(50),
    HourlyRate DECIMAL(10,2),
    Bio NVARCHAR(MAX),
    IsActive BIT DEFAULT 1
);

CREATE TABLE Campaigns (
    CampaignId INT IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL,
    Description NVARCHAR(MAX),
    StartDate DATETIME2 NOT NULL,
    EndDate DATETIME2 NOT NULL,
    TargetDealerId INT NULL,
    DiscountPercentage DECIMAL(5,2),
    IsActive BIT DEFAULT 1
);

CREATE TABLE MemberCampaigns (
    Id INT IDENTITY(1,1),
    CampaignId INT NOT NULL,
    MemberId INT NOT NULL,
    RedeemedDate DATETIME2,
    DiscountApplied DECIMAL(10,2)
);
GO
