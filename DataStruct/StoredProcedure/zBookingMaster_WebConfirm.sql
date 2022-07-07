--USE [qidjefjs_ausNail]
--GO
/****** Object:  StoredProcedure [dbo].[zBookingMasterCancel]    Script Date: 6/20/2021 3:21:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--[zBookingMaster_WebConfirm] @branchId = 2, @BookID = 125, @UserId = 8, 1, 0, ''
Create PROC [dbo].[zBookingMaster_WebConfirm]
(
@branchId as int,
@BookID as int,
 @UserId as int, 
 @ErrCode INT = 0		OUTPUT
, @ErrMsg NVARCHAR(200) = '' OUTPUT
)
AS

-- Author: Auto winfred
-- Created: 16 May 2021
-- Function: update a dbo.zBookingMaster table record

-- Modifications:

begin try

	declare @DateZone Datetime 
	set @DateZone = ISNULL((select top 1 DATEADD(HOUR, CAST(ISNULL(Value,'0') AS INT), GETDATE()) 
	from dbo.[zConfig] where ConfigCode = 'TimeZoneUse' ), GETDATE())
-- update
update [dbo].[zBookingMaster] 
set
		Status = coalesce('Temporary', Status),
		modified_by = coalesce(@UserId, modified_by),
		modified_at = @DateZone
where  branchId  = @branchId
	and BookID = @BookID
	and Status  = 'WaitingForConfirm'

	--update [dbo].[zBookingMaster] 
	--set status = 'ToBill'
	--where bookid in (6,10,11,17,18)

	--select * 
	--from [dbo].[zBookingMaster]

	--select * 
	--from [dbo].[zBillMaster]
	--where branchId  = @branchId
	--and DATEDIFF(hour,bookingdate,@DateCheck) > 1
end try

begin catch

	declare @ErrorSeverity INT;
	declare @ErrorState INT;

	select @ErrCode = ERROR_NUMBER();

	select @ErrMsg = ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE();

	raiserror (@ErrMsg, @ErrorSeverity, @ErrorState);

end catch;


