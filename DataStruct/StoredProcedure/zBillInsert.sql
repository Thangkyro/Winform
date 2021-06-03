USE [qidjefjs_ausNail]
GO
/****** Object:  StoredProcedure [dbo].[zBookingInsert]    Script Date: 31/05/2021 5:20:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[zBillInsert]
(
@branchId as int,
@bookingId as int,
@VoucherCode as nvarchar(100),
@discountAmount as Decimal(19,4),
@cardAmount as Decimal(19,4),
@cashAmount as Decimal(19,4),
@UserId as int,
@ErrCode INT = 0 OUTPUT,
@ErrMsg NVARCHAR(200) = '' OUTPUT
)
AS

-- Author: Auto Kyro
-- Created: 31 May 2021
-- Function: Inserts a dbo.zBillMaster, zBillDetail table record

-- Modifications:

begin try

	Declare @VoucherId as int
	Declare @VoucherAmount as decimal(19,4)
	SELECT @VoucherId = VoucherID,@VoucherAmount = Amount  FROM [dbo].[zVoucher] with(nolock) WHERE VoucherCode = @VoucherCode

	if @VoucherAmount is null
	begin
		set @VoucherAmount = 0
	end

-- Check exists Bill.
	if not exists (
		Select 1 
		from [dbo].[zBillMaster] t0  with(nolock)
			join [dbo].[zBookingMaster] t1  with(nolock) on t0.branchId = t1.branchId and t0.BookID = t1.BookID
		where t0.[branchId] =  @branchId
			and t0.[BookID] = @bookingId and t0.[Status] <> 'Complete' )
	begin
		-- insert master
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
           ,Getdate()
           ,'' as [BillCode]
           ,[CustId]
           ,[CustomerPhone]
           ,[TotalEstimatePrice]
           ,[TotalEstimateTime]
           ,[StaffRequire]
           ,'New'
		   ,Getdate()
		   ,@discountAmount
		   ,@cashAmount
		   ,@cashAmount
		   ,@VoucherAmount
           ,[BookID]
		   ,@VoucherId
		   ,null
           ,@UserId
           ,Getdate()
           ,@UserId
           ,Getdate()
		  FROM [dbo].[zBookingMaster] with(nolock)
		  WHERE [BookID] = @bookingId and [branchId] =  @branchId 
	end

	-- Get the BillID
		Declare @BillId as int
		SELECT @BillId = BookID 
		FROM [dbo].[zBillMaster] with(nolock)
		WHERE [branchId] =  @branchId 
			and CAST([BillDate] as date) = CAST(GETDATE() as date)
			and [BookID] = @bookingId and [Status] = 'New'

		-- insert detail
			INSERT INTO [dbo].[zBillDetail]
			   ([BillID]
			   ,[OrderNumber]
			   ,[branchId]
			   ,[ServiceID]
			   ,[Price]
			   ,[Discount]
			   ,[Payment]
			   ,[Note]
			   ,[BookID]
			   ,[BookDTID]
			   ,[StaffId]
			   ,[created_by]
			   ,[created_at])
			 SELECT
			   @BillId
			   ,t0.[OrderNumber]
			   ,@branchId
			   ,t0.[ServiceID]
			   ,t1.[Price]
			   ,0 as [Discount]
			   ,t0.Quantity * t1.Price as [Payment]
			   ,null
			   ,t0.[BookID]
			   ,t0.[BookDTID]
			   ,t0.[StaffId]
			   ,@UserId
			   ,GETDATE()
			  FROM [dbo].[zBookingDetail] t0 with (nolock)
				Join [dbo].[zService] t1 with (nolock) on t0.[branchId] = t1.[branchId] and t0.[ServiceID] = t1.[ServiceID]
			  WHERE t0.BookID = @bookingId
		
		
		-- update master value [If discount by service detail]
		Update t0
		Set t0.[TotalDiscount] = t1.[TotalDiscount]
		From [dbo].[zBillMaster] t0
			join ( Select SUM([Discount]) as [TotalDiscount], branchId, BillID 
			   from  [dbo].[zBillDetail] with (nolock)
			   where BillID = @BillId 
			   group by branchId,BillID ) t1 on t0.branchId = t1.branchId and t0.BillID = t1.BillID
		where t0.BookID = @BillId


end try

begin catch

	declare @ErrorSeverity INT;
	declare @ErrorState INT;

	select @ErrCode = ERROR_NUMBER();

	select @ErrMsg = ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE();

	raiserror (@ErrMsg, @ErrorSeverity, @ErrorState);

end catch;


