USE [qidjefjs_ausNail]
GO
/****** Object:  StoredProcedure [dbo].[zBookingInsert]    Script Date: 6/12/2021 4:10:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[zBillInsert_Ver1]
(
@BillDate as datetime,
@branchId as int,
@billCode as nvarchar(100),
@CustomerPhone as varchar(100),
@Num as int,
@ServiceID as int,
@Quantity as Decimal(19,4),
@Price as Decimal(19,4),
@StaffId as int,
@Note as varchar(1000),
@UserId as int,
@ErrCode INT = 0 OUTPUT,
@ErrMsg NVARCHAR(200) = '' OUTPUT
)
AS

-- Author: Auto Kyro
-- Created: 27 May 2021
-- Function: Inserts a dbo.zBookingMaster, zBookingDetail table record

-- Modifications:

begin try

	Declare @CustId as int
	SELECT @CustId = CustId FROM [dbo].[zCustomer] with(nolock) WHERE (ISNULL(PhoneNumber1, '') = @CustomerPhone Or ISNULL(PhoneNumber2, '') = @CustomerPhone ) ORDER BY CustId DESC

	if @CustId is null
	begin
		select @ErrCode = -260597;
		select @ErrMsg = N'Customer not exists.';
	end
-- Check exists bill.
	if not exists (
		Select 1 
		from [dbo].[zBillMaster]  with(nolock)
		where [branchId] =  @branchId and CAST([BillDate] as date) = CAST(@BillDate as date)
			and [CustId] = @CustId and [Status] = 'New' )
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
		   ,[BookID]
		   ,[VoucherID]
           ,[Decriptions]
           ,[created_by]
           ,[created_at]
           ,[modified_by]
           ,[modified_at])
		 VALUES
           (@branchId
           ,@BillDate
		   ,@BillCode
           ,@CustId
           ,@CustomerPhone
           ,0 -- TotalEstimatePrice
           ,0 -- TotalEstimateTime
           ,0 -- StaffRequire
           ,'New'
		   ,null
		   ,null
           ,null
           ,@UserId
           ,Getdate()
           ,@UserId
           ,Getdate());
	end

	-- Get the ID Booking
		Declare @IdBill as int
		SELECT @IdBill = MAX(BillID)
		FROM [dbo].[zBillMaster] with(nolock)
		WHERE [branchId] =  @branchId 
			and CAST([BillDate] as date) = CAST(@BillDate as date)
			and [CustId] = @CustId and [Status] = 'New'

	-- Get service infor
		Declare @EstimateTime as decimal(19,4)
		SELECT @EstimateTime = EstimateTime FROM dbo.[zService] with(nolock) Where ServiceID = @ServiceID
		Delete [dbo].[zBillDetail] Where branchId = @branchId AND BillID = @IdBill And [OrderNumber] + 1 > @Num
		-- insert detail
			INSERT INTO [dbo].[zBillDetail]
			   ([BillID]
			   ,[OrderNumber]
			   ,[branchId]
			   ,[ServiceID]
			   ,[Quantity]
			   ,[Price]
			   ,[Discount]
			   ,[Payment]
			   ,[BookID]
			   ,[BookDTID]
			   ,[Note]
			   ,[StaffId]
			   ,[created_by]
			   ,[created_at])
			 VALUES
			   (@IdBill
			   ,@Num
			   ,@branchId
			   ,@ServiceID
			   ,@Quantity
			   ,@Price
			   ,0
			   ,@Quantity*@Price
			   ,null
			   ,null
			   ,@Note
			   ,@StaffId
			   ,@UserId
			   ,GETDATE())

		-- update master value
		Update t0
		Set t0.TotalEstimatePrice = t1.TotalEstimatePrice,
			t0.TotalDiscount = t1.TotalDiscount
		From [dbo].[zBillMaster] t0
			join ( Select SUM(Price) as TotalEstimatePrice,SUM(Discount) as TotalDiscount, branchId, BillID 
			   from  [dbo].[zBillDetail] with (nolock)
			   where BillID = @IdBill
			   group by branchId,BillID ) t1 on t0.branchId = t1.branchId and t0.BillID = t1.BillID
		where t0.BillID = @IdBill


end try

begin catch

	declare @ErrorSeverity INT;
	declare @ErrorState INT;

	select @ErrCode = ERROR_NUMBER();

	select @ErrMsg = ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE();

	raiserror (@ErrMsg, @ErrorSeverity, @ErrorState);

end catch;


