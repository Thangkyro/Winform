


CREATE PROC [dbo].[zServiceClearImage]
(
@ServiceId as int,
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

update [dbo].[zService] WITH(ROWLOCK) set
		zImage = coalesce(@Image, null),
		modified_by = coalesce(@modified_by, modified_by),
		modified_at = coalesce(@modified_at, modified_at)
where ServiceID  = @ServiceId


-- Return the new ID
end try

begin catch

	declare @ErrorSeverity INT;
	declare @ErrorState INT;

	select @ErrCode = ERROR_NUMBER();

	select @ErrMsg = ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE();

	raiserror (@ErrMsg, @ErrorSeverity, @ErrorState);

end catch;


