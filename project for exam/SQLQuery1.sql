create database infor;
use infor;
create table Information(
inf_ID int primary key not null,
inf_Name nvarchar (30),
inf_Surname nvarchar (30),
inf_village nvarchar (30),
inf_Disrict nvarchar (30),
inf_province nvarchar (30)
);
select * from Information;
insert into information values(01,N'ຈັນເດັ່ນ', N'ເອງ', N'ຕາຣາມ', N'ກຳປົງສວາຍ', N'ກຳປົງທົມ');
insert into information values(02, 'chanden', 'Eng', 'Taream', 'kompong svay', 'kompong thom');