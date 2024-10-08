create database class_mini;
use class_mini;
create table type (
t_id char (10) primary key,
name nvarchar(30)
);
create table product(
p_id char(10) primary key,
p_name nvarchar(30),
p_type char(10) foreign key references type(t_id),
amount int,
price int,
total int
);
insert into type values('D101', N'ເຄືອງດືມ');
insert into product values('P101','Pepsi','D101',5,5000,250000);
select * from type;
select * from product;

