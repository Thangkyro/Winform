USE [qidjefjs_ausNail]
GO
/****** Object:  StoredProcedure [dbo].[zUserGetList]    Script Date: 5/23/2021 7:06:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[zusp_user_by_branch]
(
@BranchId as int
,@user_name as nvarchar(100)
,@password as nvarchar(100)
)
AS


-- Author: Auto winfred
-- Created: 16 May 2021
-- Function: select a zUser table record

-- Modifications:

	Select 
	branchId,
	user_name,
	full_name,
	is_admin,
	StaffId,
	password,
	permission,
	Decriptions,
	is_inactive,
	created_by,
	created_at,
	modified_by,
	modified_at
 FROM  [dbo].[zUser] with(nolock)
	where (branchId = @BranchId ) AND ( user_name = @user_name)
	 AND ( password = @password)


