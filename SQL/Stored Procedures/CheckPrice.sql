USE [CarDealer]
GO
/****** Object:  StoredProcedure [dbo].[CheckPrice]    Script Date: 22-09-2023 08:07:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[CheckPrice]
(
@CarId int
)
AS
BEGIN
SELECT Price
FROM Cars
WHERE CarID = @CarId
END
