USE [CarDealer]
GO
/****** Object:  StoredProcedure [dbo].[DeleteUser]    Script Date: 22-09-2023 08:08:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[DeleteUser]
(
@PersonID int
)
AS
BEGIN
DELETE FROM Users
WHERE PersonID = @PersonID;
END
