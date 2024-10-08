create database thesiss;
use thesiss;
create table producttype
(
typeid int primary key,
typename nvarchar (30));
insert into producttype values(1,'can');
insert into producttype values(2,'ຊ່ອງ');
insert into producttype values(3,'foam');
drop table producttype;
select * from producttype;

create table brand
(
brandid int primary key,
brandname nvarchar (30));
drop table brand;
insert into brand values(1,'etude');
insert into brand values(2,'Ganier');

create table supplier
(supid int primary key,
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
typeid int foreign key references producttype(typeid),
brandid int foreign key references brand(brandid),
unit nvarchar (20),
jamnoun nvarchar (20),
imprice nvarchar (20),
saleprice nvarchar (20),
supid int foreign key references supplier(supid),
promo nvarchar (20),
numpro nvarchar (30),
totalprice nvarchar (30),
datepro date
);
drop table product;
use thesiss;
select * from product;

create table employee
(
emid int primary key,
gender nvarchar (10),
emname nvarchar (20),
emsurname nvarchar (20),
birthday date,
village nvarchar (20),
district nvarchar (20),
province nvarchar (20),
tel char (20),
email varchar (20),
datehire date,
pass char (20),
pic image,
);

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
create table orderr
(
orderid int primary key,
dateoder date,
emid int foreign key references employee(emid),
supid int foreign key references supplier(supid),
proid int foreign key references product(proid),
typeid int foreign key references producttype(typeid),
brandid int foreign key references brand(brandid),
orderunitn nvarchar (20),
orderprice nvarchar (20),
totalprice nvarchar (20),
finalprice nvarchar (20),
statuss nvarchar (50)
);
drop table orderr;
create table orderdetail(
orddid int primary key,
orderid int foreign key references orderr(orderid),
dateorder date,
supid int foreign key references supplier(supid),
statuss nvarchar (40)
);
drop table orderdetail;

create table import
(imid int primary key,
emid int foreign key references employee(emid),
orddid int foreign key references orderdetail(orddid),
supid int foreign key references supplier(supid),
dateofim date,
proid int foreign key references product(proid),
typeid int foreign key references producttype(typeid),
brandid int foreign key references brand(brandid),
importunit nvarchar (20),
orderprice nvarchar (20),
totalprice nvarchar (20),
finalprice nvarchar (20),
note nvarchar (30)
);
drop table import;

create table importdetail
(impdid int primary key,
imid int foreign key references import(imid),
dateim date,
supid int foreign key references supplier(supid)
);
drop table importdetail;

create table paymenttype
(
pmtypeid int primary key,
namepm nvarchar (30));

create table sale
(saleid int primary key,
emid int foreign key references employee(emid),
datesale date,
cusid int foreign key references customer(cusid),
proid int foreign key references product(proid),
jamnoun int,
price nvarchar (20),
totalprice nvarchar (20),
finalprice nvarchar (20),
pmtypeid int foreign key references paymenttype(pmtypeid),
exid int foreign key references exchange(exid)
);
drop table sale;
select * from sale;
create table saledetail
(
saledeid int primary key,
saleid int foreign key references sale(saleid),
datesale date,
cusid int foreign key references customer(cusid),
);
drop table saledetail;

create table problem
(
problemid int primary key,
emid int foreign key references employee(emid),
dateproblem date,
saleid int foreign  key references sale(saleid),
proid int foreign key references product(proid),
jamnoun int,
price nvarchar (20),
totalprice nvarchar (20),
finalprice nvarchar (20),
);
select * from problem;
drop table problem;

create table payment
(
paymentid int primary key,
saledeid int foreign key references saledetail(saledeid),
proid int foreign key references product(proid),
jamnoun int,
price nvarchar (20),
totalprice nvarchar (20),
pmtypeid int foreign key references paymenttype(pmtypeid),
exid int foreign key references exchange(exid)
);
drop table payment;

create table exchange
(
exid int primary key,
currency nvarchar (30),
exchange int
);
select* from exchange;
drop table exchange;