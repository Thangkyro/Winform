USE [qidjefjs_ausNail]
GO
/****** Object:  StoredProcedure [dbo].[zBranchClearImage]    Script Date: 09/24/2021 2:03:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROC [dbo].[zBranchClearImage]
(
@BranchId as int,
@Image as varbinary(max) = Null,
@created_by as int,
@created_at as datetime,
@modified_by as int,
@modified_at as datetime
, @ErrCode INT = 0		OUTPUT
, @ErrMsg NVARCHAR(200) = ''		OUTPUT
)
AS

-- Author: Auto winfred
-- Created: 16 May 2021
-- Function: Inserts a dbo.zStaffImages table record

-- Modifications:

begin try

update [dbo].[zBranch] WITH(ROWLOCK) set
		Imagebranch = coalesce(@Image, null),
		modified_by = coalesce(@modified_by, modified_by),
		modified_at = coalesce(@modified_at, modified_at)
where branchId  = @BranchId


-- Return the new ID
end try

begin catch

	declare @ErrorSeverity INT;
	declare @ErrorState INT;

	select @ErrCode = ERROR_NUMBER();

	select @ErrMsg = ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE();

	raiserror (@ErrMsg, @ErrorSeverity, @ErrorState);

end catch;


