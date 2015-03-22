CREATE PROC dbo.usp_TotalIncome(@name varchar(50),@start datetime, @end datetime)
AS
SELECT s.CompanyName, p.ProductName, ord.OrderDate
FROM Orders ord JOIN [Order Details] odet 
	 ON ord.OrderID=odet.OrderID
	 JOIN Products p
	 ON odet.ProductID=p.ProductID
	 JOIN Suppliers s
	 ON p.SupplierID=s.SupplierID
WHERE s.CompanyName=@name
	  AND ord.OrderDate>= CONVERT (datetime, @start , 104)
	  AND ord.OrderDate<= CONVERT (datetime, @end , 104)
