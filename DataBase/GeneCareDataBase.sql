USE master;
GO

IF EXISTS (SELECT name FROM sys.databases WHERE name = N'GeneCarePRN')
    DROP DATABASE GeneCarePRN;
GO

CREATE DATABASE GeneCarePRN;
GO

USE GeneCarePRN;
GO

-- Bảng Role
CREATE TABLE Role (
    RoleID INT PRIMARY KEY,
    RoleName NVARCHAR(100)
);

-- Bảng Users
CREATE TABLE Users (
    UserID INT PRIMARY KEY IDENTITY(1,1),
    RoleID INT NOT NULL FOREIGN KEY REFERENCES Role(RoleID),
    FullName NVARCHAR(150),
	IdentifyID INT,
    [Address] NVARCHAR(500),
    Email NVARCHAR(200) NOT NULL UNIQUE,
    Phone VARCHAR(20),
    [Password] NVARCHAR(100)
);







-- Bảng Service
CREATE TABLE [Service] (
    ServiceID INT PRIMARY KEY IDENTITY(1,1),
    ServiceName NVARCHAR(200),
    ServiceType NVARCHAR(100),
    [Description] NVARCHAR(MAX)
);

-- Bảng Duration
CREATE TABLE Duration (
    DurationID INT PRIMARY KEY IDENTITY(1,1),
    DurationName NVARCHAR(100),
    [Time] TIME
);

-- Bảng ServicePrice
CREATE TABLE ServicePrice (
    PriceID INT PRIMARY KEY IDENTITY(1,1),
    ServiceID INT FOREIGN KEY REFERENCES [Service](ServiceID),
    DurationID INT FOREIGN KEY REFERENCES Duration(DurationID),
    Price INT
);

-- Bảng CollectionMethod
CREATE TABLE CollectionMethod (
    MethodID INT PRIMARY KEY IDENTITY(1,1),
    MethodName NVARCHAR(100)
);


-- Bảng Status
CREATE TABLE [Status] (
    StatusID INT PRIMARY KEY IDENTITY(1,1),
    StatusName NVARCHAR(50)
);

-- Bảng TestResult
CREATE TABLE TestResult (
    ResultID INT PRIMARY KEY IDENTITY(1,1),
    [Date] DATETIME,
    ResultSummary NVARCHAR(MAX)
);

-- Bảng Booking
CREATE TABLE Booking (
    BookingID INT PRIMARY KEY IDENTITY(1,1),
    UserID INT FOREIGN KEY REFERENCES Users(UserID),
    DurationID INT FOREIGN KEY REFERENCES Duration(DurationID),
    ServiceID INT FOREIGN KEY REFERENCES [Service](ServiceID),
    MethodID INT FOREIGN KEY REFERENCES CollectionMethod(MethodID),
	ResultID INT FOREIGN KEY REFERENCES TestResult(ResultID),
    AppointmentTime DATETIME,
    StatusID INT FOREIGN KEY REFERENCES [Status](StatusID),
    [Date] DATETIME
);





-- Bảng Feedback
CREATE TABLE Feedback (
    FeedbackID INT PRIMARY KEY IDENTITY(1,1),
    UserID INT FOREIGN KEY REFERENCES Users(UserID) NOT NULL,
    ServiceID INT FOREIGN KEY REFERENCES [Service](ServiceID) NOT NULL,
    CreatedAt DATETIME NOT NULL,
    Comment NVARCHAR(MAX),
    Rating INT NOT NULL
);

-- Bảng Samples
CREATE TABLE Samples (
    SampleID INT PRIMARY KEY IDENTITY(1,1),
	SampleName NVARCHAR(200)
);

-- Bảng Patient
CREATE TABLE Patient (
    PatientID INT PRIMARY KEY IDENTITY(1,1), 
    BookingID  INT  NOT NULL FOREIGN KEY REFERENCES Booking(BookingID) ON DELETE CASCADE,
	SampleID INT FOREIGN KEY REFERENCES Samples(SampleID),
    FullName NVARCHAR(200) NOT NULL,
    BirthDate DATE NOT NULL,
    Gender NVARCHAR(10) NOT NULL, -- 'Nam', 'Nữ'
    IdentifyID NVARCHAR(50),
    HasTestedDNA BIT NOT NULL,
    Relationship NVARCHAR(100) -- Quan hệ với người còn lại trong cùng booking
);

-- Bảng Blog
CREATE TABLE Blog (
    BlogID INT PRIMARY KEY IDENTITY(1,1),
    UserID INT FOREIGN KEY REFERENCES Users(UserID),
    Title NVARCHAR(200),
    Content NVARCHAR(MAX),
    CreatedAt DATETIME
);



-------------------------------------------INSERT DATA---------------------------------------------------------------
INSERT INTO Role (RoleID, RoleName) VALUES
(1, N'Customer'),
(2, N'Staff'),
(3, N'Manage'),
(4, N'Admin');
go
INSERT INTO Users (RoleID,FullName,IdentifyID,Address,Email,Phone,Password)
VALUES 
(1, N'ThuanCustomer','090909',N'HCM',N't@cus','0909090','123'),
(2, N'ThuanStaff','090909',N'HCM',N't@sta','0909090','123'),
(3, N'ThuanManager','090909',N'HCM',N't@mana','0909090','123'),
(4, N'ThuanAdmin','090909',N'HCM',N't@ad','0909090','123');
go
INSERT INTO Service (ServiceName ,ServiceType)
VALUES 
(N'Dân sự', N'Cha/Mẹ-Con'),
(N'Dân sự', N'Anh/Chị-Em'),
(N'Dân sự', N'song sinh'),
(N'Dân sự', N'Cô/Chú-Cháu'),
(N'Dân sự', N'Dì/Cậu-Cháu'),
(N'Dân sự', N'Ông/Bà-Cháu'),

(N'Pháp lý', N'Cha/Mẹ-Con'),
(N'Pháp lý', N'Anh/Chị-Em'),
(N'Pháp lý', N'song sinh'),
(N'Pháp lý', N'Cô/Chú-Cháu'),
(N'Pháp lý', N'Dì/Cậu-Cháu'),
(N'Pháp lý', N'Ông/Bà-Cháu');
go
INSERT INTO Duration(DurationName )
VALUES
(N'Gói 6h'),
(N'Gói 24h'),
(N'Gói 48h');
go
INSERT INTO ServicePrice(ServiceID,DurationID,Price)
VALUES
(1,1,2500000),
(1,2,2000000),
(1,3,1500000),
(7,1,3500000),
(7,2,3000000),
(7,3,2500000);
go
INSERT INTO CollectionMethod (MethodName)
VALUES
(N'Tự thu mẫu tại nhà'),
(N'Thu mẫu tại nhà'),
(N'Thu mẫu tại cơ sở y tế');
go
INSERT INTO Status(StatusName)
VALUES
(N'Chưa thực hiện'),
(N'Đang thực hiện'),
(N'Hoàn thành'),
(N'Đã hủy');
go
INSERT INTO Samples(SampleName)
 VALUES
 (N'Máu'),
 (N'Móng tay/chân'),
 (N'Tóc'),
 (N'Niêm mạc miệng');
go

