create database testthesis;
use testthesis;
create table producttype
(
typeid char (20) primary key,
typename nvarchar (20)
);
insert into producttype values(1,'foam');
insert into producttype values(2,'suncream');
select * from producttype;
drop table producttype;

create table brand(
brandid char(20) primary key,
brandname nvarchar (20)
);
insert into brand values(1,'etude');
insert into brand values(2,'Ganier');

create table supplier(
supid int primary key,
supname nvarchar (30),
village nvarchar (30),
district nvarchar (30),
province nvarchar (30),
country nvarchar (30),
tel char (20),
email varchar (50)
);
insert into supplier values(1,'chan', 'ban', 'taa', 'kpt', 'cambodia', 12334,'chan@gamilafh'); 

create table product
(
proid int primary key,
proname nvarchar (30),
ddesc nvarchar (40),
supid int foreign key references supplier(supid),
supname nvarchar (30),
typeid char(20) foreign key references producttype(typeid),
typename nvarchar(30),
brandid char(20) foreign key references brand(brandid),
brandname nvarchar (30),
jamnoun nvarchar (20),
unit nvarchar (20),
imprice nvarchar (20),
saleprice nvarchar (20),
totalprice nvarchar (30),
);
select * from product;
drop table product;

create table employee
(
emid int primary key,
gender nvarchar (10),
emname nvarchar (20),
emsurname nvarchar (20),
birthday date,
age int,
village nvarchar (20),
district nvarchar (20),
province nvarchar (20),
tel char (20),
email varchar (20),
datehire date,
pass char (20),
pic image,
);
select * from employee;
create table paymenttype
(
pmtypeid int primary key,
namepm nvarchar (30));

create table exchange
(
exid int primary key,
currency nvarchar (30),
exchange int
);
select * from exchange;

create table customer
(
cusid int primary key,
gender nvarchar (20),
cusname nvarchar (30),
cussurname nvarchar (30),
birthday date,
age int,
vilage nvarchar (30),
district nvarchar (30),
province nvarchar (30),
tel char (20)
);
select * from customer;

select * from employee;

create table orderr
(
orderid int primary key,
dateoder date,
emid int foreign key references employee(emid),
proid int foreign key references product(proid),
proname nvarchar (30),
ddesc nvarchar (40),
supname nvarchar(30),
typename nvarchar(30),
brandname nvarchar (30),
orderqty nvarchar (20),
unit nvarchar(20),
orderprice nvarchar (20),
totalprice nvarchar (20),
finalprice nvarchar (20),
);
drop table orderr;
select * from orderr;

CREATE TABLE saledetial (
    saleid INT PRIMARY KEY,
    saledate DATETIME,
    emid INT,
    cusid INT,
    cusname NVARCHAR(100),
    grandtotal DECIMAL(18, 2)
);

CREATE TABLE sale (
    saleid INT PRIMARY KEY,
	saledate DATETIME,
    emid INT,
    cusid INT,
    cusname NVARCHAR(100),
    proid INT,
    proname NVARCHAR(100),
    unitprice int,
    discount int,
    amount int,
    saleqty INT,
    totalprice int,
	grandtotal int,
    paymenttype NVARCHAR(50),
    currency NVARCHAR(50),
);
select * from saledetial;
select * from sale;

drop table sale;

create table payment
(
paymentid int primary key,
saleid int foreign key references sale(saleid),
proid int foreign key references product(proid),
proname nvarchar(30),
qty int,
price int,
totalprice int,
);
drop table payment;
create table userr(
userid int primary key,
namee nvarchar(30),
surname nvarchar(30),
userr nvarchar(30),
pass char (20)
);
select * from userr;
select * from employee;
use testthesis;

create table import
(
imid int primary key,
imdate date,
emid int foreign key references employee(emid),
orderid int foreign key references orderr(orderid),
dateoder date,
proid int foreign key references product(proid),
proname nvarchar (30),
ddesc nvarchar (30),
supname nvarchar(30),
typename nvarchar(30),
brandname nvarchar (30),
orderqty nvarchar (20),
unit nvarchar(20),
orderprice nvarchar (20),
totalprice nvarchar (20),
);
select * from import;
drop table import;
create table problem
(
problemid int primary key,
emid int foreign key references employee(emid),
datepro date,
saleid int foreign key references sale(saleid),
proid int foreign key references product(proid),
proname nvarchar (30),
qty int,
price int,
totalprice int
);
drop table problem;
create table userr
(
userid int primary key,
namee varchar (30),
surname varchar (30),
userr varchar (30),
pass char(20)
);
select * from userr;
