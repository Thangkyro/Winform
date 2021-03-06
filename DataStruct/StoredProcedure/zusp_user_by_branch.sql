USE [qidjefjs_ausNail]
GO
/****** Object:  StoredProcedure [dbo].[zusp_user_by_branch]    Script Date: 09/24/2021 11:28:34 AM ******/
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
	a.branchId,
	user_name,
	full_name,
	is_admin,
	StaffId,
	password,
	permission,
	a.Decriptions,
	a.is_inactive,
	a.created_by,
	a.created_at,
	a.modified_by,
	a.modified_at,
	ColorUser,
	b.Located,
	b.IsAutoPrint,
	b.MaxPercen,
	b.MinApprovePercen,
	b.PercenPay,
	b.website,
	b.Titlebranch,
	b.Imagebranch
 FROM  [dbo].[zUser] a with(nolock)
 INNER JOIN [dbo].[zBranch] b  with(nolock) on a.branchId = b.branchId
	where  ( user_name = @user_name)
	 AND ( password = @password)
	 AND ((a.branchId = @BranchId  OR is_admin = 1))