CREATE PROC sp_AddAndMultiply
	(@FirstNumber INT, @SecondNumber INT,
	@Sum INT OUTPUT, @Product INT OUTPUT)
AS
	SET @Sum = @FirstNumber + @SecondNumber
	SET @Product = @FirstNumber + @SecondNumber
GO

DECLARE @Sum INT;
DECLARE @Prod INT;
EXEC sp_AddAndMultiply 2, 3, @Sum OUTPUT, @Prod OUTPUT
SELECT @Sum AS SUM, @Prod AS Product