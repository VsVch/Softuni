DECLARE @TableName NVARCHAR(MAX) = 'Employees'
EXEC('SELECT * FROM ' + @TableName)