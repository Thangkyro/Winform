USE [qidjefjs_ausNail]
GO
/****** Object:  StoredProcedure [dbo].[zBillDetailInsert_Ver1]    Script Date: 6/26/2021 4:34:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[zBillDetailUpdate_Ver1]
(
	@billId as int ,
	@billDetailId as int ,
	@branchId as int ,
	@StaffId as int ,
	@Note as nvarchar(200),
	@ErrCode INT = 0 OUTPUT,
	@ErrMsg NVARCHAR(200) = '' OUTPUT
)
AS

-- Author: Auto Kyro
-- Created: 31 May 2021
-- Function: Inserts a dbo.zBillMaster, zBillDetail table record by Booking infor.

-- Modifications:

begin try
		begin
			UPDATE [dbo].[zBillDetail]
			SET [StaffId] = @StaffId
				, [Note] = @Note
			WHERE 	[BillID] = @billId
				AND [BillDtID] = @billDetailId
				AND [branchId] = @branchId
		end	   
		
		-- update master value [If discount by service detail]
		Update t0
		Set t0.[TotalDiscount] = t1.[TotalDiscount]
		From [dbo].[zBillMaster] t0
			join ( Select SUM([Discount]) as [TotalDiscount], branchId, BillID 
			   from  [dbo].[zBillDetail] with (nolock)
			   where BillID = @BillId 
			   group by branchId,BillID ) t1 on t0.branchId = t1.branchId and t0.BillID = t1.BillID
		where t0.BookID = @BillId

		---- Update booking status
		--update [dbo].[zBookingMaster]
		--set [Status] = 'ToBill'
		--where [BookID] = @bookingId and [branchId] =  @branchId 

end try

begin catch

	declare @ErrorSeverity INT;
	declare @ErrorState INT;

	select @ErrCode = ERROR_NUMBER();

	select @ErrMsg = ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE();

	raiserror (@ErrMsg, @ErrorSeverity, @ErrorState);

end catch;


