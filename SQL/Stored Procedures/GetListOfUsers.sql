USE [CarDealer]
GO
/****** Object:  StoredProcedure [dbo].[GetListOfUsers]    Script Date: 22-09-2023 08:08:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[GetListOfUsers]
AS
BEGIN
SELECT * From dbo.Users
END
