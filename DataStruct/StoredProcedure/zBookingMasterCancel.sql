CREATE PROC [dbo].[zBookingMasterCancel]
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
	declare @DateZone Datetime 
	set @DateZone = ISNULL((select top 1 DATEADD(HOUR, CAST(ISNULL(Value,'0') AS INT), GETDATE()) from dbo.[zConfig] where ConfigCode = 'TimeZoneUse' ), GETDATE())

-- update
update [dbo].[zBookingMaster] WITH(ROWLOCK) set
		Status = coalesce(@Status, Status),
		modified_by = coalesce(@modified_by, modified_by),
		modified_at = @DateZone
where BookID  = @BookID  AND  branchId  = @branchId

end try

begin catch

	declare @ErrorSeverity INT;
	declare @ErrorState INT;

	select @ErrCode = ERROR_NUMBER();

	select @ErrMsg = ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE();

	raiserror (@ErrMsg, @ErrorSeverity, @ErrorState);

end catch;


