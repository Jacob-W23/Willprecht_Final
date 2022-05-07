USE [master]
GO

CREATE DATABASE [DMV]
GO
USE [DMV]
GO
SET QUOTED_IDENTIFIER ON
GO


-- Create/Populate Drivers Table --
CREATE TABLE Drivers (
  DriverID int NOT NULL IDENTITY(1,1) PRIMARY KEY,
  FirstName varchar(MAX) NOT NULL,
  LastName varchar(MAX) NOT NULL,
  SSN varchar(MAX) NOT NULL
)

INSERT INTO Drivers (FirstName, LastName, SSN) VALUES
('Dennis', 'Feltner', '517-40-4875'),
('Lillian', 'Anderson', '530-08-7784'),
('Anne', 'Thorpe', '537-18-9756'),
('Anthony', 'Young', '667-03-6234'),
('Gordon', 'Ellenburg', '242-67-8899'),
('Diane', 'Northcutt', '541-19-5716'),
('Patricia', 'Grubb', '536-70-7841'),
('Kyle', 'Crawford', '482-07-5977'),
('John', 'Atchison', '285-94-4545'),
('James', 'Nick', '028-22-0154');


-- Create/Populate Infractions Table --
CREATE TABLE Infractions (
  InfractionID int NOT NULL IDENTITY(1,1) PRIMARY KEY,
  InfractionType varchar(MAX) NOT NULL
)

INSERT INTO Infractions (InfractionType) VALUES
('Speeding'),
('Tailgating'),
('Littering'),
('Distracted Driving'),
('Parking Overtime'),
('DUI'),
('Seat belt violation'),
('Failing to stop'),
('Failing to signal'),
('Reckless driving');


-- Create/Populate DriverInfraction Table --
CREATE TABLE DriverInfractions (
  DriverInfractionID int NOT NULL IDENTITY(1,1) PRIMARY KEY,
  DriverID int NOT NULL,
  InfractionID int NOT NULL,
  FOREIGN KEY (DriverID) REFERENCES Drivers(DriverID),
  FOREIGN KEY (InfractionID) REFERENCES Infractions(InfractionID)
)

INSERT INTO DriverInfractions (DriverID, InfractionID) VALUES
(2, 5),
(4, 1),
(1, 10),
(6, 2),
(8, 7),
(3, 9),
(5, 10),
(10, 4),
(9, 9),
(7, 5);


-- Create/Populate Users Table --
CREATE TABLE Users (
  UserID int NOT NULL IDENTITY(1,1) PRIMARY KEY,
  FirstName varchar(MAX) NOT NULL,
  LastName varchar(MAX) NOT NULL,
  Username varchar(MAX) NOT NULL,
  Password varchar(MAX) NOT NULL,
  Role varchar(MAX) NOT NULL
)


INSERT INTO Users (FirstName, LastName, Username, Password, Role) VALUES
('Cynthia', 'Jones', 'CJones', 'Jones', 'DMV Personnel'),
('Geoffrey', 'Stanley', 'GStanley', 'Stanley', 'Law Enforcement'),
('James', 'Knowles', 'JKnowles', 'Knowles', 'Law Enforcement'),
('Gerald', 'Thurston', 'GThurston', 'Thurston', 'DMV Personnel'),
('Angelyn', 'Perry', 'APerry', 'Perry', 'Law Enforcement'),
('Jennifer', 'Coyle', 'JCoyle', 'Coyle', 'DMV Personnel'),
('Vera', 'Cola', 'VCola', 'Cola', 'DMV Personnel'),
('Charlie', 'Bryant', 'CBryant', 'Bryant', 'Law Enforcement'),
('Deena', 'Hargrove', 'DHargrove', 'Hargrove', 'Law Enforcement'),
('Jenifer', 'Johnson', 'JJohnson', 'Johnson', 'DMV Personnel');


-- Create/Populate Vehicles Table --
CREATE TABLE Vehicles (
  VehicleID int NOT NULL IDENTITY(1,1) PRIMARY KEY,
  DriverID int NOT NULL,
  VehicleMake varchar(MAX) NOT NULL,
  VehicleModel varchar(MAX) NOT NULL,
  VehicleYear varchar(MAX) NOT NULL,
  LicensePlateNumber varchar(MAX) NOT NULL,
  FOREIGN KEY (DriverID) REFERENCES Drivers(DriverID)
) 


INSERT INTO Vehicles (DriverID, VehicleMake, VehicleModel, VehicleYear, LicensePlateNumber) VALUES
(1, 'Toyota', 'Previa', '2008', '6BL591'),
(2, 'Daewoo', 'Lacetti', '2011', '356G03'),
(3, 'Ford', 'Laser', '2001', '792LS2'),
(4, 'Audi', 'S6', '2005', '6HH939'),
(5, 'Mercedes-Benz', 'CLK', '1998', '109LZT'),
(6, 'BMW', '320', '1999', 'JJN854'),
(7, 'Mercedes-Benz', 'S-Class', '2015', 'HJP508'),
(8, 'Lancia', 'Delta', '1993', '445XAX'),
(9, 'SsangYong', 'Korando', '2008', '768XUY'),
(10, 'Donkervoort', 'D8', '1993', 'GP8257');
