--Task 1

CREATE PROC dbo.usp_FullNameOfPersons
AS
SELECT FirstName+' '+LastName as [Full Name]
FROM Persons

EXEC usp_FullNameOfPersons

--Task 2

CREATE PROC dbo.usp_MoreThan(@money int = 0)
AS
SELECT e.FirstName+' '+e.LastName as [Full Name], a.Ballance
FROM Persons e LEFT JOIN Accounts a
	 ON e.id=a.PersonID
WHERE a.Ballance>@money

EXEC usp_MoreThan 20

--Task 3

CREATE PROC dbo.usp_Calculate(@sum money, @interestrate float, @months int)
AS
SELECT @sum/100*@interestrate*@months as [Sum]
RETURN @sum/100*@interestrate*@months

EXEC usp_Calculate 128455712,2,12

--Task 4

CREATE PROC dbo.usp_GiveInterest(@accountid int,@interestrate float)
AS 
BEGIN
DECLARE @Ballance int
SELECT @Ballance = Ballance FROM Accounts WHERE id=@accountid
DECLARE @NewBallance int
EXEC @NewBallance = usp_Calculate @Ballance,@interestrate,1
SET @NewBallance=@NewBallance+@Ballance
UPDATE Accounts
SET Ballance=@NewBallance
WHERE id=@accountid
END

EXEC usp_GiveInterest 2,2

--Task 5

CREATE PROC dbo.usp_WithdrawMoney (@accountid int,@money int)
AS
BEGIN
DECLARE @Ballance int
SELECT @Ballance = Ballance FROM Accounts WHERE id=@accountid
UPDATE Accounts
SET Ballance=@Ballance-@money
WHERE id=@accountid
END

CREATE PROC dbo.usp_DepositMoney (@accountid int,@money int) 
AS
BEGIN
DECLARE @Ballance int
SELECT @Ballance = Ballance FROM Accounts WHERE id=@accountid
UPDATE Accounts
SET Ballance=@Ballance+@money
WHERE id=@accountid
END

EXEC usp_WithdrawMoney 2, 2
EXEC usp_DepositMoney 2, 2

--Task 6
CREATE TRIGGER tr_AccountsUpdate ON Accounts
 FOR UPDATE
AS
DECLARE @OldSum money
SELECT @OldSum = Ballance FROM deleted
DECLARE @NewSum money
SELECT @NewSum = Ballance FROM inserted
DECLARE @AccountID int
SELECT @AccountID = id from inserted
INSERT INTO Logs (AccountID, OldSum, NewSum)
VALUES (@AccountID, @OldSum, @NewSum)

