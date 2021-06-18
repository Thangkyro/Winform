USE [qidjefjs_ausNail]
GO
/****** Object:  StoredProcedure [dbo].[zBookingMasterUpdate]    Script Date: 6/16/2021 1:34:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROC [dbo].[zBookingMasterCancel]
(
@BookID as int,
@branchId as int,
@Status as varchar(100),
@modified_by as int
, @ErrCode INT = 0		OUTPUT
, @ErrMsg NVARCHAR(200) = ''		OUTPUT
)
AS

-- Author: Auto winfred
-- Created: 16 May 2021
-- Function: Create or update a dbo.zBookingMaster table record

-- Modifications:

begin try

-- update
update [dbo].[zBookingMaster] WITH(ROWLOCK) set
		Status = coalesce(@Status, Status),
		modified_by = coalesce(@modified_by, modified_by),
		modified_at = getdate()
where BookID  = @BookID  AND  branchId  = @branchId

end try

begin catch

	declare @ErrorSeverity INT;
	declare @ErrorState INT;

	select @ErrCode = ERROR_NUMBER();

	select @ErrMsg = ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE();

	raiserror (@ErrMsg, @ErrorSeverity, @ErrorState);

end catch;


