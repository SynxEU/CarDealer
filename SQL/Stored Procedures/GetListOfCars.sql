USE [CarDealer]
GO
/****** Object:  StoredProcedure [dbo].[GetListOfCars]    Script Date: 22-09-2023 08:08:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[GetListOfCars]
AS
BEGIN
SELECT * FROM dbo.Cars
END
