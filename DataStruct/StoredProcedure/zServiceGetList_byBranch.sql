/****** Object:  StoredProcedure [dbo].[zServiceGetList_byBranch]    Script Date: 12/6/2021 10:10:59 PM ******/

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
	s.ServiceID,
	s.branchId,
	s.Title,
	CONCAT(s.Title + ' - ', CAST(s.Price as varchar)) as Display,
	s.Price,
	s.EstimateTime,
	s.Decriptions,
	s.is_inactive,
	s.created_by,
	s.created_at,
	s.modified_by,
	s.modified_at,
	s.is_discount,
	s.ShortDecriptions,
	s.GroupStt,
	s.zImage,
	isnull(sg.ServiceGroupName,'') as ServiceGroupName
 FROM  [dbo].[zService] s with(nolock)
	left join  zServicegroup sg with(nolock) on s.GroupStt = sg.ServiceGroupID AND s.BranchId = sg.BranchId
 	where (s.branchId = @branchId)


