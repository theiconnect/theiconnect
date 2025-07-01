-- Step-1:
-- Run below commands 1 by 1 line
USE MASTER
GO -- Use GO to separate batches
CREATE DATABASE SAMPLEDEMO
GO
USE SAMPLEDEMO
GO

-- Step-2 Run below script
BEGIN TRANSACTION;

DROP TABLE if exists EMP;
DROP TABLE if exists DEPT;
DROP TABLE if exists SALGRADE;

CREATE TABLE EMP
(
    EMPNO INT PRIMARY KEY, -- Add Primary Key for better practice and joins
    FirstName VARCHAR(20), -- Split ENAME for better string function practice
    LastName VARCHAR(20),
    JOB VARCHAR(9),
    MGR INT,
    HIREDATE DATETIME,
    SAL DECIMAL(10, 2), -- Use DECIMAL for salary to handle precision
    COMM DECIMAL(10, 2), -- Commission can be NULL
    DEPTNO INT,
    CONSTRAINT FK_EMP_DEPT FOREIGN KEY (DEPTNO) REFERENCES DEPT(DEPTNO)); -- Add FK for referential integrity
    -- CONSTRAINT FK_EMP_MGR FOREIGN KEY (MGR) REFERENCES EMP(EMPNO) -- Self-referencing FK for managers
);

CREATE TABLE DEPT
(
    DEPTNO INT PRIMARY KEY, -- Add Primary Key
    DNAME VARCHAR(14),
    LOC VARCHAR(13)
);

CREATE TABLE SALGRADE
(
    GRADE INT PRIMARY KEY, -- Add Primary Key
    LOSAL DECIMAL(10, 2),
    HISAL DECIMAL(10, 2)
);

-- Insert into DEPT first due to FK constraint
INSERT INTO DEPT VALUES (10,'ACCOUNTING','NEW YORK');
INSERT INTO DEPT VALUES (20,'RESEARCH','DALLAS');
INSERT INTO DEPT VALUES (30,'SALES','CHICAGO');
INSERT INTO DEPT VALUES (40,'OPERATIONS','BOSTON');
INSERT INTO DEPT VALUES (50,'MARKETING','LONDON'); -- Add a department with no employees initially

INSERT INTO EMP VALUES(7369,'JOHN','SMITH','CLERK',7902,'1980-12-17',800.00, NULL, 20);
INSERT INTO EMP VALUES(7499,'ALEX','ALLEN','SALESMAN',7698,'1981-02-20',1600.00,300.00,30);
INSERT INTO EMP VALUES(7521,'PETER','WARD','SALESMAN',7698,'1981-02-22',1250.00,500.00,30);
INSERT INTO EMP VALUES(7566,'DAVID','JONES','MANAGER',7839,'1981-04-02',2975.00,NULL,20);
INSERT INTO EMP VALUES(7654,'MARY','MARTIN','SALESMAN',7698,'1981-09-28',1250.00,1400.00,30);
INSERT INTO EMP VALUES(7698,'ROBERT','BLAKE','MANAGER',7839,'1981-05-01',2850.00,NULL,30);
INSERT INTO EMP VALUES(7782,'SUSAN','CLARK','MANAGER',7839,'1981-06-09',2450.00,NULL,NULL); -- Employee with NULL DEPTNO
INSERT INTO EMP VALUES(7788,'MICHAEL','SCOTT','ANALYST',7566,'1982-12-09',3000.00,NULL,20); -- Salary at border of SALGRADE 4/5
INSERT INTO EMP VALUES(7839,'ANNA','KING','PRESIDENT',NULL,'1981-11-17',5000.00,NULL,10);
INSERT INTO EMP VALUES(7844,'THOMAS','TURNER','SALESMAN',7698,'1981-09-08',1500.00,0.00,30);
INSERT INTO EMP VALUES(7876,'CHRIS','ADAMS','CLERK',7788,'1983-01-12',1100.00, NULL,20); -- Salary at border of SALGRADE 1/2
INSERT INTO EMP VALUES(7900,'JOHN','JAMES','CLERK',7698,'1981-12-03',950.00,NULL,NULL); -- Another NULL DEPTNO, same FirstName as 7369
INSERT INTO EMP VALUES(7902,'PATRICK','FORD','ANALYST',7566,'1981-12-03',3000.00,NULL,20);
INSERT INTO EMP VALUES(7934,'LINDA','MILLER','CLERK',7782,'1982-01-23',1300.00,NULL,10); -- Salary at border of SALGRADE 2/3

INSERT INTO SALGRADE VALUES (1, 700.00, 1200.00);
INSERT INTO SALGRADE VALUES (2, 1201.00, 1400.00);
INSERT INTO SALGRADE VALUES (3, 1401.00, 2000.00);
INSERT INTO SALGRADE VALUES (4, 2001.00, 3000.00);
INSERT INTO SALGRADE VALUES (5, 3001.00, 9999.00);

COMMIT;

SELECT 'DB tables with data is ready - Please start working on the queries' AS Message;
SELECT * FROM EMP;
SELECT * FROM DEPT;
SELECT * FROM SALGRADE;

--List all employee details.
select * from Emp
--List all department details
select * from Dept
--List all job details
Select job from EMP
--List all the locations
select Loc from DEPT
--List all unique job titles
select Distinct job From Emp 
--List all unique office locations
select Distinct Loc from Dept
--List employee's first name, last name, salary, and commission
select FirstName, LastName,Sal ,Comm from Emp
--List employee ID, first name, last name, and department ID, renaming columns to "Employee ID", "First Name", "Last Name", and "Department ID".
select EMPNO  as EmployeeId ,FirstName as FirstName , LastName as LastName ,DeptNo as DepartmentID from Emp
--List employee's annual salary (salary * 12) along with their first and last names.
select FirstName ,LastName, Sal*12 from Emp
--List all details for the employee named 'SMITH' (Last Name).
select * from Emp where LastName='SMITH'
--List employees working in department 20.
select * from Emp where DeptNo='20'
--List out the employees who are earning salary between 3000 and 4500 
select Sal from Emp where Sal between 3000 and 4500
--List employees whose salary is between 2500 and 3000 (inclusive).
select SAL from Emp where Sal>2500 and Sal<3000
--List employees working in department 10 or 20.
select * from Emp where DeptNo='10' or DeptNo='20'
--Find employees who are not working in department 10 or 20.
select * from Emp where Deptno not in(10,20)
--Find out the employees who are not working in department 10 or 30 
select * from Emp where Deptno not in(10,30)
--List employees whose last name starts with 'S'.
select * from Emp where LastName like'S%'
--List employees whose last name starts with 'S' and ends with 'H'.
select * from Emp where LastName like'S%H'
--List employees whose last name has exactly 4 characters and starts with 'S'.
select * from Emp Where LastName like'S%' and len(LastName) =4
--List employees who work in department 10 AND earn more than 3500.
select * from Emp Where DeptNo='10' and Sal >3500
--List employees who are not receiving commission
select * from Emp where Comm is null
--List employees who receive some commission
select * from Emp where Comm >0
--List employees whose last name contains an 'A' and is exactly 5 characters long
select * from Emp Where LastName like '%A%' and len(LastName) =5
--List employee ID, first name, last name in ascending order based on employee ID
Select EmpNo, FirstName, LastName from Emp order by EMPNO asc
--List employee ID, first name, last name in descending order based on salary.
select EmpNo, FirstName, LastName from Emp order by Sal desc
--List employee details, sorted by last name in ascending order, then by salary in descending order.
select *from Emp  order by Lastname asc , Sal desc
--List employee details, sorted by last name in ascending order, then by department ID in descending order.
select *from Emp  order by Lastname asc , DeptNo desc
--List out employee_id,last name,department id for all  employees and rename employee id as “ID  of the employee”, last name as “Name of the employee”, department id as  “department  ID”
select  EMPNO  as ID,LastName as [Name of the Employee],DeptNo as DepartmentID from Emp
--List out the employees anuual salary with their names only. 
select Sal*12 as AnuualSalary ,CONCAT(FirstName,' ',LastName) from Emp
--List the details about “SMITH” 
select * from Emp where LastName='SMITH'
--How many employees who are working in different departments wise in the organization For QTP Information
select 
	DeptNo,
	count(*) as NoOfEmployees
	from Emp
	Group By DeptNo
--List out the department wise maximum salary, minimum salary, average salary of the employees 
select 
	DeptNo,
	MIN(Sal) as MinimumSal,
	Max(Sal) as MaximumSal,
	Avg(Sal) as AvgSal
	From Emp
	Group By DeptNo
--List out the job wise maximum salary, minimum salary, average salaries of the employees. 
select 
	Job,
	MIN(Sal) as MinSal,
	MAX(Sal) as MaxSal,
	Avg(Sal) as AvgSalary
	from Emp
	Group By Job
--List out the no.of employees joined in every month in ascending order. 
Select
	DATENAME(MM,HIREDATE) as MonthName,
	Count(*) as NoOfEmployee
	From Emp
	Group By 
		DATENAME(MM,HIREDATE),Month(HIREDATE)
	Order By(1) Asc;
--List out the no.of employees for each month and year, in the ascending order based on the year, month. 
Select 
	DATENAME(YY,HIREDATE) as EmpYear,
	DATENAME(MM,HIREDATE) as EmpMonth,
	Count(*) as NoOfEmployees
	From Emp
	Group By
		DATENAME(YY,HIREDATE),Year(HIREDATE),
		DATENAME(MM,HIREDATE),Month(HIREDATE)
	Order By
		Year(HIREDATE),Month(HIREDATE) ASC;
--List out the department id having atleast four employees. 
Select  DeptNo
From Emp
group by DeptNo
having count(DeptNo)>=4
--How many employees in January month. 
Select *from Emp where Month(HIREDATE)=1
--How many employees who are joined in January or September month.
Select *from Emp where Month(HIREDATE)=1 or Month(HIREDATE)=9
Order by 
Month(HIREDATE)ASC;
--How many employees who are joined in 1985. 
Select * from Emp where Year(HIREDATE)=1985
--How many employees joined each month in 1985. 
Select * from Emp where Month(HIREDATE)=1985
--How many employees who are joined in March 1985. 
Select * from emp where Month(HIREDATE)=3 and Year(HIREDATE)=1985
--Which is the department id, having greater than or equal to 3 employees joined in April 1985. 
Select  DeptNo
From Emp
Where Month(HIREDATE)=4 and Year(HIREDATE)=1985
Group By DeptNo
Having Count(DeptNo)>=3
--Display the employee who got the maximum salary. 
Select * from Emp where Sal in(
	select Max(Sal) from Emp)
--Display the employees who are working in Sales department.
Select EmpNo,FirstName,LastName,DNAME from Emp E
join DEPT D on E.DeptNo=D.DeptNo
Where  DName='Sales'
--Display the employees who are working as “Clerk”.
Select EmpNo,FirstName,LastName,Job from Emp Where  Job='Clerk'
--Display the employees who are working in “New York”
Select EmpNo,FirstName,LastName,LOC from Emp E
join DEPT D on E.DeptNo=D.DeptNo
Where LOC='New York'
--Find out no.of employees working in “Sales” department.
select 
	count(*) as NoOfEmployees
	From Emp E
	join DEPT D on E.DeptNo=D.DeptNo
	Where DName='Sales'
--List our employees with their department names 
Select FirstName,DName from Emp E
join  DEPT D on E.DeptNo=D.DeptNo
--Display employees with their designations (jobs) 
Select FirstName,Job as Designations from Emp
--How many employees who are working in sales department. 
select 
	count(*) as NoOfEmployees
	From Emp E
	join DEPT D on E.DeptNo=D.DeptNo
	Where DName='Sales'
--Display the employee details with their manager names.
Select EMPNO,FirstName,LastName ,MGR from Emp
--Display the employee details who earn more than their managers salaries.
Select E.EmpNo,E.FirstName,E.Sal as EmpSal,M.Sal as MgrSal 
From Emp E
Join Emp M on E.MGR=M.MGR
Where E.Sal>M.Sal
--Display employee details with all departments. 
Select * from Emp E 
	Right join Dept D On E.DeptNo=D.DEPTNO
--Display all employees in sales or operation departments.
Select EmpNo,FirstName,LastName,Sal,Job,Dname from Emp E
	Left Join Dept D on E.DeptNo=D.DeptNo
	Where DNAME = 'Operation' or DNAME='Sales'
--List out the distinct jobs in Sales and Accounting Departments. 
select Distinct Job ,DName From Emp E
	Right Join Dept D on E.DeptNo=D.DeptNo
	Where DNAME='Sales' or DNAME='Accounting'
--List out the ALL jobs in Sales and Accounting Departments.
Select Job,DName from Emp E
	Right Join Dept D on E.DeptNo=D.DeptNo
	Where DNAME='Sales' or DNAME='Accounting'
--List out the common jobs in Research and Accounting Departments in ascending order.
Select 
	Job as CommonJobs,DName
	From Emp E
	left join Dept D on E.DeptNo=D.DeptNo
	Where DNAME='Research' or DNAME='Accounting'
	order by job Asc;

--Update the employees salaries, who are working as Clerk on the basis   of 10%. 
Update EMP Set SAL = Sal+SAL*0.1 where job ='Clerk' 
select * from Emp


--Delete the employees who are working in accounting department. 


--Display the second highest salary drawing employee details. 

--Display the Nth highest salary drawing employee details	

--List out the employees who earn more than every employee in department 30. 

--List out the employees who earn more than the lowest salary in department 30.

--Find out which department does not have any employees.
select D.DEPTNO from DEPT D  
 left join Emp E on D.DEPTNO= E.DEPTNO
where (E.EMPNO is null)
--Find out the employees who earn greater than the average salary for their department.

--Display the employees with their department name and regional groups. 
Select EMPNo,FirstName,LastName,DNAME,Loc 
from Emp E 
join Dept D on E.DeptNo =D.DEPTNO
--How many employees who are working in different departments and display with department name.
Select Count(EMPNO),D.DNAME from  Emp E
join Dept D on E.EMPNO=D.DEPTNO

--Which is the department having greater than or equal to 5 employees and display the department names in ascending order. 

--Display employee details with salary grades. 
Select EMPNO,FirstName,LastName,S.GRADE From Emp E
join SALGRADE S on E.SAL between S.LOSAL and S.HISAL
--Display the employ salary grades and no. of employees between 2000 to 5000 range of salary. 
Select S.GRADE,Count(*)as NoOfEmp
from EMP E 
join SALGRADE  S on E.SAL between S.LOSAL and S.HISAL
where E.Sal between 2000 and 5000 
Group by S.GRADE      


--Show the no. of employees working under every manager.


--Display the employee details with their manager names. 
