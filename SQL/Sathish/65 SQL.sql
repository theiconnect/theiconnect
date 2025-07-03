 --Simple Queries:
--
--1.List all the employee details
	SELECT * FROM EMP
--2.List all the department details
	SELECT * FROM DEPT
--3.List all job details
	SELECT JOB FROM EMP
--4.List all the locations
	SELECT LOC FROM DEPT
--5.List out first name,last name,salary, commission for all employees
	SELECT FirstName, LASTNAME, SAL, COMM FROM EMP
--6.List out employee_id,last name,department id for all  employees and rename employee id as “ID  of the employee”, 
--  last name as “Name of the employee”, department id as  “department  ID”
	SELECT EMPNO AS IDOFEMPLOYEE, lastname AS NAMEOFEMPLOYEE, deptno AS DEPARTMENTID from EMP 
--7.List out the employees anuual salary with their names only. 
	SELECT SAL*12 FROM EMP 
--8.List the details about “SMITH” 
	SELECT * FROM EMP WHERE LastName='SMITH'
--9.List out the employees who are working in department 20 
	SELECT * FROM EMP WHERE DEPTNO='20'
--10.List out the employees who are earning salary between 3000 and 4500 
	SELECT * FROM EMP WHERE SAL BETWEEN 3000 AND 4500
--11.List out the employees who are working in department 10 or 20 
	SELECT * FROM EMP WHERE DEPTNO BETWEEN 10 AND 20
--12.Find out the employees who are not working in department 10 or 30 
	SELECT * FROM EMP WHERE DEPTNO NOT BETWEEN 10 AND 20
--13.List out the employees whose name starts with “S” 
	SELECT * FROM EMP WHERE FirstName like 'S%'
--14.List out the employees whose name start with “S” and end with “H”
	SELECT * FROM EMP WHERE LastName LIKE 'S%%H'
--15.List out the employees whose name length is 4 and start with “S”
	SELECT * FROM EMP WHERE  LEN(FirstName) = 4 AND FIRSTNAME LIKE 'S%'
--16.List out the employees who are working in department 10 and draw the salaries more than 3500 
	SELECT * FROM EMP WHERE DEPTNO = 10 AND SAL >= 3500
--17.list out the employees who are not receiving commission. 
	SELECT * FROM EMP WHERE COMM IS NULL
--18.List out the employee id, last name in ascending order based on the employee id. 
	SELECT EMPNO, LastName FROM EMP ORDER BY EMPNO ASC
--19. List out the employee id, name in descending order based on salary column 
	SELECT EMPNO, FIRSTNAME FROM EMP ORDER BY SAL ASC
--20. List out the employee details according to their last_name in ascending order and salaries in descending order 
	SELECT * FROM EMP ORDER BY LastName ASC, SAL DESC
--21. List out the employee details according to their last_name in ascending order and then on department_id in descending order.
    SELECT  EMPNO,LASTNAME ,SAL FROM EMP ORDER BY SAL DESC 
--22.How many employees who are working in different departments wise in the organization For QTP Information
	SELECT DEPTNO, COUNT(*) AS EmployeeCount FROM EMP GROUP BY DEPTNO
--23.List out the department wise maximum salary, minimum salary, average salary of the employees 
	SELECT DEPTNO, MAX(SAL) AS MAXSALARY, MIN(SAL) AS MinSalary, AVG(SAL) AS AvgSalary FROM EMP GROUP BY DEPTNO 
--24.List out the job wise maximum salary, minimum salary, average salaries of the employees. 
	SELECT JOB, MAX(SAL) AS MAXIMUMSALARY, MIN(SAL) AS MINIMUMSALARY, AVG(SAL) AS AVERAGESALARY FROM EMP GROUP BY JOB
--25.List out the no.of employees joined in every month in ascending order. 
	SELECT YEAR(HIREDATE) AS YEARJOINED,MONTH(HIREDATE) AS MONTHJOINED, COUNT(*) AS NOOFEMPLOYEES FROM EMP
	GROUP BY YEAR(HIREDATE), MONTH(HIREDATE) ORDER BY YEARJOINED ASC, MONTHJOINED ASC
--26.List out the no.of employees for each month and year, in the ascending order based on the year, month. 
	SELECT COUNT(*) AS NOOFEMPLOYEES, MONTH(HIREDATE)AS MONTHJOINED, YEAR(HIREDATE) AS YEARJOINED FROM EMP GROUP BY MONTH(HIREDATE), YEAR(HIREDATE)
	ORDER BY YEARJOINED ASC, MONTHJOINED ASC
--27.List out the department id having atleast four employees. 
	SELECT DEPTNO FROM EMP GROUP BY DEPTNO HAVING COUNT(*)>=4
--28.How many employees in January month. 
	SELECT * FROM EMP WHERE MONTH(HIREDATE)=1
--29.How many employees who are joined in January or September month.
	SELECT COUNT(*) AS NOOFEMPLOYEES FROM EMP WHERE MONTH(HIREDATE)=1 OR MONTH(HIREDATE)= 9
--30.How many employees who are joined in 1985. 
	SELECT COUNT(*) AS NOOFEMPLOYEES FROM EMP WHERE YEAR(HIREDATE)=1985
--31.How many employees joined each month in 1985. 
	SELECT COUNT(*) AS NOOFEMPLOYEES FROM EMP WHERE MONTH(HIREDATE)=1985
--32.How many employees who are joined in March 1985. 
	SELECT COUNT(*) AS NOOFEMPLOYEES FROM EMP WHERE MONTH(HIREDATE)=3 AND YEAR(HIREDATE)=1985
--33.Which is the department id, having greater than or equal to 3 employees joined in April 1985. 
	SELECT DEPTNO FROM EMP WHERE MONTH(HIREDATE)=3 AND YEAR(HIREDATE)=1985 GROUP BY DEPTNO HAVING COUNT(EMPNO)>=3
-- 34.Display the employee who got the maximum salary. 
	SELECT * FROM EMP WHERE SAL= (SELECT MAX(SAL) FROM EMP)
-- 35.Display the employees who are working in Sales department
	SELECT E.* FROM EMP E JOIN DEPT D ON E.DEPTNO = D.DEPTNO WHERE D.DNAME = 'SALES'
-- 36.Display the employees who are working as “Clerk”.
	SELECT * FROM EMP WHERE JOB='CLERK'
-- 37.Display the employees who are working in “New York”
	SELECT E.* FROM EMP E JOIN DEPT D ON E.DEPTNO=D.DEPTNO WHERE D.LOC='NEW YORK'
-- 38.Find out no.of employees working in “Sales” department.
	SELECT COUNT(*) AS NOOFEMPLOYEES FROM EMP E JOIN DEPT D ON E.DEPTNO = D.DEPTNO WHERE D.DNAME = 'SALES'
-- 39.Update the employees salaries, who are working as Clerk on the basis   of 10%. 
	UPDATE EMP SET SAL = SAL + (SAL * 0.10) WHERE JOB = 'CLERK'
-- 40.Delete the employees who are working in accounting department. 
	update emp set mgr = null where mgr in(
	SELECT *
	FROM Emp E JOIN DEPT D ON E.DEPTNO=D.DEPTNO WHERE DNAME ='ACCOUNTING')
-- 41.Display the second highest salary drawing employee details. 
	SELECT SAL FROM EMP WHERE SAL=(SELECT MAX(SAL)FROM EMP WHERE SAL<(SELECT MAX(SAL)FROM EMP))
-- 42.Display the Nth highest salary drawing employee details  
	
-- 43.List out the employees who earn more than every employee in department 30. 
	SELECT * FROM EMP WHERE SAL>ALL (SELECT SAL FROM EMP WHERE DEPTNO=30)
-- 44.List out the employees who earn more than the lowest salary in department 30. 
	SELECT * FROM EMP WHERE SAL<ALL (SELECT SAL FROM EMP WHERE DEPTNO=10)
-- 45.Find out whose department has not employees. 
	SELECT D.DEPTNO FROM DEPT D JOIN EMP E ON D.DEPTNO = E.DEPTNO WHERE EMPNO IS NULL
-- 46.Find out which department does not have any employees.
	SELECT DNAME,NOOFEMPLOYEES FROM(SELECT DNAME,COUNT(EMPNO)AS NOOFEMPLOYEES
	FROM DEPT D LEFT JOIN EMP E ON D.DEPTNO = E.DEPTNO GROUP BY DNAME) AS A WHERE NOOFEMPLOYEES=0
-- 47.Find out the employees who earn greater than the average salary for their department.   
	SELECT * FROM EMP WHERE SAL>(SELECT AVG(SAL)FROM EMP)
-- 48.List our employees with their department names 
	SELECT EMPNO,DNAME FROM EMP E JOIN DEPT D on E.DEPTNO = D.DEPTNO
-- 49.Display employees with their designations (jobs) 
	SELECT EMPNO, JOB FROM EMP
-- 50.Display the employees with their department name and regional groups. 
	SELECT E.EMPNO,E.FirstName,E.LastName,D.DEPTNO,D.LOC FROM EMP E JOIN DEPT D ON E.DEPTNO = D.DEPTNO 
-- 51.How many employees who are working in different departments and display with department name. 
	SELECT D.DNAME, COUNT(EMPNO)AS NOOFEMPOLYESS FROM 
	EMP E RIGHT JOIN DEPT D ON E.DEPTNO=D.DEPTNO GROUP BY DNAME
-- 52.How many employees who are working in sales department.
	SELECT 'SALES' AS DPETNAME,COUNT(EMPNO)AS NOOFEMPLOYEES FROM
	EMP E JOIN DEPT D ON E.DEPTNO=D.DEPTNO WHERE DNAME='SALES'
-- 53.Which is the department having greater than or equal to 5 employees and display the department names in ascending order. 
	SELECT D.DEPTNO,D.DNAME FROM EMP E JOIN DEPT D ON E.DEPTNO=D.DEPTNO 
	GROUP BY D.DEPTNO,DNAME HAVING COUNT(EMPNO)>=5 ORDER BY DNAME	
-- 54.How many jobs in the organization with designations. 
	SELECT COUNT(JOB) AS NOOFJOBS,JOB FROM Emp group by JOB
-- 55.How many employees working in “New York”.
	SELECT COUNT(*) AS NOOFEMPLOYEES FROM EMP E JOIN DEPT D ON E.DEPTNO=D.DEPTNO WHERE LOC ='New York'
-- 56.Display employee details with salary grades. 
	SELECT EMPNO,FirstName,LastName, S.GRADE FROM EMP E JOIN SALGRADE S ON E.SAL BETWEEN S.LOSAL AND S.HISAL
-- 57.List out the no. of employees on grade wise. 
	SELECT S.GRADE,COUNT(*)AS NOOFEMPLOYEES FROM 
	EMP E JOIN SALGRADE S on E.SAL BETWEEN S.LOSAL AND S.HISAL GROUP BY GRADE
-- 58.Display the employee salary grades and no. of employees between 2000 to 5000 range of salary.
	SELECT S.GRADE, COUNT(*)AS NOOFEMPLOYEES FROM 
	EMP E JOIN SALGRADE S ON E.SAl BETWEEN S.LOSAL AND S.HISAL WHERE GRADE = 4 GROUP BY GRADE
-- 59.Display the employee details with their manager names.
	SELECT E.EmpNo,E.FirstName,E.LastName,M.MGR FROM EMP E JOIN EMP M ON E.EMPNO = M.EMPNO
-- 60.Display the employee details who earn more than their managers salaries.
	SELECT E.EMPNO,E.FirstName,E.LastName,E.SAL AS EMPSAL,M.SAL AS MGRSAL FROM 
	EMP E JOIN EMP M ON E.MGR = M.MGR WHERE E.SAL>M.SAL
-- 61.Show the no. of employees working under every manager.
	SELECT * FROM EMP E RIGHT JOIN DEPT D ON E.DEPTNO=D.DEPTNO
-- 61.Display employee details with all departments.
	SELECT * FROM Emp E Right Join Dept D on E. DeptNo = D. DeptNo
-- 62.Display all employees in sales or operation departments.
	SELECT EmpNo,FirstName,LastName,Sal,Dname FROM Emp E left join Dept D on E. DeptNo = D. DeptNo
	WHERE DName = 'SALES' or DName = 'operations'
--63.List out the distinct jobs in Sales and Accounting Departments.
	SELECT DISTINCT Job,Dname FROM Emp E left join Dept D on E. DeptNo = D. DeptNo 
	WHERE DName = 'SALES' or DName = 'ACCOUNTING'
--64.List out the ALL jobs in Sales and Accounting Departments.
	SELECT Job,DName FROM Emp E left join Dept D on E. DeptNo = D. DeptNo WHERE DName = 'SALES' or DName = 'ACCOUNTING'
--65.List out the common jobs in Research and Accounting Departments in ascending order.
	SELECT JOB,DNAME FROM EMP E INNER JOIN DEPT D ON E.DEPTNO= D.DEPTNO 
	WHERE DNAME='RESEARCH' OR DNAME='ACCOUNTING'
