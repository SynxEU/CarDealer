USE [CarDealer]
GO
/****** Object:  StoredProcedure [dbo].[GetCarID]    Script Date: 22-09-2023 08:08:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[GetCarID]
AS
BEGIN
SELECT CarID from dbo.Cars
END
