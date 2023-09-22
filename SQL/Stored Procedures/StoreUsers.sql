USE [CarDealer]
GO
/****** Object:  StoredProcedure [dbo].[StoreUsers]    Script Date: 22-09-2023 08:09:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[StoreUsers]
(
@fName nvarchar (50),
@lName nvarchar (50),
@bal Int,
@type Int
)
AS
BEGIN
INSERT INTO dbo.Users (FirstName, LastName, Balance, Type)
VALUES (@fName,@lName,@bal,@type)
END