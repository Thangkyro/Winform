USE [qidjefjs_ausNail]
GO
/****** Object:  StoredProcedure [dbo].[zBookingMasterCancel]    Script Date: 6/18/2021 3:22:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROC [dbo].[zBookingMaster_CheckByDate]
(
@branchId as int,
@Status as varchar(100),
@CustomerPhone as varchar(100),
@BookDate as datetime
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
select 1 from  [dbo].[zBookingMaster] WITH(nolock) 
where CustomerPhone  = @CustomerPhone  
		and  branchId  = @branchId
		and Status = @Status
		and [BookingDate]  = @BookDate 

end try

begin catch

	declare @ErrorSeverity INT;
	declare @ErrorState INT;

	select @ErrCode = ERROR_NUMBER();

	select @ErrMsg = ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE();

	raiserror (@ErrMsg, @ErrorSeverity, @ErrorState);

end catch;


