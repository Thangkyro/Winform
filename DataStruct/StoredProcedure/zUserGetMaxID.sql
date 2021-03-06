USE [qidjefjs_ausNail]
GO
/****** Object:  StoredProcedure [dbo].[zUserGetList]    Script Date: 5/31/2021 9:02:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[zUserGetMaxID]
(
@Userid as int = 0
,@StaffId as INt = 0
,@user_name as nvarchar(100) = ''
)
AS


-- Author: Auto winfred
-- Created: 16 May 2021
-- Function: select a zUser table record

-- Modifications:

	Select 
	ISNULL(Userid,0) MaxID
 FROM  [dbo].[zUser] with(nolock)
	where (Userid = @Userid OR @Userid = 0 ) AND ( StaffId = @StaffId OR @StaffId = 0)
	 AND ( user_name = @user_name OR @user_name = '')


