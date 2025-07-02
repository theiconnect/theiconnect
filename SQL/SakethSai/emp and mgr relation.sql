	
	SELECT E.EMPNO,E.DEPTNO,Sm.EMPNO,Sm.DEPTNO,SSm.EMPNO,SSm.DEPTNO,SSSm.EMPNO,SSSM.DEPTNO
	FROM Emp E
	Left Join Emp m on E.Mgr = m.EmpNo
	Left Join Emp Sm on M.Mgr = sm.EmpNo
	left join Emp SSm on sm.mgr = ssm.EMPNO
	left join Emp SSSm on SSm.mgr = SSSm.EMPNO