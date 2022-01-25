
/****** Object:  StoredProcedure [dbo].[zServiceGetList_byBranch]    Script Date: 12/6/2021 10:10:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROC [dbo].[zServiceGetList_byBranch_Booking]
(
@branchId as int
)
AS

-- Author: Kyro
-- Created: 16 May 2021
-- Function: select a zService table record

-- Modifications:

 Select 
	t1.ServiceID,
	t1.branchId,
	t2.ServiceGroupName,
	t1.Title,
	t1.ShortDecriptions,
	CONCAT(t1.Title + ' - ', CAST(t1.Price as varchar)) as Display,
	t1.Price,
	t1.EstimateTime,
	t1.Decriptions,
	t1.is_inactive,
	t1.created_by,
	t1.created_at,
	t1.modified_by,
	t1.modified_at,
	t1.GroupStt
 FROM  [dbo].[zService] t1 with(nolock) 
		join [dbo].[zServicegroup] t2 with(nolock)  on t1.GroupStt = t2.ServiceGroupID
 where (t1.branchId = @branchId)
 order by t2.ServiceGroupID, t2.GroupStt


