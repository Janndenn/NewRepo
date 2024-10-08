create database lab2;
use lab2;
create table classroomder(
c_id int primary key not null,
c_room char(10));
insert into classroomder values (1, '3cpr1');
select * from classroomder;

use lab2;
create table department(
d_id int primary key not null,
l_name nvarchar (21),
E_name char (15));
insert into department values(1, N'ຈັນເດັ່ນ', 'chanden');
select * from department;