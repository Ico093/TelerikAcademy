--Task4
SELECT *
FROM Departments

--Task5
SELECT dep.Name
FROM Departments dep

--Task6
SELECT CONCAT(emp.FirstName,' ',emp.LastName) as [Full Name],emp.Salary
FROM Employees emp

--Task7
SELECT CONCAT(emp.FirstName,' ',emp.LastName)  as [Full Name]
FROM Employees emp

--Task8
SELECT CONCAT(emp.FirstName,'.',emp.LastName,'@telerik.com') AS [Full Email Addresses]
FROM Employees emp

--Task9
SELECT DISTINCT emp.Salary 
FROM Employees emp

--Task10
SELECT *
FROM Employees emp
WHERE emp.JobTitle='Sales Representative'

--Task11
SELECT *
FROM Employees emp
WHERE emp.FirstName LIKE 'SA%'

--Task12
SELECT *
FROM Employees emp
WHERE emp.LastName LIKE '%ei%'

--Task13
SELECT emp.FirstName+' '+emp.LastName as [Full Name], emp.Salary 
FROM Employees emp
WHERE emp.Salary BETWEEN 20000 AND 30000
ORDER BY emp.Salary

--Task14
SELECT emp.FirstName+' '+emp.LastName as [Full Name], emp.Salary 
FROM Employees emp
WHERE emp.Salary IN (25000,14000,12500,23600)
ORDER BY emp.Salary

--Task15
SELECT emp.FirstName+' '+emp.LastName as [Full Name], emp.ManagerID
FROM Employees emp
WHERE emp.ManagerID IS NULL

--Task16
SELECT emp.FirstName+' '+emp.LastName as [Full Name], emp.Salary
FROM Employees emp
WHERE emp.Salary>50000
ORDER BY emp.Salary DESC

--Task17
SELECT TOP 5 emp.FirstName+' '+emp.LastName as [Full Name], emp.Salary
FROM Employees emp
ORDER BY emp.Salary DESC

--Task18
SELECT emp.FirstName+' '+emp.LastName as [Full Name],ad.AddressText as [Address]
FROM Employees emp JOIN Addresses ad
ON emp.AddressID=ad.AddressID

--Task19
SELECT emp.FirstName+' '+emp.LastName as [Full Name],ad.AddressText as [Address]
FROM Employees emp,Addresses ad
WHERE emp.AddressID=ad.AddressID

--Task20
SELECT emp.FirstName+' '+emp.LastName as [Full Name of Employee], man.FirstName+' '+man.LastName as [Full Name of Manager]
FROM Employees emp LEFT JOIN Employees man
ON emp.ManagerID = man.EmployeeID

--Task21
SELECT emp.FirstName+' '+emp.LastName as [Full Name of Employee], man.FirstName+' '+man.LastName as [Full Name of Manager], ad.AddressText as [Employee Address]
FROM Employees emp LEFT JOIN Employees man
ON emp.ManagerID = man.EmployeeID
LEFT JOIN Addresses ad
ON emp.AddressID=ad.AddressID

--Task22
SELECT d.Name
FROM Departments d 
UNION
SELECT t.Name
FROM Towns t

--Task23
SELECT emp.FirstName+' '+emp.LastName as [Full Name of Employee], man.FirstName+' '+man.LastName as [Full Name of Manager]
FROM Employees emp LEFT JOIN Employees man
ON emp.ManagerID = man.EmployeeID

SELECT emp.FirstName+' '+emp.LastName as [Full Name of Employee], man.FirstName+' '+man.LastName as [Full Name of Manager]
FROM Employees man Right JOIN Employees emp
ON emp.ManagerID = man.EmployeeID

--Task24
SELECT emp.FirstName+' '+emp.LastName as [Full Name of Employee], dep.Name, emp.HireDate
FROM Employees emp LEFT JOIN Departments dep
ON emp.DepartmentID = dep.DepartmentID
WHERE (dep.Name IN ('Sales','Finance')) AND (emp.HireDate BETWEEN '1.1.1995' AND '1.1.2005')
ORDER BY emp.HireDate
