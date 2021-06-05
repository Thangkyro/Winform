USE [qidjefjs_ausNail]
GO
/****** Object:  StoredProcedure [dbo].[zBillInsert]    Script Date: 6/5/2021 5:33:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROC [dbo].[zBillMasterInsert_Ver1]
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
		   ,Getdate()
		   ,0
		   ,0
		   ,0
		   ,0
           ,[BookID]
		   ,@VoucherId
		   ,null
           ,@UserId
           ,Getdate()
           ,@UserId
           ,Getdate()
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
		   ,Getdate()
		   ,0
		   ,0
		   ,0
		   ,0
           ,@BookingId
		   ,@VoucherId
		   ,null
           ,@UserId
           ,Getdate()
           ,@UserId
           ,Getdate()
		  )
	END

	-- Update booking to BillID
		UPDATE [dbo].[zBillMaster]
		SET BookID = null
		WHERE [branchId] =  @branchId 
			and BookID = -1

		---- insert detail
		--	INSERT INTO [dbo].[zBillDetail]
		--	   ([BillID]
		--	   ,[OrderNumber]
		--	   ,[branchId]
		--	   ,[ServiceID]
		--	   ,[Price]
		--	   ,[Discount]
		--	   ,[Payment]
		--	   ,[Note]
		--	   ,[BookID]
		--	   ,[BookDTID]
		--	   ,[StaffId]
		--	   ,[created_by]
		--	   ,[created_at])
		--	 SELECT
		--	   @BillId
		--	   ,t0.[OrderNumber]
		--	   ,@branchId
		--	   ,t0.[ServiceID]
		--	   ,t1.[Price]
		--	   ,0 as [Discount]
		--	   ,t0.Quantity * t1.Price as [Payment]
		--	   ,null
		--	   ,t0.[BookID]
		--	   ,t0.[BookDTID]
		--	   ,t0.[StaffId]
		--	   ,@UserId
		--	   ,GETDATE()
		--	  FROM [dbo].[zBookingDetail] t0 with (nolock)
		--		Join [dbo].[zService] t1 with (nolock) on t0.[branchId] = t1.[branchId] and t0.[ServiceID] = t1.[ServiceID]
		--	  WHERE t0.BookID = @bookingId
		
		
		---- update master value [If discount by service detail]
		--Update t0
		--Set t0.[TotalDiscount] = t1.[TotalDiscount]
		--From [dbo].[zBillMaster] t0
		--	join ( Select SUM([Discount]) as [TotalDiscount], branchId, BillID 
		--	   from  [dbo].[zBillDetail] with (nolock)
		--	   where BillID = @BillId 
		--	   group by branchId,BillID ) t1 on t0.branchId = t1.branchId and t0.BillID = t1.BillID
		--where t0.BookID = @BillId

		---- Update booking status
		--update [dbo].[zBookingMaster]
		--set [Status] = 'ToBill'
		--where [BookID] = @bookingId and [branchId] =  @branchId 

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


