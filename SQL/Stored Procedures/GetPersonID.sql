USE [CarDealer]
GO
/****** Object:  StoredProcedure [dbo].[GetPersonID]    Script Date: 22-09-2023 08:09:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[GetPersonID]
AS
BEGIN
SELECT PersonId From dbo.Users
END
