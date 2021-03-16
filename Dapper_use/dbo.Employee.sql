USE [AngJSAsp4_Employees]
GO

/****** Object: Table [dbo].[Employee] Script Date: 10/1/2020 2:15:48 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Employee] (
    [Emp_Id]   INT           IDENTITY (1, 1) NOT NULL,
    [Emp_Name] VARCHAR (MAX) NULL,
    [Emp_City] VARCHAR (MAX) NULL,
    [Emp_Age]  INT           NULL
);


