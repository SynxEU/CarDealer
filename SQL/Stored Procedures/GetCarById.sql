USE [CarDealer]
GO
/****** Object:  StoredProcedure [dbo].[GetCarById]    Script Date: 22-09-2023 08:08:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[GetCarById]
(
@CarId Int
)
AS
BEGIN
SELECT * From dbo.Cars
WHERE CarID = @CarId;
END
