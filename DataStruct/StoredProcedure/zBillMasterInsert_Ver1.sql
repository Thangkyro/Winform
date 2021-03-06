CREATE PROC [dbo].[zBillMasterInsert_Ver1]
(
	@BillDate as datetime = '20210605',
	@branchId as int = 2,
	@BillCode as varchar(100) = 'BL00000008',
	@CustomerPhone as varchar(100) = '0967151994',
	@BookingId as int = -1,
	@VoucherCode as varchar(100) = '',
	@UserId as int = 1,
	@outBilId INT = -1 OUTPUT,
	@ErrCode INT = 0 OUTPUT,
	@ErrMsg NVARCHAR(200) = '' OUTPUT
)
AS

-- Author: Auto Kyro
-- Created: 31 May 2021
-- Function: Inserts a dbo.zBillMaster, zBillDetail table record by Booking infor.

-- Modifications:

begin try
	 declare @DateZone Datetime 
	set @DateZone = ISNULL((select top 1 DATEADD(HOUR, CAST(ISNULL(Value,'0') AS INT), GETDATE()) from dbo.[zConfig] where ConfigCode = 'TimeZoneUse' ), GETDATE())

	Declare @VoucherId as int
	Declare @CustId as int
	Declare @VoucherAmount as decimal(19,4)
	SELECT @VoucherId = VoucherID,@VoucherAmount = Amount  FROM [dbo].[zVoucher] with(nolock) WHERE VoucherCode = @VoucherCode
	SELECT @CustId = CustId FROM [dbo].[zCustomer] with(nolock) WHERE BranchId = @branchId and PhoneNumber1 = @CustomerPhone

	if @VoucherAmount is null
	begin
		set @VoucherAmount = 0
	end

-- Check exists Bill.
		-- insert master
	IF @BookingId <> - 1
	BEGIN
		INSERT INTO [dbo].[zBillMaster]
           ([branchId]
           ,[BillDate]
		   ,[BillCode]
           ,[CustId]
           ,[CustomerPhone]
           ,[TotalEstimatePrice]
           ,[TotalEstimateTime]
           ,[StaffRequire]
           ,[Status]
		   ,[Timefinish]
		   ,[TotalDiscount]
		   ,[PaymentCash]
		   ,[PaymentCard]
		   ,[PaymentVoucher]
		   ,[BookID]
		   ,[VoucherID]
           ,[Decriptions]
           ,[created_by]
           ,[created_at]
           ,[modified_by]
           ,[modified_at])
		 SELECT
           @branchId
           ,@BillDate
           ,@BillCode
           ,[CustId]
           ,[CustomerPhone]
           ,[TotalEstimatePrice]
           ,[TotalEstimateTime]
           ,[StaffRequire]
           ,'New'
		   ,@DateZone
		   ,0
		   ,0
		   ,0
		   ,0
           ,[BookID]
		   ,@VoucherId
		   ,null
           ,@UserId
           ,@DateZone
           ,@UserId
           ,@DateZone
		  FROM [dbo].[zBookingMaster] with(nolock)
		  WHERE [BookID] = @bookingId and [branchId] =  @branchId 
	END
	ELSE
	BEGIN
		INSERT INTO [dbo].[zBillMaster]
           ([branchId]
           ,[BillDate]
		   ,[BillCode]
           ,[CustId]
           ,[CustomerPhone]
           ,[TotalEstimatePrice]
           ,[TotalEstimateTime]
           ,[StaffRequire]
           ,[Status]
		   ,[Timefinish]
		   ,[TotalDiscount]
		   ,[PaymentCash]
		   ,[PaymentCard]
		   ,[PaymentVoucher]
		   ,[BookID]
		   ,[VoucherID]
           ,[Decriptions]
           ,[created_by]
           ,[created_at]
           ,[modified_by]
           ,[modified_at])
		 VALUES
		 (
           @branchId
           ,@BillDate
           ,@BillCode
           ,@CustId
           ,@CustomerPhone
           ,0
           ,0
           ,0
           ,'New'
		   ,@DateZone
		   ,0
		   ,0
		   ,0
		   ,0
           ,@BookingId
		   ,@VoucherId
		   ,null
           ,@UserId
           ,@DateZone
           ,@UserId
           ,@DateZone
		  )
	END

	-- Update booking to BillID
		UPDATE [dbo].[zBillMaster]
		SET BookID = null
		WHERE [branchId] =  @branchId 
			and BookID = -1

		-- Update voucher
		update [dbo].[zVoucher]
		set is_inactive = 1
		where VoucherID = @VoucherId 

		---- Post

  --      -- Update revenue


end try

begin catch

	declare @ErrorSeverity INT;
	declare @ErrorState INT;

	select @ErrCode = ERROR_NUMBER();

	select @ErrMsg = ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE();

	raiserror (@ErrMsg, @ErrorSeverity, @ErrorState);

end catch;


