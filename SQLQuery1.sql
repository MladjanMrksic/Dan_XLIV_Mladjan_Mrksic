IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'FoodOrderAppBase')
CREATE DATABASE FoodOrderAppBase
GO

USE FoodOrderAppBase
GO

IF EXISTS (SELECT name FROM sys.sysobjects WHERE name = 'FoodOrder')
drop table FoodOrder

IF EXISTS (SELECT name FROM sys.sysobjects WHERE name = 'FoodCustomer')
drop table FoodCustomer

IF EXISTS (SELECT name FROM sys.sysobjects WHERE name = 'FoodMenu')
drop table FoodMenu

create table FoodCustomer
(
CustomerID int primary key identity(1,1) not null,
JMBG nvarchar(13) Check (LEN(JMBG) = 13 and ISNUMERIC(JMBG) = 1) not null
)
create table FoodOrder
(
OrderID int primary key identity(1,1) not null,
CustomerID int foreign key references FoodCustomer(CustomerID) not null,
Price decimal (6,2) not null,
StatusOfOrder nvarchar(50) Check (UPPER(StatusOfOrder) = 'PROCESSING' or UPPER(StatusOfOrder) = 'READY' or UPPER(StatusOfOrder) = 'REJECTED') not null
)

create table FoodMenu
(
MenuItemID int primary key identity(1,1) not null,
MenuItemName nvarchar(50) not null,
Price decimal (6,2) not null,
)

