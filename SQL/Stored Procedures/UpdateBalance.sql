USE [CarDealer]
GO
/****** Object:  StoredProcedure [dbo].[UpdateBalance]    Script Date: 22-09-2023 08:10:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[UpdateBalance]
(
@PersonID int,
@Balance int
)
AS
BEGIN
UPDATE dbo.Users
SET Balance = @Balance
WHERE PersonID = @PersonID;
END
