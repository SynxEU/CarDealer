USE [CarDealer]
GO
/****** Object:  StoredProcedure [dbo].[StoreCars]    Script Date: 22-09-2023 08:09:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[StoreCars]
(
@Brand Int,
@Model nvarchar (50),
@Price Int,
@InStock nchar (10)
)
AS
BEGIN
INSERT INTO dbo.Cars(Brand, Model, Price, [In Stock])
VALUES (@Brand,@Model,@Price,@InStock)
END
