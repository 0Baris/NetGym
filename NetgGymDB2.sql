-- Kullanıcı Yönetimi
CREATE TABLE Roles (
    RoleId INT PRIMARY KEY IDENTITY(1,1),
    RoleName NVARCHAR(50) NOT NULL,
    Description NVARCHAR(255)
);

CREATE TABLE Users (
    UserId UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    Email NVARCHAR(100) NOT NULL UNIQUE,
    PasswordHash NVARCHAR(255) NOT NULL,
    FirstName NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50) NOT NULL,
    PhoneNumber NVARCHAR(20),
    CreatedAt DATETIME2 DEFAULT GETDATE(),
    IsActive BIT DEFAULT 1
);

CREATE TABLE UserRoles (
    UserId UNIQUEIDENTIFIER FOREIGN KEY REFERENCES Users(UserId),
    RoleId INT FOREIGN KEY REFERENCES Roles(RoleId),
    PRIMARY KEY (UserId, RoleId)
);

-- Üyelik Sistemi
CREATE TABLE Members (
    MemberId UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    UserId UNIQUEIDENTIFIER FOREIGN KEY REFERENCES Users(UserId),
    IdentityNumber NVARCHAR(11) NOT NULL UNIQUE,
    BirthDate DATE,
    Gender CHAR(1),
    RegistrationDate DATETIME2 DEFAULT GETDATE(),
    Notes NVARCHAR(MAX)
);

CREATE TABLE MemberMeasurements (
    MeasurementId INT PRIMARY KEY IDENTITY(1,1),
    MemberId UNIQUEIDENTIFIER FOREIGN KEY REFERENCES Members(MemberId),
    MeasurementDate DATETIME2 DEFAULT GETDATE(),
    Weight DECIMAL(5,2),
    Height DECIMAL(5,2),
    BodyFatPercentage DECIMAL(5,2),
    MuscleMass DECIMAL(5,2),
    CustomFields NVARCHAR(MAX)
);

-- Paket ve Ödeme
CREATE TABLE Packages (
    PackageId INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL,
    Description NVARCHAR(255),
    DurationDays INT NOT NULL,
    Price DECIMAL(10,2) NOT NULL,
    IsActive BIT DEFAULT 1
);

CREATE TABLE Subscriptions (
    SubscriptionId UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    MemberId UNIQUEIDENTIFIER FOREIGN KEY REFERENCES Members(MemberId),
    PackageId INT FOREIGN KEY REFERENCES Packages(PackageId),
    StartDate DATETIME2 NOT NULL,
    EndDate DATETIME2 NOT NULL,
    AutoRenew BIT DEFAULT 0,
    Status NVARCHAR(20) CHECK (Status IN ('Active', 'Expired', 'Cancelled'))
);

CREATE TABLE Payments (
    PaymentId UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    SubscriptionId UNIQUEIDENTIFIER FOREIGN KEY REFERENCES Subscriptions(SubscriptionId),
    Amount DECIMAL(10,2) NOT NULL,
    PaymentDate DATETIME2 DEFAULT GETDATE(),
    PaymentMethod NVARCHAR(50),
    TransactionId NVARCHAR(100),
    Status NVARCHAR(20) CHECK (Status IN ('Pending', 'Completed', 'Failed', 'Refunded'))
);

-- Bayi Yönetimi
CREATE TABLE Dealers (
    DealerId UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    UserId UNIQUEIDENTIFIER FOREIGN KEY REFERENCES Users(UserId),
    CompanyName NVARCHAR(100) NOT NULL,
    TaxNumber NVARCHAR(50),
    CommissionRate DECIMAL(5,2) DEFAULT 10.00,
    Region NVARCHAR(100),
    ContractStartDate DATE NOT NULL
);

CREATE TABLE DealerMembers (
    Id INT PRIMARY KEY IDENTITY(1,1),
    DealerId UNIQUEIDENTIFIER FOREIGN KEY REFERENCES Dealers(DealerId),
    MemberId UNIQUEIDENTIFIER FOREIGN KEY REFERENCES Members(MemberId),
    RegistrationDate DATETIME2 DEFAULT GETDATE()
);

-- Ekipman Yönetimi
CREATE TABLE Equipment (
    EquipmentId INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL,
    PurchaseDate DATE,
    MaintenanceInterval INT,
    LastMaintenanceDate DATE,
    DealerId UNIQUEIDENTIFIER FOREIGN KEY REFERENCES Dealers(DealerId)
);

-- Personel Trainer
CREATE TABLE Trainers (
    TrainerId UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    UserId UNIQUEIDENTIFIER FOREIGN KEY REFERENCES Users(UserId),
    Specialization NVARCHAR(100),
    CertificationNumber NVARCHAR(50),
    HourlyRate DECIMAL(10,2),
    Bio NVARCHAR(MAX),
    IsActive BIT DEFAULT 1,
    DealerId UNIQUEIDENTIFIER FOREIGN KEY REFERENCES Dealers(DealerId)
);

CREATE TABLE TrainerSchedules (
    ScheduleId UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    TrainerId UNIQUEIDENTIFIER FOREIGN KEY REFERENCES Trainers(TrainerId),
    DayOfWeek TINYINT CHECK (DayOfWeek BETWEEN 1 AND 7),
    StartTime TIME NOT NULL,
    EndTime TIME NOT NULL,
    IsRecurring BIT DEFAULT 1
);

CREATE TABLE TrainerAssignments (
    AssignmentId UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    TrainerId UNIQUEIDENTIFIER FOREIGN KEY REFERENCES Trainers(TrainerId),
    MemberId UNIQUEIDENTIFIER FOREIGN KEY REFERENCES Members(MemberId),
    StartDate DATE NOT NULL,
    EndDate DATE,
    SessionCount INT,
    Notes NVARCHAR(MAX)
);

-- Salon Erişim ve Kapasite
CREATE TABLE GymAccessLogs (
    LogId UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    MemberId UNIQUEIDENTIFIER FOREIGN KEY REFERENCES Members(MemberId),
    DealerId UNIQUEIDENTIFIER FOREIGN KEY REFERENCES Dealers(DealerId),
    CheckInTime DATETIME2 NOT NULL DEFAULT GETDATE(),
    CheckOutTime DATETIME2,
    TrainerId UNIQUEIDENTIFIER NULL FOREIGN KEY REFERENCES Trainers(TrainerId),
    AccessType NVARCHAR(20) CHECK (AccessType IN ('Normal', 'PT Session', 'Group Class', 'Guest')),
    DurationMinutes AS DATEDIFF(MINUTE, CheckInTime, ISNULL(CheckOutTime, GETDATE()))
);

CREATE TABLE GymCapacity (
    CapacityId INT PRIMARY KEY IDENTITY(1,1),
    DealerId UNIQUEIDENTIFIER FOREIGN KEY REFERENCES Dealers(DealerId),
    LogDate DATE NOT NULL,
    HourlySlot TINYINT NOT NULL CHECK (HourlySlot BETWEEN 0 AND 23),
    CurrentCount INT NOT NULL DEFAULT 0,
    MaxCapacity INT NOT NULL
);

-- Kampanya Yönetimi
CREATE TABLE Campaigns (
    CampaignId UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    Name NVARCHAR(100) NOT NULL,
    Description NVARCHAR(MAX),
    StartDate DATETIME2 NOT NULL,
    EndDate DATETIME2 NOT NULL,
    TargetDealerId UNIQUEIDENTIFIER NULL FOREIGN KEY REFERENCES Dealers(DealerId),
    DiscountPercentage DECIMAL(5,2),
    IsActive BIT DEFAULT 1
);

CREATE TABLE MemberCampaigns (
    Id INT PRIMARY KEY IDENTITY(1,1),
    CampaignId UNIQUEIDENTIFIER FOREIGN KEY REFERENCES Campaigns(CampaignId),
    MemberId UNIQUEIDENTIFIER FOREIGN KEY REFERENCES Members(MemberId),
    RedeemedDate DATETIME2,
    DiscountApplied DECIMAL(10,2)
);