TRUNCATE TABLE EventQueue
TRUNCATE TABLE History
TRUNCATE TABLE PublishQueue

DECLARE @TableName VARCHAR(255)
DECLARE @sql NVARCHAR(500)
DECLARE TableCursor CURSOR FOR
SELECT OBJECT_SCHEMA_NAME([object_id])+'.'+name AS TableName
FROM sys.tables
OPEN TableCursor
FETCH NEXT FROM TableCursor INTO @TableName
WHILE @@FETCH_STATUS = 0
BEGIN
SET @sql = 'ALTER INDEX ALL ON ' + @TableName + ' REBUILD'
EXEC (@sql)
FETCH NEXT FROM TableCursor INTO @TableName
END
CLOSE TableCursor
DEALLOCATE TableCursor
GO

-- Run a few times as it seems to make a difference!
DBCC SHRINKDATABASE([$(dbname)])
DBCC SHRINKDATABASE([$(dbname)])
DBCC SHRINKDATABASE([$(dbname)])