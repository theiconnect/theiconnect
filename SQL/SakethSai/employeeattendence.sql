WITH AttendancePairs AS (
    SELECT 
        EA.EmpIDFk,
        E.Ename,
        EA.logDateTime AS InTime,
        LEAD(EA.logDateTime) OVER (PARTITION BY EA.EmpIDFk ORDER BY EA.logDateTime) AS OutTime,
        EA.InOrOut
    FROM EmpAttendence EA
    INNER JOIN Employee E ON EA.EmpIDFk = E.EmpIdPk
    WHERE CAST(EA.logDateTime AS DATE) = '2025-06-17'
),
ActualWorkedHours AS (
    SELECT 
        EmpIDFk,
        Ename,
        SUM(DATEDIFF(MINUTE, InTime, OutTime)) / 60.0 AS ActualWorkingHrs
    FROM AttendancePairs
    WHERE InOrOut = 1
    GROUP BY EmpIDFk, Ename
),
FinalResult AS (
    SELECT 
        E.EmpIdPk AS EmpId,
        E.Ename,
        CASE WHEN A.EmpIDFk IS NULL THEN NULL ELSE 9.5 END AS TotalWorkingHrs,
        CASE WHEN A.EmpIDFk IS NULL THEN NULL ELSE A.ActualWorkingHrs END AS ActualWorkingHrs,
        CASE WHEN A.EmpIDFk IS NULL THEN 'Yes' ELSE 'No' END AS AbsentOrNot
    FROM Employee E
    LEFT JOIN ActualWorkedHours A ON E.EmpIdPk = A.EmpIDFk
)
SELECT * FROM FinalResult;
