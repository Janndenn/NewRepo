create database pos_dshop;

use pos_dshop;

create table category (
cate_id int primary key not null identity,
cate_name nvarchar(255)
);

create table brand (
brand_id int primary key not null identity,
brand_name nvarchar(255)
);

create table unit (
unit_id int primary key not null identity,
unit_name nvarchar(255)
);

create table product (
product_id int primary key not null identity,
code varchar(50),
cate_id int,
brand_id int,
unit_id int,
pro_name nvarchar(255),
qty int,
price float,
img image null,
detail nvarchar(255) null,
FOREIGN KEY (cate_id) REFERENCES category(cate_id),
FOREIGN KEY (brand_id) REFERENCES brand(brand_id),
FOREIGN KEY (unit_id) REFERENCES unit(unit_id)
);

create table customer (
cus_id int primary key not null identity,
cus_type nvarchar(50),
cus_name nvarchar(255),
phone nvarchar(50),
buy_total float,
dis_percent int
);

create table employee (
emp_id int primary key not null identity,
emp_name nvarchar(255),
phone nvarchar(50),
email nvarchar(255) not null,
address nvarchar(255) null,
detail nvarchar(255) null,
img image null,
username nvarchar(50),
password nvarchar(50),
);

create table exchange (
ex_id int primary key not null identity,
ex_name nvarchar(255),
ex_rate int
);

create table sale (
sale_id int primary key not null identity,
valuedt date,
code varchar(50),
total float,
dis_percent int,
discount float,
result float,
ex_id int,
ex_rate int,
cus_id int,
emp_id int,
FOREIGN KEY (ex_id) REFERENCES exchange(ex_id),
FOREIGN KEY (cus_id) REFERENCES customer(cus_id),
FOREIGN KEY (emp_id) REFERENCES employee(emp_id),
);



create table sale_detail (
sale_detail_id int primary key not null identity,
sale_ful_id varchar(50),
product_id int,
price float,
qty int,
total float,
FOREIGN KEY (product_id) REFERENCES product(product_id),
);

create table problem (
problem_id int primary key not null identity,
valuedt date,
code varchar(50),
product_id int,
qty int,
FOREIGN KEY (product_id) REFERENCES product(product_id),
);

create table payment_type (
pay_type_id int primary key not null identity,
pay_type_name nvarchar(255)
);

create table payment (
payment_id int primary key not null identity,
valuedt date,
code varchar(50),
emp_id int,
pay_type_id int,
FOREIGN KEY (emp_id) REFERENCES employee(emp_id),
FOREIGN KEY (pay_type_id) REFERENCES payment_type(pay_type_id),
);

create table supplier (
supplier_id int primary key not null identity,
supplier_name nvarchar(255),
phone nvarchar(50),
detail text null,
);

create table buy (
buy_id int primary key not null identity,
valuedt date,
code varchar(50),
emp_id int,
supplier_id int,
FOREIGN KEY (emp_id) REFERENCES employee(emp_id),
FOREIGN KEY (supplier_id) REFERENCES supplier(supplier_id),
);

create table buy_detail (
buy_detail_id int primary key not null identity,
buy_code varchar(50),
product_id int,
qty int,
FOREIGN KEY (product_id) REFERENCES product(product_id)
);

create table import (
import_id int primary key not null identity,
code varchar(50),
valuedt date,
ex_id int,
ex_rate int,
total float,
emp_id int,
FOREIGN KEY (emp_id) REFERENCES employee(emp_id),
FOREIGN KEY (ex_id) REFERENCES exchange(ex_id),
);

create table import_detail (
import_detail_id int primary key not null identity,
import_code varchar(50),
product_id int,
qty int,
total float,
FOREIGN KEY (product_id) REFERENCES product(product_id),
);

select * from customer;
insert into employee (emp_name,phone,email,address,detail,img,username,password) values('admin','00000000','admin@gmail.com',null,null,null,'admin','123456');

insert into customer (cus_type,cus_name,phone,buy_total,dis_percent) values('General',N'ລູກຄ້າທົ່ວໄປ','00000000',0,0);

insert into exchange (ex_name,ex_rate) values ('LAK',1), ('THB',700), ('USD',22000);