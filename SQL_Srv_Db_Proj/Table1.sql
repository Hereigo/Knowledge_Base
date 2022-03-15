ALTER TABLE [dbo].[Users] DROP CONSTRAINT [FK_DepNum_Departments]
GO
DROP TABLE [dbo].[Departments]
DROP TABLE [dbo].[Users]
GO
CREATE TABLE [dbo].[Departments]
(
	[DepNum] INT NOT NULL PRIMARY KEY,
	[DepName] VARCHAR(30) NOT NULL
)
GO
INSERT INTO [dbo].[Departments] (DepNum, DepName)
OUTPUT inserted.DepNum, inserted.DepName
VALUES (1, 'Dep01'),(2, 'Dep02'),(3, 'Dep03')
GO
CREATE TABLE [dbo].[Users]
(
    [Id] UNIQUEIDENTIFIER DEFAULT NEWID() PRIMARY KEY,
	[DepartmentNum] INT NOT NULL,
	[UserName] VARCHAR(50) NOT NULL,
	[Balance] SMALLMONEY NOT NULL,
	[Registered] DATETIME2,
	CONSTRAINT [FK_DepNum_Departments] FOREIGN KEY (DepartmentNum) REFERENCES [Departments]([DepNum])
)
GO
INSERT INTO [dbo].[Users] (DepartmentNum, Balance, Registered, UserName)
VALUES
	(1, 0, DATEADD(MONTH, -1, GETDATE()), 'Alex'),
	(2, 0, DATEADD(MONTH, -2, GETDATE()), 'Felix'),
	(2, 0, DATEADD(MONTH, -3, GETDATE()), 'Max'),
	(3, 0, DATEADD(MONTH, -4, GETDATE()), 'Zeus')
GO
SELECT * FROM [dbo].[Users] ORDER BY UserName OFFSET 1 ROWS;

SELECT DISTINCT DepartmentNum, UserName FROM [dbo].[Users];

