USE [CarDealer]
GO
/****** Object:  StoredProcedure [dbo].[EmployeeCheck]    Script Date: 22-09-2023 08:08:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[EmployeeCheck]
(
@PersonID Int
)
AS
BEGIN
SELECT Type From dbo.Users
WHERE PersonID = @PersonID;
END
