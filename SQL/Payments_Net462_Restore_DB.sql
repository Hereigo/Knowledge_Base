USE [master]
GO

-- IF NOT EXISTS :
-- CREATE DATABASE MyExpenses

-- TO SEE LOGICAL NAME IF NEEDED :
-- RESTORE FILELISTONLY FROM DISK = '\Downloads\myExpenses20200419.bak'

RESTORE DATABASE [MyExpenses] FROM DISK = '\Downloads\myExpenses20200419.bak'
WITH 
MOVE 'MyExpenses_Data' TO '%USERPROFILE%\MyExpenses.mdf'
-- , MOVE 'MyExpenses_Log' TO '%USERPROFILE%\MyExpenses.ldf'
-- ,
-- REPLACE;
