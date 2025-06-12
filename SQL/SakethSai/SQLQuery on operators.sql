create table empolyee(
employeeidpk int primary key not null identity(1,1),
employeename varchar(128),
esalary decimal(10,2),
emailid varchar(256),
dateofbirth date,
mobileno char(10),
)

select * from empolyee


insert into empolyee (employeename,esalary,emailid,dateofbirth,mobileno)
values
('sai',100000.00,'sai@gmail.com','2003-07-02',1234567890),
('ram',200000.00,'ram@gmail.com','2003-02-18',9876543210),
('raju',250000.00,'raju@gmail.com','2003-01-01',9392587822)

select esalary,esalary-200000  as latestesalary from empolyee

alter table empolyee 
add  latestesalary  decimal(10,3)