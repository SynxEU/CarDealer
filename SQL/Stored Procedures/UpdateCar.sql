USE [CarDealer]
GO
/****** Object:  StoredProcedure [dbo].[UpdateCar]    Script Date: 22-09-2023 08:10:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[UpdateCar]
(
@CarID int,
@Price int
)
AS
BEGIN
UPDATE dbo.Cars
SET Price = @Price
WHERE CarID = @CarID;
END
