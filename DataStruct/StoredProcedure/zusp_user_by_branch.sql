USE [qidjefjs_ausNail]
GO
/****** Object:  StoredProcedure [dbo].[zusp_user_by_branch]    Script Date: 6/18/2021 10:54:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--[zusp_user_by_branch] 2, 'voduy', '3e6c7d141e32189c917761138b026b74c4ca4238a0b923820dcc509a6f75849be10adc3949ba59abbe56e057f20f883e'
ALTER PROC [dbo].[zusp_user_by_branch]
(
@BranchId as int
,@user_name as nvarchar(100)
,@password as nvarchar(max)
)
AS


-- Author: Auto winfred
-- Created: 16 May 2021
-- Function: select a zUser table record

-- Modifications:

	Select 
	Userid,
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
	modified_at,
	ColorUser
 FROM  [dbo].[zUser] with(nolock)
	where  ( user_name = @user_name)
	 AND ( password = @password)
	 AND ((branchId = @BranchId  OR is_admin = 1))