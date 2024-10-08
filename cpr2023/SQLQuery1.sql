use salary_cpr2023;
drop database salary_cpr2023;

create database salary_cpr2023;
use salary_cpr2023;
create table department
(
dep_id int primary key identity (1,1),
dep_name nvarchar (35));

insert into department values(N'????? IT');
select * from department;

create table position
(
po_id int primary key identity (1,1),
po_name nvarchar (20));

insert into position values(N'?????'), (N'????????');
select * from position;

create table qualification
(
q_id int primary key identity (1,1),
q_name nvarchar (20));

insert into qualification values(N'? ??'), (N'? ???');
insert into qualification values(N'? ??');
select * from qualification;

create table staff
(
st_id char(5) primary key,
gender nvarchar(15),
st_name nvarchar(15),
surname nvarchar(15),
birthday date,
village nvarchar (20),
district nvarchar (20),
province nvarchar (20),
tel varchar(15),
mail varchar(100),
facebook varchar (100),
department nvarchar(30),
position nvarchar(30),
qualification nvarchar(30),
pic image
);
drop table staff;

create table salary(
bs_id int primary key,
qualification nvarchar(30),
position nvarchar (30),
department nvarchar (30),
amount nvarchar(30));
select * from salary;
drop table salary;

use salary_cpr2023;

create table staffder(
st_id char(10) primary key,
gender nvarchar(10),
stname nvarchar(20),
surname nvarchar(20),
birthday date,
village nvarchar(25),
district nvarchar(25),
province nvarchar(20),
tel varchar(15),
mail varchar(60),
facebook nvarchar (60),
department nvarchar(30),
position nvarchar(30),
qualification nvarchar(30),
pic image
);

select * from staffder;
DELETE FROM staff WHERE st_name= 'Mos';
insert into staffder
use salary_cpr2023;

create table userder(
id int primary key identity(1,1),
cosname nvarchar(15),
surname nvarchar (15),
position nvarchar (30),
users nvarchar (50),
pass varchar (50)
);
select * from userder;
drop table userder;
