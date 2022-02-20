
CREATE PROC [dbo].[zBookingMaster_CheckExistsBooking]
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

-- update

select 1  from  [dbo].[zBookingMaster] WITH(nolock) 
where   branchId  = @branchId
		and Status in ( 'ToBill','Temporary')
		and CAST([BookingDate] AS DATE)  = CAST(@BookDate AS DATE)
		and DATEPART(HOUR,[BookingDate]) = DATEPART(HOUR, @BookDate)
having count(*) >= 10

end try

begin catch

	declare @ErrorSeverity INT;
	declare @ErrorState INT;

	select @ErrCode = ERROR_NUMBER();

	select @ErrMsg = ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE();

	raiserror (@ErrMsg, @ErrorSeverity, @ErrorState);

end catch;


