USE [CarDealer]
GO
/****** Object:  StoredProcedure [dbo].[BuyCars]    Script Date: 22-09-2023 08:07:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[BuyCars]
(
@CarID Int,
@InStock nchar(10),
@BoughtById int
)
AS
BEGIN
DECLARE @Brand Int
DECLARE @Model Nvarchar(50)
DECLARE @Price Int
SELECT @Brand = Brand, @Model = Model, @Price = Price FROM dbo.Cars
WHERE CarID = @CarID

INSERT INTO BoughtCars (CarID,Brand,Model,Price,[In Stock],[Bought By ID])
Values (@CarID,@Brand,@Model,@Price,@InStock,@BoughtById)

DELETE FROM dbo.Cars WHERE CarId = @CarID
END
