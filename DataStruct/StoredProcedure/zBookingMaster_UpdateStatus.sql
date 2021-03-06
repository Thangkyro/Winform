USE [qidjefjs_ausNail]
GO
/****** Object:  StoredProcedure [dbo].[zBookingMasterCancel]    Script Date: 6/20/2021 3:21:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--[zBookingMaster_UpdateStatus] 2, '2021-06-20 15:35:12', 'Cancel', 1, 0, ''
ALTER PROC [dbo].[zBookingMaster_UpdateStatus]
(
@branchId as int,
@DateCheck as datetime,
@Status as varchar(100),
@modified_by as int
, @ErrCode INT = 0		OUTPUT
, @ErrMsg NVARCHAR(200) = '' OUTPUT
)
AS

-- Author: Auto winfred
-- Created: 16 May 2021
-- Function: Create or update a dbo.zBookingMaster table record

-- Modifications:

begin try

-- update
update [dbo].[zBookingMaster] 
set
		Status = coalesce(@Status, Status),
		modified_by = coalesce(@modified_by, modified_by),
		modified_at = getdate()
where  branchId  = @branchId
	and DATEDIFF(hour,bookingdate,@DateCheck) > 1 
	and Status  = 'Temporary'

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


