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
 
INSERT INTO FoodCustomer (JMBG) VALUES ('1234567890123');
INSERT INTO FoodCustomer (JMBG) VALUES ('1122334455667');
INSERT INTO FoodCustomer (JMBG) VALUES ('3210987654321');

INSERT INTO FoodOrder (CustomerID, Price, StatusOfOrder) VALUES (1,350.00,'PROCESSING');
INSERT INTO FoodOrder (CustomerID, Price, StatusOfOrder) VALUES (2,250.50,'READY');
INSERT INTO FoodOrder (CustomerID, Price, StatusOfOrder) VALUES (3,400.00,'REJECTED');

INSERT INTO FoodMenu (MenuItemName, Price) VALUES ('Pepperoni Pizza', 200);
INSERT INTO FoodMenu (MenuItemName, Price) VALUES ('Capricciosa pizza', 150);
INSERT INTO FoodMenu (MenuItemName, Price) VALUES ('Margherita Pizza', 250.50	);