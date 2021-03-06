CREATE PROC [dbo].[zBillDetailInsert_Ver1]
(
	@billId as int ,
	@branchId as int ,
	@Num as int ,
	@ServiceID as int ,
	@Quantity as Decimal(19,4),
	@Price as Decimal(19,4) ,
	@Discount as Decimal(19,4),
	@StaffId as int ,
	@UserId as int ,
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

	declare @DateZone Datetime 
	set @DateZone = ISNULL((select top 1 DATEADD(HOUR, CAST(ISNULL(Value,'0') AS INT), GETDATE()) from dbo.[zConfig] where ConfigCode = 'TimeZoneUse' ), GETDATE())
	

		Declare @Bookingid as int
		SET  @Bookingid = (SELECT Distinct t0.BookId FROM dbo.[zBookingDetail] t0 with(nolock)
				join dbo.[zBookingMaster] t1 with(nolock) on t0.BookId = t1.BookId and t0.BranchId = t1.BranchId
				join dbo.[zBillMaster] t2 with(nolock) on t1.BookId = t2.BookId and t1.BranchId = t2.BranchId
			WHERE t2.BillId = @BillId and t0.BranchId = @BranchId and t0.ServiceId = @ServiceId)
		
		IF ISNULL(@Bookingid, -1) > -1
		Begin
		-- insert detail
			INSERT INTO [dbo].[zBillDetail]
			   ([BillID]
			   ,[OrderNumber]
			   ,[branchId]
			   ,[ServiceID]
			   ,[Price]
			   ,[Quantity]
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
			   ,@Num
			   ,@branchId
			   ,@ServiceID
			   ,@Price
			   ,@Quantity
			   ,@Discount
			   ,@Quantity * @Price - @Discount as [Payment]
			   ,ISNULL(t0.Note,@Note)
			   ,t0.[BookID]
			   ,t0.[BookDTID]
			   ,@StaffId
			   ,@UserId
			   ,@DateZone
			  FROM [dbo].[zBookingDetail] t0 with (nolock)
			  WHERE t0.BookID = @bookingId AND t0.[ServiceID] = @ServiceID
		end
		else
		begin
			Select 1
			INSERT INTO [dbo].[zBillDetail]
			   ([BillID]
			   ,[OrderNumber]
			   ,[branchId]
			   ,[ServiceID]
			   ,[Price]
			   ,[Quantity]
			   ,[Discount]
			   ,[Payment]
			   ,[Note]
			   ,[BookID]
			   ,[BookDTID]
			   ,[StaffId]
			   ,[created_by]
			   ,[created_at])
			 VALUES
			 (
			   @BillId
			   ,@Num
			   ,@branchId
			   ,@ServiceID
			   ,@Price
			   ,@Quantity
			   ,@Discount
			   ,@Quantity * @Price - @Discount
			   ,@Note
			   ,null
			   ,null
			   ,@StaffId
			   ,@UserId
			   ,@DateZone
			   )
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


