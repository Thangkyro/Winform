USE [qidjefjs_ausNail]
GO
/****** Object:  StoredProcedure [dbo].[zBillMasterDelete]    Script Date: 07/17/2021 10:51:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROC [dbo].[zBillMasterDelete]
(
 @BillID as int
, @branchId as int
, @ErrCode INT = 0 OUTPUT
, @ErrMsg NVARCHAR(200) = '' OUTPUT
)
AS

-- Author: Auto winfred
-- Created: 16 May 2021
-- Function: Delete a zBillMaster table record

-- Modifications:

begin try

	-- Update status for booking
	declare @BokkingId as int
	declare @Billdate as datetime
	select @BokkingId = BookID, @Billdate = BillDate from ZbillMaster with(nolock) where BillID = @BillID and branchId = @branchId and BookID > 0
	if @BokkingId is not null
	begin
		if @Billdate < getdate()
		begin
			update zBookingMaster set [Status] = 'Cancel' where BookID = @BokkingId and branchId = @branchId
		end
		else
		begin
			update zBookingMaster set [Status] = 'Temporary' where BookID = @BokkingId and branchId = @branchId
		end
	end

	-- delete
	delete [dbo].[zBillMaster] with(rowlock)
	where branchId = @branchId and BillID = @BillID 

	delete [dbo].[zBillDetail] with(rowlock)
	where branchId = @branchId and BillID = @BillID 

	delete [dbo].[zRevenue] with(rowlock)
	where branchId = @branchId and BillID = @BillID 

	delete [dbo].[zRevenueDetail] with(rowlock)
	where branchId = @branchId and BillID = @BillID 

end try

begin catch

	declare @ErrorSeverity INT;
	declare @ErrorState INT;

	select @ErrCode = ERROR_NUMBER();

	select @ErrMsg = ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE();

	raiserror (@ErrMsg, @ErrorSeverity, @ErrorState);

end catch;


