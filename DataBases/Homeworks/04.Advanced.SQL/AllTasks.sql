--Task1

SELECT e.FirstName+' '+e.LastName, e.Salary
FROM Employees e
WHERE e.Salary=
	(SELECT MIN(em.Salary)
	FROM Employees em)

--Task2

SELECT e.FirstName+' '+e.LastName, e.Salary
FROM Employees e
WHERE e.Salary<
	(SELECT MIN(em.Salary)
	FROM Employees em)*0.1
	+(SELECT MIN(em.Salary)
	FROM Employees em)

--Task3

SELECT e.FirstName+' '+e.LastName, e.Salary, d.DepartmentID
FROM Employees e JOIN Departments d
	ON e.DepartmentID=d.DepartmentID
WHERE e.Salary=
	(SELECT MIN(emp.Salary)
	 FROM Employees emp
	 WHERE emp.DepartmentID=e.DepartmentID)

--Task4

SELECT AVG(e.Salary) as [Average Salary]
FROM Employees e JOIN Departments d
	ON e.DepartmentID=d.DepartmentID
GROUP BY d.DepartmentID
HAVING d.DepartmentID=1

--Task5

SELECT AVG(e.Salary) as [Average Salary]
FROM Employees e JOIN Departments d
	ON e.DepartmentID=d.DepartmentID
GROUP BY d.Name
HAVING d.Name='Sales'

--Task6

SELECT COUNT(*) as [Employees in Sales]
FROM Employees e JOIN Departments d
	ON e.DepartmentID=d.DepartmentID
GROUP BY d.Name
HAVING d.Name='Sales'

--Task7

SELECT COUNT(*) [Number of Employees with Manager]
FROM Employees e JOIN Employees m
	ON e.ManagerID=m.EmployeeID

--Task8

SELECT COUNT(*) [Number of Employees without Manager]
FROM Employees e LEFT JOIN Employees m
	ON e.ManagerID=m.EmployeeID
WHERE e.ManagerID is NULL

--Task9

SELECT d.DepartmentID,d.Name,AVG(e.Salary)
FROM Departments d LEFT JOIN Employees e
	ON d.DepartmentID=e.DepartmentID
GROUP BY d.DepartmentID, d.Name

--Task10

SELECT d.DepartmentID,d.Name as [Departament Name],t.Name as [Town Name],COUNT(*) as [Number of Employees]
FROM Departments d LEFT JOIN Employees e
	ON d.DepartmentID=e.DepartmentID
		LEFT JOIN Addresses a
	ON a.AddressID=e.AddressID
		LEFT JOIN Towns t
	ON t.TownID=a.TownID
GROUP BY d.DepartmentID, d.Name,t.Name
ORDER BY d.DepartmentID

--Task11

SELECT m.FirstName,m.LastName, COUNT(*) as [Number of Employees]
FROM Employees e JOIN Employees m
	ON e.ManagerID=m.EmployeeID
GROUP BY m.EmployeeID,m.FirstName,m.LastName
HAVING COUNT(*)=5

--Task 12

SELECT e.FirstName + ' ' + e.LastName as [Employee], COALESCE(m.FirstName + ' ' + m.LastName,'no manager') as [Manager]
FROM Employees e LEFT JOIN Employees m
	ON e.ManagerID=m.EmployeeID

--Task 13

SELECT e.FirstName, e.LastName, LEN(e.LastName) as [Length of Last Name]
FROM Employees e
WHERE LEN(e.LastName)=5

--Task 14

SELECT GETDATE() 'Today', 
       CONVERT(VARCHAR(30), GETDATE(), 104) + ' ' + CONVERT(VARCHAR(30), GETDATE(), 114) as [FormatTime]

--Task 15

CREATE TABLE Users (
  UserID int IDENTITY,
  UserName nvarchar(100) NOT NULL UNIQUE,
  UserPassword nvarchar(100) NOT NULL,
  FullName nvarchar(100) NOT NULL,
  LastLogIn datetime,
  CONSTRAINT PK_Users PRIMARY KEY(UserID),
  CHECK (LEN(UserPassword)>=5)
)

--Task 16

CREATE VIEW [All Users from Today] AS
SELECT UserName,LastLogIn FROM Users
WHERE LastLogIn=(SELECT CONVERT(char(10), GetDate(),126))

--Task 17

CREATE TABLE Groups (
  GroupID int IDENTITY,
  GroupName nvarchar(100) NOT NULL UNIQUE,
  CONSTRAINT PK_Groups PRIMARY KEY(GroupID)
)

--Task 18

ALTER TABLE Users ADD GroupID int
ALTER TABLE Users
ADD CONSTRAINT FK_Users_Groups
  FOREIGN KEY (GroupID)
  REFERENCES Groups(GroupID)

--Task 19

DECLARE @counter int;
SET @counter = 5;
WHILE @counter>0
BEGIN
	INSERT INTO Groups(GroupName)
	VALUES ('Group'+CONVERT(nvarchar(10),5-@counter));
	INSERT INTO Users(UserName,UserPassword,FullName,LastLogIn)
	VALUES ('User'+CONVERT(nvarchar(10),5-@counter),'akjhag','User with number'+CONVERT(nvarchar(10),5-@counter),GETDATE());
	SET @counter-=1;
END;

--Task 20

UPDATE Users
SET FullName='Te tuk sh sa ebe'
WHERE UserID=1

--Task 21

UPDATE Users 
SET GroupID=NULL
WHERE GroupID=3

DELETE FROM Groups 
WHERE GroupID=3

--Task 22

INSERT INTO Users(UserName,UserPassword,FullName,LastLogIn)
SELECT LOWER(LEFT(e.FirstName,9)+LEFT(e.LastName,9)),LOWER(LEFT(e.FirstName,3)+LEFT(e.LastName,3)),e.FirstName+' '+e.LastName,NULL
FROM Employees e

--Task 23 

UPDATE Users
SET UserPassword=NULL
WHERE LastLogIn<CONVERT (datetime, '10.03.2010', 104)

--Task 24

DELETE FROM Users
WHERE UserPassword is NULL

--Task 25

SELECT d.Name,e.JobTitle,AVG(e.Salary) as 'Salary by Title and Department'
FROM Employees e JOIN Departments d
	ON e.DepartmentID=d.DepartmentID
GROUP BY d.Name,e.JobTitle

--Task 26

SELECT d.Name,e.JobTitle,MIN(e.FirstName) as 'First Name',MIN(e.LastName) as 'Last Name',MIN(e.Salary) as 'Salary by Title and Department'
FROM Employees e JOIN Departments d
	ON e.DepartmentID=d.DepartmentID
GROUP BY d.Name,e.JobTitle

--Task 27

SELECT TOP 1 t.Name, COUNT(*) as 'Employees'
FROM Employees e JOIN Addresses a
	ON e.AddressID=a.AddressID
	JOIN Towns t
	ON a.TownID=t.TownID
GROUP BY t.Name
ORDER BY COUNT(*) DESC

--Task 28

SELECT t.Name, COUNT(*) as 'Managers'
FROM Employees e JOIN Employees m
	ON e.ManagerID=m.EmployeeID
	JOIN Addresses a
	ON m.AddressID=a.AddressID
	JOIN Towns t
	ON a.TownID=t.TownID
GROUP BY t.Name,m.EmployeeID
ORDER BY COUNT(*) DESC

--Task 30
BEGIN TRAN
UPDATE Departments
SET ManagerID=NULL
WHERE ManagerID IN (SELECT e.ManagerID FROM Employees e JOIN Departments d
	ON e.DepartmentID=d.DepartmentID
WHERE d.Name='Sales')

DELETE e FROM Employees as e JOIN Departments d
	ON e.DepartmentID=d.DepartmentID
WHERE d.Name='Sales'

ROLLBACK TRAN


--Task 31

BEGIN TRAN
	CREATE DATABASE TelerikAcademy_snapshot1900 
	ON (NAME = TelerikAcademy_Data, FILENAME = 'TelerikAcademy_snapshot1900.ss')
	AS SNAPSHOT OF TelerikAcademy;

	DROP TABLE EmployeesProjects
	-- ROLLBACK TRAN
GO


--Task 32

BEGIN TRAN
	SELECT * INTO #TempEmployeesProjects 
	FROM EmployeesProjects;

	DROP TABLE EmployeesProjects;

	SELECT * INTO EmployeesProjects
	FROM #TempEmployeesProjects;

	DROP TABLE #TempEmployeesProjects
GO


