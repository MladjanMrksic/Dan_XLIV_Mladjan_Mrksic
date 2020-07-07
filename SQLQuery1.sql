IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'FoodOrderAppBase')
CREATE DATABASE FoodOrderAppBase
GO

USE FoodOrderAppBase
GO

IF EXISTS (SELECT name FROM sys.sysobjects WHERE name = 'FoodOrder')
drop table FoodOrder

IF EXISTS (SELECT name FROM sys.sysobjects WHERE name = 'FoodCustomer')
drop table FoodCustomer

create table FoodCustomer
(
CustomerID int primary key identity(1,1),
FirstName nvarchar(50) not null,
LastName nvarchar(50) not null,
JMBG nvarchar(13) Check (LEN(JMBG) = 13 and ISNUMERIC(JMBG) = 1) not null
)
create table FoodOrder
(
OrderID int primary key identity(1,1),
CustomerID int foreign key references FoodCustomer(CustomerID) not null,
Price decimal (6,2) not null,
StatusOfOrder nvarchar Check (UPPER(StatusOfOrder) = 'PROCESSING' or UPPER(StatusOfOrder) = 'READY' or UPPER(StatusOfOrder) = 'REJECTED') not null
)

