use master 
create database company

CREATE TABLE Employee(
EmployeeIdPk INT PRIMARY KEY,
FirstName VARCHAR(128),
LastName VARCHAR(256),
DateOfBirth DATE,
Esalary decimal(10,3),
)

select * from Employee

insert into Employee (EmployeeIdPk,FirstName,LastName,DateOfBirth,Esalary) values 
(101,'gangishetty','Saketh Sai','2003-07-02',10000.000),
(102,'pairala','sathish','2001-11-18',10000.000),
(103,'m','thrisha','2004-08-14',10000.000),
(104,'m','balu','2003-11-26',10000.000),
(105,'sai','prasad','2004-01-07',10000.000);


select Esalary
From Employee
where EmployeeIdPk >= 101
group by Esalary 
having min(Esalary) >= 10000
order by Esalary

update Employee set Esalary = 15000.000 where EmployeeIdPk = 102
update Employee set Esalary = 12000.000 where EmployeeIdPk = 103
update Employee set Esalary = 12500.000 where EmployeeIdPk = 104
update Employee set Esalary = 9000.000  where EmployeeIdPk = 105



