USE [qidjefjs_ausNail]
GO
/****** Object:  StoredProcedure [dbo].[zServiceGetList]    Script Date: 23/05/2021 5:10:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROC [dbo].[zServiceGetList_byBranch]
(
@branchId as int
)
AS

-- Author: Kyro
-- Created: 16 May 2021
-- Function: select a zService table record

-- Modifications:

 Select 
	ServiceID,
	branchId,
	Title,
	CONCAT(Title + ' - ', CAST(Price as varchar)) as Display,
	Price,
	EstimateTime,
	Decriptions,
	is_inactive,
	created_by,
	created_at,
	modified_by,
	modified_at
 FROM  [dbo].[zService] with(nolock)
	where (branchId = @branchId)


