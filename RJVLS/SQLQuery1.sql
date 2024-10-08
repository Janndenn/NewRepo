create database projectRJVLS;
use projectRJVLS;
create table Major(
majorID int not null primary key,
MajorName nvarchar(50));
select * from Major;

create table class(
classID int not null primary key,
classname nvarchar(50),
majorID int foreign key references major(majorID));

create table student(
STDID nvarchar (15) primary key,
FName nvarchar (30),
LName nvarchar (30),
Gender nvarchar (5),
Borndate date,
Mobile nvarchar(15),
classID int foreign key references class(classID)
);
drop table student;


create table years(
YearID int not null primary key,
Years nvarchar (10)
);
select * from years;
create table register(
registerID int not  null primary key,
STDID nvarchar (15) foreign key references student(STDID),
YearID int foreign key references years(YearID)
);
drop table register;
select*from Major;