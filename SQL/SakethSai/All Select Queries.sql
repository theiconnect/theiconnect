CREATE DATABASE SampleDemo
USE SampleDemo

BEGIN TRANSACTION;

DROP TABLE if exists EMP;
DROP TABLE if exists DEPT;
DROP TABLE if exists SALGRADE;

CREATE TABLE DEPT
(
    DEPTNO INT PRIMARY KEY,
    DNAME VARCHAR(14),
    LOC VARCHAR(13)
);

CREATE TABLE SALGRADE
(
    GRADE INT PRIMARY KEY, 
    LOSAL DECIMAL(10, 2),
    HISAL DECIMAL(10, 2)
);

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
    CONSTRAINT FK_EMP_DEPT FOREIGN KEY (DEPTNO) REFERENCES DEPT(DEPTNO), -- Add FK for referential integrity
    CONSTRAINT FK_EMP_MGR FOREIGN KEY (MGR) REFERENCES EMP(EMPNO) -- Self-referencing FK for managers
);


-- Insert into DEPT first due to FK constraint
INSERT INTO DEPT VALUES (10,'ACCOUNTING','NEW YORK');
INSERT INTO DEPT VALUES (20,'RESEARCH','DALLAS');
INSERT INTO DEPT VALUES (30,'SALES','CHICAGO');
INSERT INTO DEPT VALUES (40,'OPERATIONS','BOSTON');
INSERT INTO DEPT VALUES (50,'MARKETING','LONDON'); 

INSERT INTO EMP VALUES(7369,'JOHN','SMITH','CLERK',7902,'1980-12-17',800.00, NULL, 20);
INSERT INTO EMP VALUES(7499,'ALEX','ALLEN','SALESMAN',7698,'1981-02-20',1600.00,300.00,30);
INSERT INTO EMP VALUES(7521,'PETER','WARD','SALESMAN',7698,'1981-02-22',1250.00,500.00,30);
INSERT INTO EMP VALUES(7566,'DAVID','JONES','MANAGER',7839,'1981-04-02',2975.00,NULL,20);
INSERT INTO EMP VALUES(7654,'MARY','MARTIN','SALESMAN',7698,'1981-09-28',1250.00,1400.00,30);
INSERT INTO EMP VALUES(7698,'ROBERT','BLAKE','MANAGER',7839,'1981-05-01',2850.00,NULL,30);
INSERT INTO EMP VALUES(7782,'SUSAN','CLARK','MANAGER',7839,'1981-06-09',2450.00,NULL,NULL); 
INSERT INTO EMP VALUES(7788,'MICHAEL','SCOTT','ANALYST',7566,'1982-12-09',3000.00,NULL,20); 
INSERT INTO EMP VALUES(7839,'ANNA','KING','PRESIDENT',NULL,'1981-11-17',5000.00,NULL,10);
INSERT INTO EMP VALUES(7844,'THOMAS','TURNER','SALESMAN',7698,'1981-09-08',1500.00,0.00,30);
INSERT INTO EMP VALUES(7876,'CHRIS','ADAMS','CLERK',7788,'1983-01-12',1100.00, NULL,20); 
INSERT INTO EMP VALUES(7900,'JOHN','JAMES','CLERK',7698,'1981-12-03',950.00,NULL,NULL); 
INSERT INTO EMP VALUES(7902,'PATRICK','FORD','ANALYST',7566,'1981-12-03',3000.00,NULL,20);
INSERT INTO EMP VALUES(7934,'LINDA','MILLER','CLERK',7782,'1982-01-23',1300.00,NULL,10);

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
SELECT *
fROM Emp;

--List all department details

SELECT *
FROM dept;

--List all unique job titles

SELECT 
	DISTINCT Job
FROM Emp;

--List all unique office locations


SELECT 
	DISTINCT Loc
FROM Dept;


--List employee's first name, last name, salary, and commission

SELECT
	FirstName,LastName,Sal,Comm
FROM Emp;

--List employee ID, first name, last name, and department ID, renaming columns to "Employee ID", "First Name", "Last Name", and "Department ID".

SELECT 
	Empno AS EmployeeId,
	FirstName AS FirstName,
	LastName AS LastName,
	DeptNo AS DepartmentId
FROM Emp;

--List employee's annual salary (salary * 12) along with their first and last names.

SELECT 
	SAL*12,FirstName,LastName
FROM Emp;

--List all details for the employee named 'SMITH' (Last Name).

SELECT *
FROM Emp
WHERE LastName = 'Smith';

--List employees working in department 20.

SELECT *
FROM Emp
where DeptNo = 20;

--List employees whose salary is between 2500 and 3000 (inclusive).
SELECT *
FROM Emp
WHERE Sal >=2500 AND Sal <= 3000;

--List employees working in department 10 or 20.
SELECT *
FROM Emp
WHERE deptno = 10 OR deptno = 20;

--Find employees who are not working in department 10 or 30.
 SELECT *
 FROM Emp
 WHERE NOT( DeptNo = 10 OR DeptNo = 30);

--List employees whose last name starts with 'S'.
SELECT *
FROM Emp
WHERE LastName like's%';

--List employees whose last name starts with 'S' and ends with 'H'.

SELECT LastName
FROM Emp
WHERE LastName Like 'S%H';

--List employees whose last name has exactly 4 characters and starts with 'S'.
SELECT LastName
FROM Emp
WHERE LastName like 'S%' AND len(LastName) = 4;

--List employees who work in department 10 AND earn more than 3500.
Select *
FROM Emp
WHERE deptNo = 10 and Sal > 3500;

--List employees who are not receiving commission
SELECT *
FROM Emp
WHERE COMM IS NULL;

--List employees who receive some commission
SELECT *
FROM Emp
WHERE NOT COMM IS NULL;

--List employees whose last name contains an 'A' and is exactly 5 characters long

SELECT LastName
FROM Emp
WHERE  LastName like '%a%' and len(LastName) = 5

-- List employee ID, first name, last name in ascending order based on employee ID

SELECT EMPNO,FirstName,LastName
FROM Emp
ORDER BY Empno;

--List employee ID, first name, last name in descending order based on salary.

SELECT EMPNO,FirstName,LastName, Sal
FROM Emp
ORDER BY Sal DESC;

--List employee details, sorted by last name in ascending order, then by salary in descending order.
SELECT *
FROM Emp
ORDER BY LastName ASC, Sal DESC;

--List employee details, sorted by last name in ascending order, then by department ID in descending order.

SELECT *
FROM Emp
ORDER BY LastName ASC, DeptNo DESC;

---joins 

select empno,firstname,lastname,dname
from emp
join dept on emp.deptno = dept.deptno
order by dname


select empno,firstname,lastname,dname
from emp
left join dept on emp.deptno = dept.deptno


select empno,firstname,lastname,dname
from emp
right join dept on emp.deptno = dept.deptno
order by dname


select empno,firstname,lastname,dname
from emp
full join dept on emp.deptno = dept.deptno
order by dname 


Select D.DName,Sum(sal) as Totalsal 
from emp E
right join dept D on E.DeptNo = D.DeptNo
Group By D.Dname
order by totalsal desc

go
---hike salary of an employees
Select Sum(Sal) as Tcurrentsal,sum(hikeSal)as Thikesal, Sum(hikesal)- Sum(sal) as hikeamount
from 
(SELECT D.DName,E.Sal,
	(((CASE 
		when D.DEPTNO = 10 then 5
		when D.DeptNo = 20 then 10
		when D.DEPTNO = 30 then 8
		when D.DeptNo = 40 then 4
		when D.Deptno = 50 then 2
		else 0
		end
		)/100.0 )*E.Sal)+E.Sal as hikeSal

From emp E
LEFT JOIN Dept D on E.DeptNo = D.DeptNo
) 
salary


--another method 

Select DNAME,sal,((perc/100.0)*sal)+sal as hikesal, (((perc/100.0)*sal)+sal) - sal as hike
from(
SELECT DName,Sal,
	iif(D.DeptNo = 10,5,
		iif(D.DeptNo = 20,10,
			iif(D.DeptNo = 30,8,
				iif(D.DeptNo = 40,4,
					iif(D.Deptno = 50,2,0))))) as [perc]

from emp E
Left join Dept D on E.DeptNo = D.DeptNo
) A


--65 select queries 
-- Simple Queries:

--1.List all the employee details
	select * 
	from emp

--2.List all the department details
    select * 
	from Dept
--3.List all job details
	select job 
	from emp

--4.List all the locations
	select loc 
	from Dept

--5.List out first name,last name,salary, commission for all employees
    select 
		firstname as [first name],
		lastname 'last name',
		Salary = sal,
		comm
	from emp

--6.List out employee_id,last name,department id for all employees 
--and rename employee id as “ID  of the employee”, last name as “Name of the employee”, department id as  “department  ID”
	select 
		empNo as [ID of The Employee],
		lastName as 'NameOfTheEmployee',
		DeptNo as [Department Id]
	from emp

--7.List out the employees anuual salary with their names only.
	SELECT 
		FirstName + LastName as [name],
		Sal*12 as Annualsalary
	FROM Emp 

--8.List the details about “SMITH” 
	SELECT *
	FROM Emp
	WHERE FirstName ='SMITH' OR LastName = 'SMITH'

--9.List out the employees who are working in department 20 
	
	SELECT *
	FROM Emp
	Where DeptNo = 20

--10.List out the employees who are earning salary between 3000 and 4500
	
	SELECT *
	FROM Emp
	WHERE SAL >= 3000 and Sal <=4500

--11.List out the employees who are working in department 10 or 20 
	
	SELECT *
	FROM Emp
	WHERE DeptNo = 10 or DeptNo = 20

--12.Find out the employees who are not working in department 10 or 30 

	SELECT *
	FROM Emp
	WHERE not(DeptNo = 10 or DeptNo = 30)

--13.List out the employees whose name starts with “S”
	--SELECT FirstName,LastName
	--FROM Emp
	--WHERE FirstName+LastName LIKE 'S%'

	SELECT FirstName
	FROM Emp
	WHERE FirstName LIKE 'S%'

	--SELECT *
	--FROM(SELECT FirstName+' '+LastName AS [Name]
	--FROM Emp) AS A
	--WHERE [Name] LIKE 'S%'

--14.List out the employees whose name start with “S” and end with “H”
	SELECT *
	FROM Emp
	WHERE FirstName+LastName LIKE 'S%H'

	SELECT *
	FROM(SELECT FirstName+LastName As Name 
	FROM Emp) AS a                                                                    
    WHERE Name LIKE 'S%H'                                                           SELECT * FROM EMP;
                                                                                    SELECT * FROM DEPT;
                                                                                    SELECT * FROM SALGRADE;
	

--15.List out the employees whose name length is 4 and start with “S”
	  
	  SELECT *
	  FROM Emp
	  WHERE len(FirstName) = 4 and FirstName like 's%'
	  
	  SELECT *
	  FROM(SELECT FirstName+LastName As [Name]
	  FROM Emp) As A
	  WHERE [Name] LIKE 'S%' AND Len([Name]) = 4

--16.List out the employees who are working in department 10 and draw the salaries more than 3500 
	
	SELECT *
	FROM Emp
	WHERE DeptNo = 10 AND SAL >=3500

--17.list out the employees who are not receiving commission. 
	SELECT *
	FROM Emp
	WHERE COMM IS NULL

--18.List out the employee id, last name in ascending order based on the employee id. 
	SELECT EmpNo,LastName
	FROM Emp
	ORDER BY EmpNo

--19. List out the employee id, name in descending order based on salary column
	
	SELECT EmpNo, FirstName+' '+LastName As [Name]
	FROM Emp
	ORDER BY Sal DESC

--20. List out the employee details according to their last_name in ascending order and salaries in descending order 
	SELECT *
	FROM Emp
	ORDER BY LastName, SAL DESC

--21. List out the employee details according to their last_name in ascending order and then on department_id in descending order.
	SELECT *
	FROM Emp
	ORDER BY LastName, DeptNo DESC

--22.How many employees who are working in different departments wise in the organization For QTP Information
	SELECT 
		DeptNO,
		count(EmpNo) AS NoOfEmployees
	FROM Emp
	GROUP BY DeptNo

--23.List out the department wise maximum salary, minimum salary, average salary of the employees 
	SELECT
		DeptNo,
		MAX(SAL) AS MaxmiumSalary,
		MIN(SAL) AS MinimumSalary,
		Avg(SAL) AS AverageSalary
	FROM Emp
	GROUP BY DEPTNO
	

--24.List out the job wise maximum salary, minimum salary, average salaries of the employees. 
	SELECT
		Job,
		MAX(SAL) AS MaxmiumSalary,
		MIN(SAL) AS MinimumSalary,
		Avg(SAL) AS AverageSalary
	FROM Emp
	GROUP BY Job

--25.List out the no.of employees joined in every month in ascending order. 
	SELECT 
		COUNT(*) As NoOfEmp,
		month(Hiredate) As [Month]
	FROM Emp
	GROUP BY month(hiredate)
	order by month(hiredate)


--26.List out the no.of employees for each month and year, in the ascending order based on the year, month. 
	select  yy, mm, count(*)
	from(
		select year(hiredate) yy, month(hiredate) mm,* from emp
		--order by yy,mm
	)a
	group by yy, mm
	order by yy,mm


--27.List out the department id having atleast four employees.
	
	SELECT DeptNo
	FROM Emp
	GROUP BY DeptNo
	HAVING COUNT(EMPNO) >= 4
	

--28.How many employees in January month. 
	SELECT COUNT(EmpNo) as EmpjoinedinJAN
	FROM Emp
	Where month(hireDate) = 1

--29.How many employees who are joined in January or September month.
	SELECT COUNT(EMpNO)AS joininJanSep
	FROM Emp
	WHERE month(HireDate) = 1 or month(HireDate) = 8

--30.How many employees who are joined in 1985. 
	SELECT COUNT(EmpNo)as joinyear
	FROM Emp
	WHERE Year(HireDate) = 1985

--31.How many employees joined each month in 1985. 
	
	SELECT 
		MONTH(HireDate) AS monthdate,
		COUNT(*) AS NoofEmp
	FROM Emp
	WHERE Month(HireDate) = 1985
	GROUP BY Month(Hiredate)



--32.How many employees who are joined in March 1985. 
	SELECT COUNT(EMPNO)
	FROM Emp
	WHERE year(HireDate) = 1985 AND Month(HireDate) = 3
--33.Which is the department id, having greater than or equal to 3 employees joined in April 1985. 
	 SELECT DeptNo
	 FROM Emp
	 WHERE month(hiredate) = 4 and Year(hiredate) = 1985
	 GROUP BY DeptNo
	 HAVING COUNT(EmpNo) >= 3 
	

 --34.Display the employee who got the maximum salary.
	
	--select max(sal) from emp

	select * from emp where sal in (
	select max(sal) from emp)

 --35.Display the employees who are working in Sales department
	Select 
		EmpNo,
		FirstName,
		LastName,
		dname
	FROM Emp e
	join dept d on e.deptNo = d.DeptNo
	WHERE dname = 'sales'

 --36.Display the employees who are working as “Clerk”.
	SELECT 
		EmpNo,
		FirstName,
		LastName,
		job
	FROM Emp 
	WHERE job = 'Clerk'

 --37.Display the employees who are working in “New York”
	SELECT 
		EmpNo,
		FirstName,
		LastName,
		LOC
	FROM Emp E
	Join Dept D on E.DeptNo = D. DeptNo
	WHERE LOC = 'NEW YORK'

 --38.Find out no.of employees working in “Sales” department.
	SELECT COUNT(EmpNo)AS NoOfEmpinSALESDept
	FROM Emp E
	JOIN Dept D on E.DeptNo = D.DeptNo
	WHERE Dname = 'Sales'

 --39.Update the employees salaries, who are working as Clerk on the basis   of 10%. 
	Update Emp Set sal = sal + sal*0.1 where JOB = 'clerk'
	
	select * From EMP

 --40.Delete the employees who are working in accounting department. 
	

	update emp set mgr = null where mgr in(
	SELECT *
	FROM Emp E
	Join Dept D on E.DeptNo = D.DeptNo
	where Dname ='Accounting' )

	--DELETE E
	--FROM Emp E
	--Join Dept D on E.DeptNo = D.DeptNo
	--where Dname ='Accounting'

	select * from EMP
 --41.Display the second highest salary drawing employee details. 
	
	SELECT top 1 Sal From (
	SELECT top 2 SAL
	FROM Emp 
	order by sal desc) as a 
	order by sal asc

 --42.Display the Nth highest salary drawing employee details  
	
	SELECT * FROM(select sal,
				DENSE_RANK() OVER (ORDER BY SAL desc) as [row_number]
		from emp) as a 
		WHERE row_number = 4
		

-- 43.List out the employees who earn more than every employee in department 30. 
	

--44.List out the employees who earn more than the lowest salary in department 30. 

--45.Find out whose department has not employees.
	
	SELECT D.DeptNo
	FROM Dept D
	join Emp E on D.DeptNo = E.DeptNo
	WHERE EmpNo IS NULL

--46.Find out which department does not have any employees.

 FROM Dept D
	
	

--47.Find out the employees who earn greater than the average salary for their department.
	
	FROM EMP


--48.List our employees with their department names 
		
		SELECT EmpNo,DName
		FROM Emp E
		JOIN Dept D on E. DeptNo = D. DeptNo

--49.Display employees with their designations (jobs)
		
		SELECT EmpNo,Job
		FROM Emp


--50.Display the employees with their department name and regional groups. 
	SELECT E.EMPNO,E.FirstName,E.LastName,D.DEPTNO,D.LOC
	FROM EMP E
	JOIN Dept D
	on E.DeptNo = D.DeptNo 


--51.How many employees who are working in different departments and display with department name. 
	select d.DNAME,count(EMPNO) as noofemp
	FROM Emp E  
	JOIN Dept D on E.DeptNo = D.DeptNo
	Group BY d.DNAME
	

--52.How many employees who are working in sales department.
		
		SELECT Count (*) As NoOfEmp
		FROM Emp E
		Join Dept D on E. DeptNo = D. DeptNo 
		WHERE DName = 'Sales'

--53.Which is the department having greater than or equal to 5 employees and display the department names in ascending order. 
	
	SELECT D.DEPTNO,D.DNAME
	FROM Emp E
	join Dept D on E.DEPTNO = D.DEPTNO
	GROUP BY D.DeptNo,Dname
	HAVING Count(EmpNo) >= 5
	ORDER BY Dname 

--54.How many jobs in the organization with designations. 
	
	Select count(JOB)as noofemp,JOB
	FROM Emp 
	group by JOB

	

--55.How many employees working in “New York”.
	SELECT Count (*) As NoOfEmp
		FROM Emp E
		Join Dept D on E. DeptNo = D. DeptNo 
		WHERE LOC ='New York'

--56.Display employee details with salary grades. 
	SELECT EMPNO,FirstName,LastName, S.GRADE
	FROM Emp E
	JOIN SALGRADE S on E.SAL
	BETWEEN S.loSal and S.HiSal


--57.List out the no. of employees on grade wise. 
	SELECT S.GRADE,
		COUNT(*)as noofemp
	FROM Emp E
	JOIN SALGRADE S on E.SAL
	Between S.losal and S.HISAL 
	Group BY GRADE

--58.Display the employ salary grades and no. of employees between 2000 to 5000 range of salary.
	SELECT s.GRADE,
		COUNT(*)as NoOfEmp
	FROM Emp E
	Join SalGrade S 
	on E.SAl BETWEEN S.LOSAL AND S.HISAL
	where GRADE = 4
	GROUP BY GRADE
	

--59.Display the employee details with their manager names.
	
	SELECT E.EmpNo,E.FirstName,E.LastName,M.MGR
	FROM Emp E
	Join Emp M on E.EmpNo = M.EmpNo

--60.Display the employee details who earn more than their managers salaries.
	SELECT e.empno,e.firstName,e.lastName,e.sal as EmpSal,m.sal As MgrSal
	FROM Emp E
	Join Emp m on E.MGR = m.MGR
	where e.sal > m.sal
	

--61.Show the no. of employees working under every manager.

--61.Display employee details with all departments.
	SELECT *
	FROM Emp E
	Right Join Dept D on E. DeptNo = D. DeptNo

--62.Display all employees in sales or operation departments.
	SELECT EmpNo,FirstName,LastName,Sal,Dname
	FROM Emp E
	left join Dept D on E. DeptNo = D. DeptNo
	WHERE DName = 'SALES' or DName = 'operations'

--63.List out the distinct jobs in Sales and Accounting Departments.
	SELECT DISTINCT Job,Dname
	FROM Emp E
    left join Dept D on E. DeptNo = D. DeptNo
	WHERE DName = 'SALES' or DName = 'ACCOUNTING'
	
--64.List out the ALL jobs in Sales and Accounting Departments.
	SELECT Job,DName
	FROM Emp E
	left join Dept D on E. DeptNo = D. DeptNo
	WHERE DName = 'SALES' or DName = 'ACCOUNTING'

--65.List out the common jobs in Research and Accounting Departments in ascending order.
	SELECT 
		job,Dname
	FROM Emp E 
	inner join Dept D on E.DeptNo = D.DeptNo
	WHERE DName = 'Research' or Dname = 'Accounting'




