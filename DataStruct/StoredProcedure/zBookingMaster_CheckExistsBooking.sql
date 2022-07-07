
ALTER PROC [dbo].[zBookingMaster_CheckExistsBooking]
(
@branchId as int,
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


declare @zCountBooking INT = 10
-- update
SELECT @zCountBooking = zCountBooking FROM zBranch WITH(nolock) where   branchId  = @branchId

IF ISNULL(@zCountBooking,10) >=10 SET @zCountBooking = 10
-- update

select 1  from  [dbo].[zBookingMaster] WITH(nolock) 
where   branchId  = @branchId
		and Status in ( 'ToBill','Temporary','WaitingForConfirm')
		and CAST([BookingDate] AS DATE)  = CAST(@BookDate AS DATE)
		and DATEPART(HOUR,[BookingDate]) = DATEPART(HOUR, @BookDate)
having count(*) >= @zCountBooking

end try

begin catch

	declare @ErrorSeverity INT;
	declare @ErrorState INT;

	select @ErrCode = ERROR_NUMBER();

	select @ErrMsg = ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE();

	raiserror (@ErrMsg, @ErrorSeverity, @ErrorState);

end catch;


