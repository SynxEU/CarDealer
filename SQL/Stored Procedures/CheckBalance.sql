USE [CarDealer]
GO
/****** Object:  StoredProcedure [dbo].[CheckBalance]    Script Date: 22-09-2023 08:07:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[CheckBalance]
(
@PersonID Int
)
AS
BEGIN
SELECT Balance
From dbo.Users
WHERE PersonID = @PersonID;
END
