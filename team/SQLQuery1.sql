create database team;
use team;
create table employee
(
Emid char (20) primary key,
Gender nvarchar(7),
Emname nvarchar(40),
Emsurname nvarchar(40),
DOB date,
Emstatus nvarchar (20),
Province nvarchar (50),
District nvarchar (50),
Village nvarchar (50),
Email varchar(60),
Tel char (15),
Position nvarchar(30),
Hiredate date,
picture image
);

create table customer(
Cusid char (20) primary key,
Gender nvarchar (7),
Cusname nvarchar (40),
Cussurname nvarchar (40),
DOB date,
Province nvarchar (50),
District nvarchar (50),
Village nvarchar (50),
Tel char (15)
);

create table product(
ProductID char (20) primary key,
Category nvarchar (30),
Productname nvarchar (50),
Size char (20),
Price char (20),
Pic image
);
drop table product;

create table supplier(
Supplierid char (20) primary key,
Companyname nvarchar (30),
Tel char (15),
Email varchar (60),
SupAddress nvarchar(70)
);

create table orderingitem(
Orderid char (20) primary key,
Companyname nvarchar (50),
Productname nvarchar (50),
category nvarchar (30),
Size char (20),
Quantity int,
Dateoforder date
);
drop table orderingitem;

create table selling
(
Sellid char (20) primary key,
Emid char (20) foreign key references employee(Emid),
Cusid char (20) foreign key references customer(Cusid),
Productid char (20)foreign key references product(Productid),
Productname nvarchar (50),
Size nvarchar (20),
Quantity int,
Price char (20),
Totalprice char (20)
);

use team;

drop table selling;
select * from selling;

create table importitem(
Importid char (20) primary key,
Orderid char (20) foreign key references orderingitem(Orderid),
Productname nvarchar (20),
Quantity int,
Price char(20),
Totalprice char(20),
Dateofimport date,
);
drop table importitem;

use team;
create table userder(
id char (20) primary key,
cosname nvarchar(15),
surname nvarchar (15),
position nvarchar (30),
users nvarchar (50),
pass varchar (50)
);
select * from userder;
 
 use team;
 create table stock(
 stockid char (20) primary key,
 Importid char (20) foreign key references importitem(Importid),
 Productid char (20) foreign key references product(Productid),
 Productname nvarchar (30),
 siz nvarchar (20),
 Quantity nvarchar (20),
 Sellid char (20) foreign key references selling(Sellid)
 );
 drop table stock;