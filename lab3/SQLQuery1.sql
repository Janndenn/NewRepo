create database lab3;
use lab3;
create table product (
p_id char (15) primary key,
p_name nvarchar (30),
p_type nvarchar (30),
p_size char (10),
p_amount int,
p_price int,
p_total int,
p_expire date,
p_photo image
);