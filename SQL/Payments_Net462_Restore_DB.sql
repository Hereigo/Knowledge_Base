USE [master]
GO

-- IF NOT EXISTS :
-- CREATE DATABASE MyExpenses

-- TO SEE LOGICAL NAME IF NEEDED :
-- RESTORE FILELISTONLY FROM DISK = '\Downloads\MyExpenses_autobackup_368918_2020-06-03T22-19-03.bak'

RESTORE DATABASE [MyExpenses] FROM DISK = '\Downloads\MyExpenses_autobackup_368918_2020-06-03T22-19-03.bak'
WITH 
MOVE 'MyExpenses_Data' TO '%USERPROFILE%\MyExpenses.mdf'
, MOVE 'MyExpenses_Log' TO '%USERPROFILE%\MyExpenses.ldf'
, REPLACE;

-- NOT SELECT [MyExpenses] DataBase while connect to the SQL Server !