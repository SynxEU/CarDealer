USE [CarDealer]
GO
/****** Object:  StoredProcedure [dbo].[GetPerson]    Script Date: 22-09-2023 08:09:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[GetPerson]
(
@PersonID Int
)
AS
BEGIN
SELECT * From dbo.Users
WHERE PersonID = @PersonID;
END
