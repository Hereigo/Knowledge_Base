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
INSERT INTO [dbo].[Users] (DepartmentNum, Balance, UserName)
OUTPUT inserted.Id, inserted.UserName
VALUES
	(1, 0, 'Alex'),
	(2, 0, 'Felix'),
	(2, 0, 'Max'),
	(3, 0, 'Zeus')
GO
