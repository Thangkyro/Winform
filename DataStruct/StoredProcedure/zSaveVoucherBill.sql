CREATE PROC [dbo].[zSaveVoucherBill]
(
@BillId int,
@BranchID int,
@Num int,
@VoucherCode as varchar(30),
@AvailableAmount as varchar(50),
@modified_by as int
, @ErrCode INT = 0		OUTPUT
, @ErrMsg NVARCHAR(200) = ''		OUTPUT
)
AS

-- Author: Kyro
-- Created: 13 June 2021
-- Function: Save voucher for bill.

-- Modifications:

begin try
	declare @DateZone Datetime 
	set @DateZone = ISNULL((select top 1 DATEADD(HOUR, CAST(ISNULL(Value,'0') AS INT), GETDATE()) from dbo.[zConfig] where ConfigCode = 'TimeZoneUse' ), GETDATE())

	declare @VoucherID int
	Select @VoucherID = VoucherId From [dbo].[zVoucher] with(nolock) where VoucherCode = @VoucherCode

	if  exists (select 1 from dbo.[zBillVoucher] with(nolock) where BillID = @BillId AND branchId = @BranchID AND VoucherId = @VoucherID)
	begin
		Update dbo.[zBillVoucher]
		set PaymentVoucher = @AvailableAmount
			, created_by = @modified_by
		Where BillID = @BillId
			AND branchId = @BranchID
			AND VoucherId = @VoucherID
	end
	else
	begin
		Insert into dbo.[zBillVoucher]
		(
			BillID
			, branchId
			, PaymentVoucher
			, VoucherID
			, created_by
			, created_at
			, OrderNumber
		)
		values
		(
			@BillId
			, @BranchID
			, @AvailableAmount
			, @VoucherID
			, @modified_by
			, @DateZone
			, @Num
		)
	end

end try

begin catch

	declare @ErrorSeverity INT;
	declare @ErrorState INT;

	select @ErrCode = ERROR_NUMBER();

	select @ErrMsg = ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE();

	raiserror (@ErrMsg, @ErrorSeverity, @ErrorState);

end catch;


