-- AFTER CREATE DB - ADD NEW ADO EDM TO THE PROJECT !

CREATE DATABASE [AngJSAsp4_Employees];
GO

USE [AngJSAsp4_Employees] CREATE TABLE [dbo].[Employee](
    [Emp_Id] [int] IDENTITY(1, 1) NOT NULL,
    [Emp_Name] [varchar](max) NULL,
    [Emp_City] [varchar](max) NULL,
    [Emp_Age] [int] NULL,
    CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED ([Emp_Id] ASC) WITH (
        PAD_INDEX = OFF,
        STATISTICS_NORECOMPUTE = OFF,
        IGNORE_DUP_KEY = OFF,
        ALLOW_ROW_LOCKS = ON,
        ALLOW_PAGE_LOCKS = ON
    ) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT INTO
    [dbo].[Employee] (Emp_Name, Emp_Age, Emp_City)
VALUES
    ('Alex', 11, 'San Andreas'),
    ('Alexandra', 22, 'Kharkiv'),
    ('Felix', 33, 'L.A.'),
    ('Max', 44, 'Lviv'),
    ('Maria', 55, 'N.Y.'),
    ('Jose', 77, 'Kyiv')

-- AFTER CREATE DB - ADD NEW ADO EDM TO THE PROJECT !