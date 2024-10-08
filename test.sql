create database vhan;
use vhan;
CREATE TABLE Persons
(
PersonID int not null,
LastName varchar(255),
FirstName varchar(255),
Addresss varchar(255),
City varchar(255)
);
select * FROM persons;
ALter table Persons add birthday date;

insert into Persons(PersonID,LastName,FirstName,Addresss,City) 
values(1,'chan','den','sdfgf','dfghj'),
(2,'çhan','chanden','sdf','sdfg');
update Persons set LastName= 'M' where FirstName='den';

CREATE TABLE Persones (
    ID int NOT NULL,
    LastName varchar(255) NOT NULL,
    FirstName varchar(255),
    Age int,
    CONSTRAINT PK_Person PRIMARY KEY (ID,LastName)
);

alter table Persons add primary key(PersonID);

alter table Persons drop column birthday;

alter table Persons add birthday date after FirstName;

"CREATE TRIGGER TRIG01 ON table1
   BEFORE INSERT
   REFERENCING NEW COL1 AS NEW_COL1
BEGIN
   EXEC SQL PREPARE CUR1
   INSERT INTO T2 VALUES (?);
   EXEC SQL EXECUTE CUR1 USING (NEW_COL1);
   EXEC SQL CLOSE CUR1;
   EXEC SQL DROP CUR1;
END"
CREATE TABLE Per (
    ID int NOT NULL,
    LastName varchar(255) NOT NULL,
    FirstName varchar(255),
    Age int CHECK (Age>=18)
);
insert into Per values(2,'chaan','fen',19);

/*CREATE TABLE Orders (
    OrderID int NOT NULL,
    OrderNumber int NOT NULL,
    PersonID int
);*/



create database testest;
use testest;
create table customer(
CustomerID int primary key not null,
CustomerName nvarchar (50),
ContactName nvarchar (50),
Addresss char (15),
City nvarchar (50),
PostalCode char (10),
Country nvarchar (40)
);
insert into customer (CustomerID,CustomerName,ContactName,Addresss,City,PostalCode,Country)
values (1,	'Alfreds Futterkiste', '	Maria Anders',	'Obere Str. 57','Berlin',12209,	'Germany');
insert into customer (CustomerID,CustomerName,ContactName,Addresss,City,PostalCode,Country)
values (2,'Ana Trujillo Emparedados y helados',	'Ana Trujillo','Avdade2222',	'México', 'D.F.	05021',	'Mexico'),
(3,'Around the Horn','Thomas Hardy','120 Hanover Sq.','London',	'WA1 1DP','UK'),
(4,	'Beverages', 'Victoria Ashworth','cc','London' ,'EC2 5NT',	'UK');
select * from customer;

create table shipper(
ShipperID int primary key not null,
ShipperName nvarchar (50),
Phone char(15));
select * from shipper;

insert into shipper(ShipperID,ShipperName,Phone)
values(1,'Speedy Express','+503 5559831'),
(2, 'United Package','+503 5553199'),
(3,	'Federal Shipping',	'+503 5559931');

create table orders(
orderID int primary key not null,
CustomerID int foreign key references customer(CustomerID),
orderdate date,
ShipperID int foreign key references shipper(ShipperID)
);
insert into orders(orderID, CustomerID,orderdate,ShipperID) 
values(10248,	1,	'1996-07-04',	3),
(10249,	2,	'1996-07-05',	1);