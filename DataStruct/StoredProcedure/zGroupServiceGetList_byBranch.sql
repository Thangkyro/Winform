USE [qidjefjs_ausNail]
GO
/****** Object:  StoredProcedure [dbo].[zServiceGetList_byBranch]    Script Date: 12/6/2021 10:12:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[zGroupServiceGetList_byBranch]
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


