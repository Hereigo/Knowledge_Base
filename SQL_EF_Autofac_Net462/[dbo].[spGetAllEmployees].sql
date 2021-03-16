USE [MyEmplyees]
GO
/****** Object:  StoredProcedure [dbo].[spGetAllEmployees]    Script Date: 09.01.2020 9:38:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[spGetAllEmployees] AS BEGIN
SET
    NOCOUNT ON
SELECT
    EmployeeID,
    LastName,
    Email,
    PhoneNumber
FROM
    Employees
END