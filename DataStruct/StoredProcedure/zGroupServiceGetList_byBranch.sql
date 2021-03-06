USE [qidjefjs_ausNail]
GO
/****** Object:  StoredProcedure [dbo].[zGroupServiceGetList_byBranch]    Script Date: 12/14/2021 10:48:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROC [dbo].[zGroupServiceGetList_byBranch]
(
@branchId as int
)
AS

-- Modifications:

 Select 
	[ServiceGroupID],
	[BranchId],
	[ServiceGroupName],
	[GroupStt],
	Decriptions,
	is_inactive,
	created_by,
	created_at,
	modified_by,
	modified_at
 FROM  [dbo].[zServicegroup] with(nolock)
	where (BranchId = @branchId)
 ORDER BY [GroupStt]


