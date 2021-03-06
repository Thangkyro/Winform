USE [qidjefjs_ausNail]
GO
/****** Object:  StoredProcedure [dbo].[zGetNewCode]    Script Date: 23/05/2021 10:40:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROC [dbo].[zGetNewCode]
(
	@tableName as varchar(50),
	@ruleText as varchar(50),
	@columnIdName as varchar(50),
	@lenghtText as int
)
AS

-- Author: Kyro
-- Created: 22 May 2021
-- Function: Get new code by rule.

-- Modifications:

	declare @sql nvarchar(4000)

	set @sql = N'
		SELECT CONCAT(@ruleText, REPLACE(STR(ISNULL(MAX(' + @columnIdName + '),0) + 1, @lenghtText), SPACE(1), ''0''))  FROM dbo.' + @tableName 

	EXECUTE sp_executesql @sql, N' @lenghtText int, @ruleText varchar(50)',  @lenghtText = @lenghtText, @ruleText = @ruleText




	



