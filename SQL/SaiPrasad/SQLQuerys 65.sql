
drop table SALGRADE
drop table EMP
drop table DEPT
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
drop table EMP

select * from EMP
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

select * from SALGRADE
select * from EMP
--1.List all the employee details
select * from EMP
--2.List all the department details
select * from DEPT
--3.List all job details
select JOB from EMP
--4.List all the locations
select LOC from DEPT
--5.List out first name,last name,salary, commission for all employees
select FirstName,Lastname,SAL,COMM from EMP
/*6.List out employee_id,last name,department id for all  employees and rename employee id as “ID  of the employee”, last name as “Name of the employee”, 
department id as  “department  ID”*/
select EMPNO as ID_OF_THE_EMPLOYEE, Lastname as Name_of_the_employee,DeptNo as department_ID from EMP
--7.List out the employees anuual salary with their names only. 
SELECT SAL*12 AS ANUAL_SALARY FROM EMP
--List the details about “SMITH” 
SELECT * FROM EMP WHERE LASTName = 'SMITH'
--9.List out the employees who are working in department 20 
SELECT * FROM EMP
    WHERE DEPTNO = 20
--List out the employees who are earning salary between 3000 and 4500 
SELECT * FROM EMP
    WHERE SAL >= 3000 AND SAL < 4500
--11.List out the employees who are working in department 10 or 20 
SELECT * FROM EMP 
    WHERE DEPTNO = 10 OR DEPTNO = 20
--12.Find out the employees who are not working in department 10 or 30 
SELECT * FROM EMP
    WHERE NOT (DEPTNO=10 OR DEPTNO=30)
--13.List out the employees whose name starts with “S” 
SELECT * FROM EMP 
    WHERE Lastname like('S%')
--14.List out the employees whose name start with “S” and end with “H”
select * from EMP 
    where FirstName like 'S%H'
--15.List out the employees whose name length is 4 and start with “S”
select * from EMP
    where FirstName like 'S%' and len(FirstName)=4
--16.List out the employees who are working in department 10 and draw the salaries more than 3500 
    select *
    from EMP
        where DEPTNO=10 AND SAL>3500
--17.list out the employees who are not receiving commission. 
 select * from EMP where COMM is null
--18.List out the employee id, last name in ascending order based on the employee id. 
select EMPNO,Lastname from EMP order by EMPNO
--19. List out the employee id, name in descending order based on salary column 
select EMPNO,Lastname,SAL from EMP order by SAL desc
--20. List out the employee details according to their last_name in ascending order and salaries in descending order 
select * from EMP order by lastname asc , SAL desc
--21. List out the employee details according to their last_name in ascending order and then on department_id in descending order.
select * from EMP order by lastname asc ,DEPTNO desc
--22.How many employees who are working in different departments wise in the organization For QTP Information
select count(EMPNO),DEPTNO from EMP group by DEPTNO
--23.List out the department wise maximum salary, minimum salary, average salary of the employees
select  max(sal),avg(sal),Min(sal),DEPTNO from EMP group by DEPTNO
--24.List out the job wise maximum salary, minimum salary, average salaries of the employees. 
   select  max(sal),avg(sal),Min(sal),job from EMP group by job
--25.List out the no.of employees joined in every month in ascending order. 
select count(EMPNO) as nofemp , month(HIREDATE) as [month] from EMP group by month(HIREDATE)  order by month(HIREDATE) asc
--26.List out the no.of employees for each month and year, in the ascending order based on the year, month.
select count(EMPNO) as nofemp ,
    month(HIREDATE) as [month],year(HIREDATE) as yy 
from EMP 
group by month(HIREDATE), year(HIREDATE)
order by month(HIREDATE), year(HIREDATE) asc

--27.List out the department id having atleast four employees. 
select DEPTNO 
    from EMP
group by DEPTNO
having count(EMPNO) >=4
--
--28.How many employees in January month.
select count(EMPNO) from EMP
    where month(HIREDATE)=1

--29.How many employees who are joined in January or September month.
select count(EMPNO) from EMP
    where month(HIREDATE)=1 or month(HIREDATE)=9
--30.How many employees who are joined in 1985. 
select count(EMPNO) from EMP 
    where year(HIREDATE)=1985
--31.How many employees joined each month in 1985.
select month(HIREDATE),count(EMPNO)  
from EMP
where month(HIREDATE)=1985
group by month(HIREDATE)

--32.How many employees who are joined in March 1985.
select count(EMPNO) from EMP
    where month(HIREDATE)=3 and year(HIREDATE)=1985
--33.Which is the department id, having greater than or equal to 3 employees joined in April 1985. 
   select DEPTNO
   from EMP
   where month(HIREDATE)=4 AND year(HIREDATE)=1985
   group by DEPTNO
   having count(EMPNO)>=3
--34.Display the employee who got the maximum salary. 
select empno,FirstName from emp where sal in(select  MAX(SAL) as sa from EMP)

--35.Display the employees who are working in Sales department
select EMPNO,Firstname,loc,sal
    from EMP e
    join DEPt d on e.deptno=d.deptno
    where DNAME='Sales'


--36.Display the employees who are working as “Clerk”.
select Empno from EMp where job = 'clerk'

--37.Display the employees who are working in “New York”
select EMpno,firstname,sal,loc from emp e
join dept d on e.deptno = d.deptno
where loc  = 'New York'

--38.Find out no.of employees working in “Sales” department.
select count(empno)
    from EMP e
    join DEPt d on e.deptno=d.deptno
    where DNAME='Sales'
--39.Update the employees salaries, who are working as Clerk on the basis   of 10%.
update EMP
    set sal=sal+sal*10/100
    where job = 'clerk'
    select * from emp
--40.Delete the employees who are working in accounting department.
    UPDATE EMP SET MGR = NULL WHERE MGR IN (
    SELECT E.EMPNO
    FROM EMP E 
    JOIN DEPT D ON E.DEPTNO = D.DEPTNO
    WHERE DNAME = 'ACCOUNTING'
)

    delete e
    FROM EMP E 
    JOIN DEPT D ON E.DEPTNO = D.DEPTNO
    WHERE DNAME = 'ACCOUNTING'

    


select * from dept
--41.Display the second highest salary drawing employee details.
SELECT MAX(SAL) FROM EMP --1ST
SELECT MAX(SAL) FROM EMP WHERE SAL < (SELECT MAX(SAL) FROM EMP)

--42.Display the Nth highest salary drawing employee details 
    SELECT * 
FROM(
	SELECT ROW_NUMBER() OVER(ORDER BY SAL DESC) ROWID,SAL
	FROM EMP
)A
where rowid = 2
--43.List out the employees who earn more than every employee in department 30. 
select count(*) from (select max(SAL) from emp where deptno=30 group by deptno) a
--44.List out the employees who earn more than the lowest salary in department 30.
select empno,min(sal) from emp where deptno = 30 group by deptno
--45.Find out whose department has not employees. 
SELECT D.DEPTNO, D.DNAME
FROM DEPT D
LEFT JOIN EMP E ON D.DEPTNO = E.DEPTNO
WHERE E.EMPNO IS NULL;
--46.Find out which department does not have any employees.
SELECT D.DEPTNO, D.DNAME
FROM DEPT D
LEFT JOIN EMP E ON D.DEPTNO = E.DEPTNO
WHERE E.EMPNO IS NULL;
--47.Find out the employees who earn greater than the average salary for their department.
select * from emp where sal > (
select avg(sal) from emp e where e.deptno=emp.deptno)
--48.List our employees with their department names 

select e.empno,e.firstname,d.dname
from emp e
left join dept d on e.deptno=d.deptno

--49.Display employees with their designations (jobs) 
select * from emp
 select empno,firstname,job from emp
 --50.Display the employees with their department name and regional groups. 
 select e.empno,e.firstname,d.dname,loc
from emp e
left join dept d on e.deptno=d.deptno
where d.dname is not null
--51.How many employees who are working in different departments and display with department name.
select count(empno) as nofemployees,d.dname from emp e
   right join dept d on e.deptno=d.deptno group by dname

--52.How many employees who are working in sales department. 
select 'sales' as deptname,count(empno)
 from emp e join dept d on e.deptno=d.deptno where dname = 'sales'
--53.Which is the department having greater than or equal to 5 employees and display the department names in ascending order. 
    select count(empno) as nofemp,d.dname from emp e
   right join dept d on e.deptno=d.deptno group by d.deptno,d.dname having count(empno) >=5 order by d.dname asc

--54.How many jobs in the organization with designations
select count(job),job from emp 
    group by job
--55.How many employees working in “New York”.
select count(empno) as nofemp from emp e
    join dept d on e.deptno=d.deptno where loc='new york'

--56.Display employee details with salary grades.
select empno,s.grade,e.sal
from emp e
join SALGRADE s on e.sal between s.LOSAL and s.HISAL


--57.List out the no. of employees on grade wise. 
select count(empno) as nofemployees,s.GRADE
from emp e
join SALGRADE s on e.sal between s.LOSAL and s.HISAL group by s.GRADE
select * from SALGRADE
--58.Display the employ salary grades and no. of employees between 2000 to 5000 range of salary. 
     select e.sal ,count(e.empno)
    from emp e
    join salgrade s on s.sal between s.LOSAL and s.HISAL where
    e.sal between 2000 and 5000

--59.Display the employee details with their manager names. 
   select e.empno,e.firstname,e.lastname,m.mgr,concat(e.firstname,e.lastname)
   from emp e
   join emp m on e.mgr=m.empno
--60.Display the employee details who earn more than their managers salaries.
select e.firstname,e.lastname,e.mgr
    from emp e
    join emp m on e.mgr=m.empno
    where e.sal>m.sal

--61.Show the no. of employees working under every manager.
select * from emp
select count(e.empno),e.mgr
 from emp e
 left join emp m on e.mgr=e.empno
 group by e.mgr

--62.Display employee details with all departments.
select * from emp e
right join dept d on e.deptno=d.deptno

--63.Display all employees in sales or operation departments.
select * from emp e
left join dept d on e.deptno=d.deptno
where d.dname = 'sales' or d.dname = 'operation'

--64.List out the distinct jobs in Sales and Accounting Departments.
  select distinct e.job
  from emp e 
  left join dept d on e.deptno=d.deptno 
  where d.dname='sales' or d.dname='Accounting'

--64.List out the ALL jobs in Sales and Accounting Departments.
  select  e.job
    from emp e 
      left join dept d on e.deptno=d.deptno 
      where d.dname='sales' or d.dname='Accounting'

--65.List out the common jobs in Research and Accounting Departments in ascending order. 
select  e.job
    from emp e 
      left join dept d on e.deptno=d.deptno 
      where d.dname='Research' or d.dname='Accounting'
      group by job 

