USE [qidjefjs_ausNail]
GO
/****** Object:  StoredProcedure [dbo].[zBillInsert_Ver1]    Script Date: 6/16/2021 1:57:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[zBillInsert_FromBooking]
(
@bookID as int,
@branchId as int,
@userId as int,
@billDate as datetime,
@billCode as nvarchar(100),
@ErrCode INT = 0 OUTPUT,
@ErrMsg NVARCHAR(200) = '' OUTPUT
)
AS

begin try

	Declare @CustId as int
	Declare @idBillMaster as int
	SELECT @CustId = t1.CustId 
	FROM [dbo].[zCustomer]  t1 with(nolock)
		join [dbo].[zBookingMaster] t2 with(nolock) on t1.[CustId] = t2.[CustId]
	WHERE t2.[BookID] = @bookID

	if @CustId is null
	begin
		select @ErrCode = -260597;
		select @ErrMsg = N'Customer not exists.';
		return;
	end
-- Check exists bill.
	if not exists (
		Select 1 
		from [dbo].[zBillMaster]  with(nolock)
		where [branchId] =  @branchId and CAST([BillDate] as date) = CAST(@billDate as date)
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
			 select 
				@branchId
			   ,@billDate
			   ,@billCode
			   ,@CustId
			   ,[CustomerPhone]
			   ,[TotalEstimatePrice]
			   ,[TotalEstimateTime]
			   ,[StaffRequire]
			   ,'New'
			   ,@BookID
			   , null
			   ,[Decriptions]
				,@UserId
			   ,Getdate()
			   ,@UserId
			   ,Getdate()
			 from [dbo].[zBookingMaster]
			 where BookID  = @BookID  
				AND branchId = @branchId;

			--Check success insert detail
			if(@@ROWCOUNT>0) -- success
				begin
					set @idBillMaster = SCOPE_IDENTITY();
					-- insert detail
					insert into [dbo].[zBillDetail]
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
					select
						@idBillMaster
						,[OrderNumber]
						,[branchId]
						,[ServiceID]
						,[Quantity]
						,[EstimatePrice]
						, 0
						, [Quantity] * [EstimatePrice]
						,@BookID
						,[BookDTID]
						,[Note]
						,[StaffId]
						,@UserId
						,GETDATE()
					from [dbo].[zBookingDetail]
					where BookID  = @BookID 


				end
		end
	else
		begin
			select @ErrCode = -260000;
			select @ErrMsg = N'Exists bill of customer unpaid.';
			return;
		end
end try

begin catch

	declare @ErrorSeverity INT;
	declare @ErrorState INT;

	select @ErrCode = ERROR_NUMBER();

	select @ErrMsg = ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE();

	raiserror (@ErrMsg, @ErrorSeverity, @ErrorState);

end catch;


