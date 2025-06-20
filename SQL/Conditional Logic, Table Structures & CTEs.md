
# SQL Server Essentials: Conditional Logic, Table Structures & CTEs

## Data Setup for Assignments
Before starting the assignments, please execute the following SQL script to create our sample `EMP` and `DEPT` tables. We will use these tables for most of our exercises.

```sql
-- Create DEPT Table
CREATE TABLE DEPT (
    DEPTNO INT PRIMARY KEY,
    DNAME VARCHAR(14) NOT NULL,
    LOC VARCHAR(13) NOT NULL
);

-- Insert data into DEPT Table
INSERT INTO DEPT (DEPTNO, DNAME, LOC) VALUES
(10, 'ACCOUNTING', 'NEW YORK'),
(20, 'RESEARCH', 'DALLAS'),
(30, 'SALES', 'CHICAGO'),
(40, 'OPERATIONS', 'BOSTON');

-- Create EMP Table
CREATE TABLE EMP (
    EMPNO INT PRIMARY KEY,
    FirstName VARCHAR(20) NOT NULL,
    LastName VARCHAR(20) NOT NULL,
    JOB VARCHAR(9) NOT NULL,
    MGR INT,
    HIREDATE DATETIME NOT NULL,
    SAL DECIMAL(7, 2) NOT NULL,
    COMM DECIMAL(7, 2), -- Commission can be NULL
    DEPTNO INT,
    FOREIGN KEY (DEPTNO) REFERENCES DEPT(DEPTNO)
);

-- Insert data into EMP Table
INSERT INTO EMP (EMPNO, FirstName, LastName, JOB, MGR, HIREDATE, SAL, COMM, DEPTNO) VALUES
(7369, 'JOHN', 'SMITH', 'CLERK', 7902, '1980-12-17', 800.00, NULL, 20),
(7499, 'ALEX', 'ALLEN', 'SALESMAN', 7698, '1981-02-20', 1600.00, 300.00, 30),
(7521, 'PETER', 'WARD', 'SALESMAN', 7698, '1981-02-22', 1250.00, 500.00, 30),
(7566, 'DAVID', 'JONES', 'MANAGER', 7839, '1981-04-02', 2975.00, NULL, 20),
(7654, 'MARY', 'MARTIN', 'SALESMAN', 7698, '1981-09-28', 1250.00, 1400.00, 30),
(7698, 'ROBERT', 'BLAKE', 'MANAGER', 7839, '1981-05-01', 2850.00, NULL, 30),
(7782, 'SUSAN', 'CLARK', 'MANAGER', 7839, '1981-06-09', 2450.00, NULL, NULL), -- Employee with NULL DEPTNO
(7788, 'MICHAEL', 'SCOTT', 'ANALYST', 7566, '1982-12-09', 3000.00, NULL, 20),
(7839, 'ANNA', 'KING', 'PRESIDENT', NULL, '1981-11-17', 5000.00, NULL, 10),
(7844, 'THOMAS', 'TURNER', 'SALESMAN', 7698, '1981-09-08', 1500.00, 0.00, 30),
(7876, 'CHRIS', 'ADAMS', 'CLERK', 7788, '1983-01-12', 1100.00, NULL, 20),
(7900, 'JOHN', 'JAMES', 'CLERK', 7698, '1981-12-03', 950.00, NULL, NULL), -- Another employee with NULL DEPTNO
(7902, 'PATRICK', 'FORD', 'ANALYST', 7566, '1981-12-03', 3000.00, NULL, 20),
(7934, 'LINDA', 'MILLER', 'CLERK', 7782, '1982-01-23', 1300.00, NULL, 10);
```

---

## 1. Conditional Logic with `IIF()` and `CASE`
These functions allow you to introduce "if-then-else" logic directly into your queries, returning different values based on specified conditions.

### `IIF()` (SQL Server 2012+)
A shorthand for a simple `CASE` expression, ideal for binary (true/false) conditions.
* **Syntax:** `IIF(boolean_expression, true_value, false_value)`

### `CASE` Expression
The most versatile way to apply conditional logic. Can handle multiple conditions and provide a default `ELSE` value.
* **Simple CASE Syntax:**
    ```sql
    CASE expression
        WHEN value1 THEN result1
        WHEN value2 THEN result2
        [ELSE else_result]
    END
    ```
* **Searched CASE Syntax:**
    ```sql
    CASE
        WHEN condition1 THEN result1
        WHEN condition2 THEN result2
        [ELSE else_result]
    END
    ```

---

### Assignments - Conditional Logic

**Assignment 1.1: Using `IIF()` for Bonus Status**
Write a query that displays `FirstName`, `LastName`, `SAL`, and a new column called `BonusStatus`.
* If `SAL` is greater than or equal to 3000, `BonusStatus` should be 'High Salary Bonus'.
* Otherwise, `BonusStatus` should be 'Standard Bonus'.

**Assignment 1.2: Categorizing Employees with `CASE` (Simple)**
Display `FirstName`, `LastName`, `JOB`, and a new column `JobCategory`.
* If `JOB` is 'MANAGER', `JobCategory` should be 'Leadership'.
* If `JOB` is 'ANALYST', `JobCategory` should be 'Technical'.
* For all other jobs, `JobCategory` should be 'Support Staff'.

**Assignment 1.3: Complex Salary Bands with `CASE` (Searched)**
Create a query showing `FirstName`, `LastName`, `SAL`, and a column `SalaryBand`.
* If `SAL` is 5000, `SalaryBand` is 'Top Executive'.
* If `SAL` is between 3000 and 4999 (inclusive), `SalaryBand` is 'Senior Staff'.
* If `SAL` is between 1500 and 2999 (inclusive), `SalaryBand` is 'Mid-Level Staff'.
* If `SAL` is less than 1500, `SalaryBand` is 'Junior Staff'.

---

## 2. NULL Handling Functions
`NULL` in SQL means "unknown" or "no value," and it behaves differently from 0 or an empty string. These functions help you manage `NULL`s.

### `ISNULL()`
Replaces `NULL` with a specified replacement value.
* **Syntax:** `ISNULL(expression, replacement_value)`

### `COALESCE()`
Evaluates arguments in order and returns the first non-`NULL` expression. It can take multiple arguments.
* **Syntax:** `COALESCE(expression1, expression2, expression3, ...)`

### Concatenation with `+` and `CONCAT()`
* **`+` Operator:** If any part of a string concatenation using `+` is `NULL`, the entire result becomes `NULL`.
* **`CONCAT()` (SQL Server 2012+):** Treats `NULL` inputs as empty strings, so the result is never `NULL` unless all arguments are `NULL`.

---

### Assignments - NULL Handling & Concatenation

**Assignment 2.1: Default Commission with `ISNULL()`**
Write a query to display `FirstName`, `LastName`, `COMM`. Add a new column `EffectiveCommission` that shows the actual `COMM` value, but if `COMM` is `NULL`, display `0.00` instead.

**Assignment 2.2: Prioritizing Contact Info with `COALESCE()`**
Imagine our `EMP` table had an `Email` and `Phone` column (for this exercise, just use `COMM` and `MGR` to simulate nullable contact info).
Write a query that displays `FirstName`, `LastName`, and a new column `PreferredContact`.
* If `COMM` is not `NULL`, `PreferredContact` should be 'Has Commission'.
* If `COMM` is `NULL` but `MGR` is not `NULL`, `PreferredContact` should be 'Has Manager'.
* If both `COMM` and `MGR` are `NULL`, `PreferredContact` should be 'No Specific Contact'.
    *Hint: You'll need to combine `COALESCE` with `CASE` or `IIF`.*

**Assignment 2.3: Full Name Concatenation**
Display `FirstName`, `LastName`, and a `FullName` column.
* **Part A:** Create `FullName` using the `+` operator. Observe what happens if `FirstName` or `LastName` were `NULL` (they are `NOT NULL` in our current schema, but consider the behavior).
* **Part B:** Create `FullName` using the `CONCAT()` function. Explain the difference in behavior if any part were `NULL`. (No actual NULLs will appear in this output for `FirstName`/`LastName` due to schema, but understand the theoretical difference).

---

## 3. Understanding Table Structures in SQL Server
SQL Server offers various ways to store and manipulate data, from persistent disk-based tables to temporary memory-based structures.

### 3.1 Permanent Tables (Base Tables)
* **Description:** The standard tables you `CREATE TABLE` and store data persistently on disk. They exist until explicitly `DROP`ped. `EMP` and `DEPT` are examples.
* **Persistence:** Stored permanently.
* **Scope:** Accessible from any session (with permissions).

### 3.2 Inline/Derived Tables
* **Description:** A subquery used in the `FROM` clause of another `SELECT` statement. It's essentially a temporary, unnamed result set that exists only for the duration of the query.
* **Persistence:** Only for the query's execution.
* **Scope:** Local to the query.
* **Example from today:** `SELECT 1 AS id UNION SELECT 2` used as a table.
    ```sql
    SELECT my_id FROM (SELECT 1 AS id UNION ALL SELECT 2 AS id UNION ALL SELECT 3 AS id) AS MyNumbers;
    ```

### 3.3 Table Variables (`DECLARE @table_variable TABLE`)
* **Description:** A special type of local variable that stores a result set. They are primarily memory-resident (though can spill to tempdb) and are useful for small to medium-sized data sets.
* **Persistence:** Only for the batch/stored procedure where they are declared. Automatically dropped when they go out of scope.
* **Scope:** Local to the current batch, stored procedure, or function.
* **Example from today:** `DECLARE @temp TABLE(id INT)`

### 3.4 Local Temporary Tables (`CREATE TABLE #local_temp_table`)
* **Description:** Temporary tables that are physically created in the `tempdb` database. They are session-specific and automatically dropped when the session that created them ends (or explicitly `DROP`ped).
* **Persistence:** Until the session ends or explicitly dropped.
* **Scope:** Local to the current session (connection).
* **Example from today:** `CREATE TABLE #t(...)`

### 3.5 Global Temporary Tables (`CREATE TABLE ##global_temp_table`)
* **Description:** Similar to local temp tables, but they are accessible from any session by any user. They are dropped when the last session referencing them disconnects.
* **Persistence:** Until the last session referencing them disconnects or explicitly dropped.
* **Scope:** Global (across all sessions).
* **Example from today:** `CREATE TABLE ##Gt(...)`

---

### Assignments - Table Structures

**Assignment 3.1: Using an Inline/Derived Table**
Write a query that displays the `FirstName`, `LastName`, `JOB`, and `SAL` of employees. Join this data with an inline/derived table that provides a `SalaryMultiplier` based on their `JOB`.
* The derived table should have two columns: `JobRole` and `Multiplier`.
* `JobRole = 'SALESMAN'`, `Multiplier = 1.10`
* `JobRole = 'CLERK'`, `Multiplier = 1.05`
* For all other jobs, assume `Multiplier = 1.00`.
* Calculate a `ProjectedSalary` by multiplying `SAL` with the `Multiplier`.

**Assignment 3.2: Storing & Querying with a Table Variable**
1.  Declare a table variable named `@HighEarners` with columns `EmpName` (VARCHAR), `JobTitle` (VARCHAR), and `CurrentSalary` (DECIMAL).
2.  Insert all employees with `SAL >= 2500` into this table variable.
3.  Write a `SELECT` statement to retrieve all data from `@HighEarners`.

**Assignment 3.3: Processing Data with a Local Temporary Table**
1.  Create a local temporary table named `#DeptStats` with columns `DeptName` (VARCHAR), `TotalEmployees` (INT), and `AvgSalary` (DECIMAL).
2.  Insert data into `#DeptStats` by calculating the total number of employees and average salary for each department from the `EMP` table.
    * *Hint: You'll need to use `GROUP BY`.*
3.  Write a `SELECT` statement to retrieve all data from `#DeptStats`.
4.  After running the `SELECT`, try to `SELECT` from `#DeptStats` again in a **new query window** (new session) and observe what happens.

**Assignment 3.4: Demonstrating Global Temporary Table Scope**
1.  In your current query window, create a global temporary table named `##MyGlobalTable` with an `ID` column (INT) and a `Message` column (VARCHAR).
2.  Insert a single row into `##MyGlobalTable` (e.g., `(1, 'Hello from Session 1')`).
3.  Open a **new SQL Server Management Studio (SSMS) query window** (this creates a new session).
4.  In the *new* query window, try to `SELECT * FROM ##MyGlobalTable`.
5.  In your *original* query window, `DROP TABLE ##MyGlobalTable;`.
6.  Go back to the *new* query window and try to `SELECT * FROM ##MyGlobalTable` again. Explain what you observe regarding its accessibility and persistence.

---

## 4. Common Table Expressions (CTEs)
CTEs are a powerful, readable, and often more efficient way to manage complex queries by defining temporary, named result sets that you can reference within a single `SELECT`, `INSERT`, `UPDATE`, or `DELETE` statement. They improve readability and can make complex logic easier to understand.

* **Syntax:**
    ```sql
    WITH CTE_Name (Column1, Column2, ...) AS (
        -- Your SELECT statement that defines the CTE's result set
        SELECT ColumnA, ColumnB FROM YourTable WHERE ...
    )
    -- Now you can query the CTE as if it were a table
    SELECT *
    FROM CTE_Name
    WHERE Column1 > 10;

    -- Multiple CTEs
    WITH CTE_Name1 AS (
        -- Query for CTE1
    ),
    CTE_Name2 AS (
        -- Query for CTE2 (can reference CTE_Name1)
    )
    SELECT ...
    FROM CTE_Name1
    JOIN CTE_Name2 ON ...;
    ```

---

### Assignments - Common Table Expressions (CTEs)

**Assignment 4.1: Simple CTE for Department List**
Use a CTE to first select all department names and locations. Then, from this CTE, select only the departments located in 'NEW YORK'.

**Assignment 4.2: Multiple CTEs for Employee and Department Details**
1.  Create a CTE named `EmployeeSalaries` that selects `FirstName`, `LastName`, `SAL`, and `DEPTNO` for all employees.
2.  Create a second CTE named `DepartmentLocations` that selects `DEPTNO`, `DNAME`, and `LOC` for all departments.
3.  Using these two CTEs, write a final `SELECT` statement that joins them to display `FirstName`, `LastName`, `SAL`, `DNAME`, and `LOC` for all employees.

**Assignment 4.3: CTE for Manager Details**
Create a CTE that identifies all employees who are `JOB = 'MANAGER'`. Then, from this CTE, select their `FirstName`, `LastName`, and `EMPNO`, ordered by `LastName`.

---

## 5. Window Functions (Advanced Analytics)
Window functions perform calculations across a set of table rows that are related to the current row. They are incredibly powerful for ranking, running totals, and more, without collapsing rows like `GROUP BY`.

### Ranking Functions
* **`ROW_NUMBER()`:** Assigns a unique, sequential number to each row within its partition, starting at 1. (No ties).
* **`RANK()`:** Assigns a rank within its partition. If values are tied, they receive the same rank, and the next rank is skipped.
* **`DENSE_RANK()`:** Assigns a rank within its partition. If values are tied, they receive the same rank, and the next rank is *not* skipped.
* **`NTILE(N)`:** Divides the rows in an ordered partition into a specified number of groups (N).

* **Common Syntax Pattern:**
    ```sql
    FUNCTION_NAME() OVER (
        [PARTITION BY column1, column2, ...] -- Optional: divides data into groups
        ORDER BY column3 [ASC|DESC], column4 [ASC|DESC], ... -- Required: defines order within each partition
    )
    ```

---

### Assignments - Window Functions

**Assignment 5.1: Employee Ranking by Salary within Department**
Display `FirstName`, `LastName`, `DEPTNO`, `SAL`, and a new column `RankInDeptBySalary`.
* `RankInDeptBySalary` should assign a rank to employees based on their `SAL` within each `DEPTNO`.
* Employees with the same salary in the same department should receive the same rank.
* The next rank should *not* be skipped (e.g., if two people are rank 1, the next is rank 2).

**Assignment 5.2: Top Employee in Each Job Role**
For each `JOB` role, find the employee with the highest salary. Display `JOB`, `FirstName`, `LastName`, and `SAL`.
* *Hint: Use `ROW_NUMBER()` or `RANK()` partitioned by `JOB` and ordered by `SAL` descending, then filter for rank 1.*

**Assignment 5.3: Creating Salary Quintiles**
Display `FirstName`, `LastName`, `SAL`, and a new column `SalaryQuintile`.
* `SalaryQuintile` should divide all employees into 5 salary groups (quintiles) based on their salary, from lowest to highest.

---

## 6. Good Practices: Comments
* **`--` (Single-line comment):** Everything from `--` to the end of the line is a comment.
* **`/* ... */` (Multi-line comment):** Everything between `/*` and `*/` is a comment.

* **Importance:**
    * **Readability:** Explains complex logic or business rules.
    * **Maintainability:** Helps others (or your future self!) understand the code.
    * **Debugging:** Temporarily disable parts of a query.

---
