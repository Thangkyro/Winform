CREATE PROC [dbo].[zBillUnPaidUpdate]
(
@BillID as int,
@branchId as int,
@modified_by as int
, @ErrCode INT = 0		OUTPUT
, @ErrMsg NVARCHAR(200) = ''		OUTPUT
)
AS

-- Author: Kyro
-- Created: 13 June 2021
-- Function: Update bill master

-- Modifications:

begin try
	 declare @DateZone Datetime 
	set @DateZone = ISNULL((select top 1 DATEADD(HOUR, CAST(ISNULL(Value,'0') AS INT), GETDATE()) from dbo.[zConfig] where ConfigCode = 'TimeZoneUse' ), GETDATE())

-- update
	update [dbo].[zBillMaster] WITH(ROWLOCK) 
	set
		BillDate = coalesce(@DateZone, BillDate),
		Status = 'New',
		Timefinish = @DateZone,
		PaymentCash = 0,
		PaymentCard = 0,
		PaymentVoucher = 0,
		modified_by = coalesce(@modified_by, modified_by),
		modified_at = coalesce(@DateZone, modified_at)
	where BillID  = @BillID  AND  branchId  = @branchId

-- Update available amount for voucher
	Update t0
	Set t0.AvailableAmount = t0.AvailableAmount + t1.PaymentVoucher
	From dbo.[zVoucher] t0
		join dbo.[zBillVoucher] t1 on t0.VoucherID = t1.VoucherID 
	Where t1.BillID = @BillID and t1.branchId = @branchId
-- Delete voucher bil list.
	Delete dbo.[zBillVoucher]
	Where BillID = @BillID and branchId = @branchId

end try

begin catch

	declare @ErrorSeverity INT;
	declare @ErrorState INT;

	select @ErrCode = ERROR_NUMBER();

	select @ErrMsg = ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE();

	raiserror (@ErrMsg, @ErrorSeverity, @ErrorState);

end catch;


