## Data Transformation Journey: Seeing Queries in Action

To truly grasp how a `SELECT` query works, let's trace the data's journey step-by-step through a few examples. We'll imagine a "temporary table" or "result set" that the database builds internally at each stage.

**Initial State of the `EMP` Table:**

| EMPNO | FirstName | LastName | JOB        | MGR  | HIREDATE            | SAL    | COMM   | DEPTNO |
| :---- | :-------- | :------- | :--------- | :--- | :------------------ | :----- | :----- | :----- |
| 7369  | JOHN      | SMITH    | CLERK      | 7902 | 1980-12-17 00:00:00 | 800.00 | NULL   | 20     |
| 7499  | ALEX      | ALLEN    | SALESMAN   | 7698 | 1981-02-20 00:00:00 | 1600.00 | 300.00 | 30     |
| 7521  | PETER     | WARD     | SALESMAN   | 7698 | 1981-02-22 00:00:00 | 1250.00 | 500.00 | 30     |
| 7566  | DAVID     | JONES    | MANAGER    | 7839 | 1981-04-02 00:00:00 | 2975.00 | NULL   | 20     |
| 7654  | MARY      | MARTIN   | SALESMAN   | 7698 | 1981-09-28 00:00:00 | 1250.00 | 1400.00 | 30     |
| 7698  | ROBERT    | BLAKE    | MANAGER    | 7839 | 1981-05-01 00:00:00 | 2850.00 | NULL   | 30     |
| 7782  | SUSAN     | CLARK    | MANAGER    | 7839 | 1981-06-09 00:00:00 | 2450.00 | NULL   | NULL   |
| 7788  | MICHAEL   | SCOTT    | ANALYST    | 7566 | 1982-12-09 00:00:00 | 3000.00 | NULL   | 20     |
| 7839  | ANNA      | KING     | PRESIDENT  | NULL | 1981-11-17 00:00:00 | 5000.00 | NULL   | 10     |
| 7844  | THOMAS    | TURNER   | SALESMAN   | 7698 | 1981-09-08 00:00:00 | 1500.00 | 0.00   | 30     |
| 7876  | CHRIS     | ADAMS    | CLERK      | 7788 | 1983-01-12 00:00:00 | 1100.00 | NULL   | 20     |
| 7900  | JOHN      | JAMES    | CLERK      | 7698 | 1981-12-03 00:00:00 | 950.00  | NULL   | NULL   |
| 7902  | PATRICK   | FORD     | ANALYST    | 7566 | 1981-12-03 00:00:00 | 3000.00 | NULL   | 20     |
| 7934  | LINDA     | MILLER   | CLERK      | 7782 | 1982-01-23 00:00:00 | 1300.00 | NULL   | 10     |

**`DEPT` Table:**

| DEPTNO | DNAME        | LOC        |
| :----- | :----------- | :--------- |
| 10     | ACCOUNTING   | NEW YORK   |
| 20     | RESEARCH     | DALLAS     |
| 30     | SALES        | CHICAGO    |
| 40     | OPERATIONS   | BOSTON     |

**`SALGRADE` Table:**

| GRADE | LOSAL | HISAL |
| :---- | :---- | :---- |
| 1     | 700   | 1200  |
| 2     | 1201  | 1400  |
| 3     | 1401  | 2000  |
| 4     | 2001  | 3000  |
| 5     | 3001  | 9999  |

---

### Example: `INNER JOIN` with Two Tables and `WHERE` Conditions

**Goal:** Get the names of employees, their jobs, department names, and locations for employees who are 'CLERK' or 'ANALYST' and work in 'NEW YORK'.

**Query:**

```sql
SELECT
    E.FirstName,
    E.LastName,
    E.JOB,
    D.DNAME,
    D.LOC
FROM
    EMP E
INNER JOIN
    DEPT D ON E.DEPTNO = D.DEPTNO
WHERE
    (E.JOB = 'CLERK' OR E.JOB = 'ANALYST')
    AND D.LOC = 'NEW YORK';
```

**Step-by-Step Transformation:**

1.  **Conceptual Cartesian Product (`EMP` x `DEPT`) before `ON` clause filtering:**
    * The database forms every possible pair of rows between `EMP` and `DEPT`. This table would be 14 (EMP rows) * 4 (DEPT rows) = 56 rows long.
    * For brevity, we'll only show a few sample rows and the condition check.

    | E.EMPNO | E.FirstName | E.DEPTNO | D.DEPTNO | D.DNAME    | D.LOC      | ON `E.DEPTNO = D.DEPTNO` |
    | :------ | :---------- | :------- | :------- | :--------- | :--------- | :----------------------- |
    | 7369    | JOHN        | 20       | 10       | ACCOUNTING | NEW YORK   | 20 = 10 **(FALSE)** |
    | 7369    | JOHN        | 20       | 20       | RESEARCH   | DALLAS     | 20 = 20 **(TRUE)** |
    | 7369    | JOHN        | 20       | 30       | SALES      | CHICAGO    | 20 = 30 **(FALSE)** |
    | ...     | ...         | ...      | ...      | ...        | ...        | ...                      |
    | 7782    | SUSAN       | NULL     | 10       | ACCOUNTING | NEW YORK   | NULL = 10 **(FALSE)** |
    | ...     | ...         | ...      | ...      | ...        | ...        | ...                      |
    | 7839    | ANNA        | 10       | 10       | ACCOUNTING | NEW YORK   | 10 = 10 **(TRUE)** |
    | ...     | ...         | ...      | ...      | ...        | ...        | ...                      |
    | 7934    | LINDA       | 10       | 10       | ACCOUNTING | NEW YORK   | 10 = 10 **(TRUE)** |
    | ...     | ...         | ...      | ...      | ...        | ...        | ...                      |

2.  **Applying `ON E.DEPTNO = D.DEPTNO` for the `INNER JOIN`:**
    * Only rows where the `ON` condition evaluates to **TRUE** are kept. Rows with `NULL` `DEPTNO` in `EMP` cannot match, so they are naturally excluded from the inner join.

    *(Intermediate Result 1: Rows where `E.DEPTNO` matches `D.DEPTNO`)*

    | E.EMPNO | E.FirstName | E.LastName | E.JOB      | E.SAL    | E.DEPTNO | D.DEPTNO | D.DNAME      | D.LOC      |
    | :------ | :---------- | :--------- | :--------- | :------- | :------- | :------- | :----------- | :--------- |
    | 7369    | JOHN        | SMITH      | CLERK      | 800.00   | 20       | 20       | RESEARCH     | DALLAS     |
    | 7499    | ALEX        | ALLEN      | SALESMAN   | 1600.00  | 30       | 30       | SALES        | CHICAGO    |
    | 7521    | PETER       | WARD       | SALESMAN   | 1250.00  | 30       | 30       | SALES        | CHICAGO    |
    | 7566    | DAVID       | JONES      | MANAGER    | 2975.00  | 20       | 20       | RESEARCH     | DALLAS     |
    | 7654    | MARY        | MARTIN     | SALESMAN   | 1250.00  | 30       | 30       | SALES        | CHICAGO    |
    | 7698    | ROBERT      | BLAKE      | MANAGER    | 2850.00  | 30       | 30       | SALES        | CHICAGO    |
    | 7788    | MICHAEL     | SCOTT      | ANALYST    | 3000.00  | 20       | 20       | RESEARCH     | DALLAS     |
    | 7839    | ANNA        | KING       | PRESIDENT  | 5000.00  | 10       | 10       | ACCOUNTING   | NEW YORK   |
    | 7844    | THOMAS      | TURNER     | SALESMAN   | 1500.00  | 30       | 30       | SALES        | CHICAGO    |
    | 7876    | CHRIS       | ADAMS      | CLERK      | 1100.00  | 20       | 20       | RESEARCH     | DALLAS     |
    | 7902    | PATRICK     | FORD       | ANALYST    | 3000.00  | 20       | 20       | RESEARCH     | DALLAS     |
    | 7934    | LINDA       | MILLER     | CLERK      | 1300.00  | 10       | 10       | ACCOUNTING   | NEW YORK   |

3.  **Applying `WHERE (E.JOB = 'CLERK' OR E.JOB = 'ANALYST') AND D.LOC = 'NEW YORK'`:**
    * Each row from the above intermediate result is evaluated against the `WHERE` conditions.
    * `Condition 1`: (`E.JOB = 'CLERK'` OR `E.JOB = 'ANALYST'`)
    * `Condition 2`: `D.LOC = 'NEW YORK'`
    * A row is kept only if `Condition 1` AND `Condition 2` are both **TRUE**.

    | E.FirstName | E.JOB      | D.LOC      | `(E.JOB = 'CLERK' OR E.JOB = 'ANALYST')` | `D.LOC = 'NEW YORK'` | Combined Result |
    | :---------- | :--------- | :--------- | :--------------------------------------- | :------------------- | :-------------- |
    | JOHN        | CLERK      | DALLAS     | TRUE                                     | FALSE                | FALSE           |
    | ALEX        | SALESMAN   | CHICAGO    | FALSE                                    | FALSE                | FALSE           |
    | PETER       | SALESMAN   | CHICAGO    | FALSE                                    | FALSE                | FALSE           |
    | DAVID       | MANAGER    | DALLAS     | FALSE                                    | FALSE                | FALSE           |
    | MARY        | SALESMAN   | CHICAGO    | FALSE                                    | FALSE                | FALSE           |
    | ROBERT      | MANAGER    | CHICAGO    | FALSE                                    | FALSE                | FALSE           |
    | MICHAEL     | ANALYST    | DALLAS     | TRUE                                     | FALSE                | FALSE           |
    | ANNA        | PRESIDENT  | NEW YORK   | FALSE                                    | TRUE                 | FALSE           |
    | THOMAS      | SALESMAN   | CHICAGO    | FALSE                                    | FALSE                | FALSE           |
    | CHRIS       | CLERK      | DALLAS     | TRUE                                     | FALSE                | FALSE           |
    | PATRICK     | ANALYST    | DALLAS     | TRUE                                     | FALSE                | FALSE           |
    | LINDA       | CLERK      | NEW YORK   | TRUE                                     | TRUE                 | TRUE            |

    *(Intermediate Result 2: Filtered rows after WHERE clause)*

    | E.EMPNO | E.FirstName | E.LastName | E.JOB | E.SAL    | E.DEPTNO | D.DEPTNO | D.DNAME      | D.LOC      |
    | :------ | :---------- | :--------- | :---- | :------- | :------- | :------- | :----------- | :--------- |
    | 7934    | LINDA       | MILLER     | CLERK | 1300.00  | 10       | 10       | ACCOUNTING   | NEW YORK   |

4.  **`SELECT E.FirstName, E.LastName, E.JOB, D.DNAME, D.LOC`**:
    * Finally, from the remaining rows, the database selects only the specified columns.

    *(Final Result)*

    | FirstName | LastName | JOB   | DNAME      | LOC        |
    | :-------- | :------- | :---- | :--------- | :--------- |
    | LINDA     | MILLER   | CLERK | ACCOUNTING | NEW YORK   |

---

### Example: `INNER JOIN` with Three Tables and `WHERE` conditions

**Goal:** Find the employee's full name, job, department name, and their salary grade for all ANALYSTs whose salary is between 2000 and 3000 (inclusive).

**Query:**

```sql
SELECT
    E.FirstName,
    E.LastName,
    E.JOB,
    D.DNAME,
    S.GRADE
FROM
    EMP E
INNER JOIN
    DEPT D ON E.DEPTNO = D.DEPTNO
INNER JOIN
    SALGRADE S ON E.SAL BETWEEN S.LOSAL AND S.HISAL
WHERE
    E.JOB = 'ANALYST'
    AND E.SAL >= 2000 AND E.SAL <= 3000;
```

**Step-by-Step Transformation:**

1.  **Applying `ON E.DEPTNO = D.DEPTNO` for the first `INNER JOIN` (`EMP` and `DEPT`):**
    * This is the same intermediate result as in the previous example (from step 2 of the previous example).

    *(Intermediate Result 1: `EMP` rows matched with `DEPT` rows)*

    | E.EMPNO | E.FirstName | E.LastName | E.JOB      | E.SAL    | E.DEPTNO | D.DEPTNO | D.DNAME      | D.LOC      |
    | :------ | :---------- | :--------- | :--------- | :------- | :------- | :------- | :----------- | :--------- |
    | 7369    | JOHN        | SMITH      | CLERK      | 800.00   | 20       | 20       | RESEARCH     | DALLAS     |
    | 7499    | ALEX        | ALLEN      | SALESMAN   | 1600.00  | 30       | 30       | SALES        | CHICAGO    |
    | 7521    | PETER       | WARD       | SALESMAN   | 1250.00  | 30       | 30       | SALES        | CHICAGO    |
    | 7566    | DAVID       | JONES      | MANAGER    | 2975.00  | 20       | 20       | RESEARCH     | DALLAS     |
    | 7654    | MARY        | MARTIN     | SALESMAN   | 1250.00  | 30       | 30       | SALES        | CHICAGO    |
    | 7698    | ROBERT      | BLAKE      | MANAGER    | 2850.00  | 30       | 30       | SALES        | CHICAGO    |
    | 7788    | MICHAEL     | SCOTT      | ANALYST    | 3000.00  | 20       | 20       | RESEARCH     | DALLAS     |
    | 7839    | ANNA        | KING       | PRESIDENT  | 5000.00  | 10       | 10       | ACCOUNTING   | NEW YORK   |
    | 7844    | THOMAS      | TURNER     | SALESMAN   | 1500.00  | 30       | 30       | SALES        | CHICAGO    |
    | 7876    | CHRIS       | ADAMS      | CLERK      | 1100.00  | 20       | 20       | RESEARCH     | DALLAS     |
    | 7902    | PATRICK     | FORD       | ANALYST    | 3000.00  | 20       | 20       | RESEARCH     | DALLAS     |
    | 7934    | LINDA       | MILLER     | CLERK      | 1300.00  | 10       | 10       | ACCOUNTING   | NEW YORK   |

2.  **Applying `ON E.SAL BETWEEN S.LOSAL AND S.HISAL` for the second `INNER JOIN` (with `SALGRADE`):**
    * Each row from `Intermediate Result 1` is now combined with `SALGRADE` rows where `E.SAL` falls within the `LOSAL` and `HISAL` range.

    | E.FirstName | E.SAL    | D.DNAME    | S.GRADE | S.LOSAL | S.HISAL | `E.SAL BETWEEN S.LOSAL AND S.HISAL` |
    | :---------- | :------- | :--------- | :------ | :------ | :------ | :---------------------------------- |
    | JOHN        | 800.00   | RESEARCH   | 1       | 700     | 1200    | 800 BETWEEN 700 AND 1200 **(TRUE)** |
    | JOHN        | 800.00   | RESEARCH   | 2       | 1201    | 1400    | 800 BETWEEN 1201 AND 1400 **(FALSE)** |
    | ...         | ...      | ...        | ...     | ...     | ...     | ...                                 |
    | MICHAEL     | 3000.00  | RESEARCH   | 4       | 2001    | 3000    | 3000 BETWEEN 2001 AND 3000 **(TRUE)** |
    | MICHAEL     | 3000.00  | RESEARCH   | 5       | 3001    | 9999    | 3000 BETWEEN 3001 AND 9999 **(FALSE)** |
    | ...         | ...      | ...        | ...     | ...     | ...     | ...                                 |
    | LINDA       | 1300.00  | ACCOUNTING | 1       | 700     | 1200    | 1300 BETWEEN 700 AND 1200 **(FALSE)** |
    | LINDA       | 1300.00  | ACCOUNTING | 2       | 1201    | 1400    | 1300 BETWEEN 1201 AND 1400 **(TRUE)** |
    | ...         | ...      | ...        | ...     | ...     | ...     | ...                                 |

    *(Intermediate Result 2: `EMP` joined with `DEPT` and `SALGRADE`)*

    | E.EMPNO | E.FirstName | E.LastName | E.JOB      | E.SAL    | E.DEPTNO | D.DNAME      | D.LOC      | S.GRADE | S.LOSAL | S.HISAL |
    | :------ | :---------- | :--------- | :--------- | :------- | :------- | :----------- | :--------- | :------ | :------ | :------ |
    | 7369    | JOHN        | SMITH      | CLERK      | 800.00   | 20       | RESEARCH     | DALLAS     | 1       | 700     | 1200    |
    | 7499    | ALEX        | ALLEN      | SALESMAN   | 1600.00  | 30       | SALES        | CHICAGO    | 3       | 1401    | 2000    |
    | 7521    | PETER       | WARD       | SALESMAN   | 1250.00  | 30       | SALES        | CHICAGO    | 1       | 700     | 1200    |
    | 7566    | DAVID       | JONES      | MANAGER    | 2975.00  | 20       | RESEARCH     | DALLAS     | 4       | 2001    | 3000    |
    | 7654    | MARY        | MARTIN     | SALESMAN   | 1250.00  | 30       | SALES        | CHICAGO    | 1       | 700     | 1200    |
    | 7698    | ROBERT      | BLAKE      | MANAGER    | 2850.00  | 30       | SALES        | CHICAGO    | 4       | 2001    | 3000    |
    | 7788    | MICHAEL     | SCOTT      | ANALYST    | 3000.00  | 20       | RESEARCH     | DALLAS     | 4       | 2001    | 3000    |
    | 7839    | ANNA        | KING       | PRESIDENT  | 5000.00  | 10       | ACCOUNTING   | NEW YORK   | 5       | 3001    | 9999    |
    | 7844    | THOMAS      | TURNER     | SALESMAN   | 1500.00  | 30       | SALES        | CHICAGO    | 3       | 1401    | 2000    |
    | 7876    | CHRIS       | ADAMS      | CLERK      | 1100.00  | 20       | RESEARCH     | DALLAS     | 1       | 700     | 1200    |
    | 7902    | PATRICK     | FORD       | ANALYST    | 3000.00  | 20       | RESEARCH     | DALLAS     | 4       | 2001    | 3000    |
    | 7934    | LINDA       | MILLER     | CLERK      | 1300.00  | 10       | ACCOUNTING   | NEW YORK   | 2       | 1201    | 1400    |

3.  **Applying `WHERE E.JOB = 'ANALYST' AND E.SAL >= 2000 AND E.SAL <= 3000`:**
    * Each row from the above intermediate result is evaluated against the `WHERE` conditions.
    * `Condition 1`: `E.JOB = 'ANALYST'`
    * `Condition 2`: `E.SAL >= 2000`
    * `Condition 3`: `E.SAL <= 3000`
    * A row is kept only if `Condition 1` AND `Condition 2` AND `Condition 3` are all **TRUE**.

    | E.FirstName | E.JOB      | E.SAL    | `E.JOB = 'ANALYST'` | `E.SAL >= 2000` | `E.SAL <= 3000` | Combined Result |
    | :---------- | :--------- | :------- | :------------------ | :-------------- | :-------------- | :-------------- |
    | JOHN        | CLERK      | 800.00   | FALSE               | FALSE           | TRUE            | FALSE           |
    | ALEX        | SALESMAN   | 1600.00  | FALSE               | FALSE           | TRUE            | FALSE           |
    | ...         | ...        | ...      | ...                 | ...             | ...             | ...             |
    | MICHAEL     | ANALYST    | 3000.00  | TRUE                | TRUE            | TRUE            | TRUE            |
    | PATRICK     | ANALYST    | 3000.00  | TRUE                | TRUE            | TRUE            | TRUE            |
    | ...         | ...        | ...      | ...                 | ...             | ...             | ...             |
    | LINDA       | CLERK      | 1300.00  | FALSE               | FALSE           | TRUE            | FALSE           |

    *(Intermediate Result 3: Filtered rows after WHERE clause)*

    | E.EMPNO | E.FirstName | E.LastName | E.JOB     | E.SAL    | E.DEPTNO | D.DNAME    | D.LOC    | S.GRADE | S.LOSAL | S.HISAL |
    | :------ | :---------- | :--------- | :-------- | :------- | :------- | :--------- | :------- | :------ | :------ | :------ |
    | 7788    | MICHAEL     | SCOTT      | ANALYST   | 3000.00  | 20       | RESEARCH   | DALLAS   | 4       | 2001    | 3000    |
    | 7902    | PATRICK     | FORD       | ANALYST   | 3000.00  | 20       | RESEARCH   | DALLAS   | 4       | 2001    | 3000    |

4.  **`SELECT E.FirstName, E.LastName, E.JOB, D.DNAME, S.GRADE`**:
    * Finally, from the remaining rows, the database selects only the specified columns.

    *(Final Result)*

    | FirstName | LastName | JOB     | DNAME    | GRADE |
    | :-------- | :------- | :------ | :------- | :---- |
    | MICHAEL   | SCOTT    | ANALYST | RESEARCH | 4     |
    | PATRICK   | FORD     | ANALYST | RESEARCH | 4     |

---
