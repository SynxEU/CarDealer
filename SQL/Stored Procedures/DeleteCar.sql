USE [CarDealer]
GO
/****** Object:  StoredProcedure [dbo].[DeleteCar]    Script Date: 22-09-2023 08:07:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[DeleteCar]
(
@CarID int
)
AS
BEGIN
DELETE FROM Cars
WHERE CarID = @CarID;
END
