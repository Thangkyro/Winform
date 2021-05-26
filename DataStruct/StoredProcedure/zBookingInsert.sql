USE [qidjefjs_ausNail]
GO
/****** Object:  StoredProcedure [dbo].[zBranchInsert]    Script Date: 27/05/2021 5:29:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROC [dbo].[zBookingInsert]
(
@branchId as int,
@CustomerPhone as varchar(100),
@Num as int,
@ServiceID as int,
@Quantity as Decimal(19,4),
@EstimatePrice as Decimal(19,4),
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

-- insert master
	INSERT INTO [dbo].[zBookingMaster]
           ([branchId]
           ,[BookingDate]
           ,[CustId]
           ,[CustomerPhone]
           ,[TotalEstimatePrice]
           ,[TotalEstimateTime]
           ,[StaffRequire]
           ,[Status]
           ,[Decriptions]
           ,[created_by]
           ,[created_at]
           ,[modified_by]
           ,[modified_at])
     VALUES
           (@branchId
           ,Getdate()
           ,@CustId
           ,@CustomerPhone
           ,0 -- TotalEstimatePrice
           ,0 -- TotalEstimateTime
           ,0 -- StaffRequire
           ,'Temporary'
           ,null
           ,@UserId
           ,Getdate()
           ,@UserId
           ,Getdate());

-- Return the new ID
	Declare @IdBooking as int
	SELECT @IdBooking = BookID FROM [dbo].[zBookingMaster] with(nolock) ORDER BY BookID DESC


-- Get service infor
	Declare @EstimateTime as decimal(19,4)
	SELECT @EstimateTime = EstimateTime FROM dbo.[zService] with(nolock) Where ServiceID = @ServiceID
-- insert detail
	INSERT INTO [dbo].[zBookingDetail]
           ([BookID]
           ,[OrderNumber]
           ,[branchId]
           ,[ServiceID]
           ,[Quantity]
           ,[EstimatePrice]
           ,[EstimateTime]
           ,[Note]
           ,[StaffId]
           ,[created_by]
           ,[created_at])
     VALUES
           (@IdBooking
           ,@Num
           ,@branchId
           ,@ServiceID
           ,@Quantity
           ,@EstimatePrice
           ,@EstimateTime
           ,@Note
           ,@StaffId
           ,@UserId
           ,GETDATE())
-- update master value
	Update t0
	Set t0.TotalEstimatePrice = t1.TotalEstimatePrice,
		t0.TotalEstimateTime = t1.TotalEstimateTime
	From [dbo].[zBookingMaster] t0
		join ( Select SUM(EstimatePrice) as TotalEstimatePrice,SUM(EstimateTime) as TotalEstimateTime, branchId, BookID 
			   from  [dbo].[zBookingDetail] with (nolock)
			   where BookID = @IdBooking 
			   group by branchId,BookID ) t1 on t0.branchId = t1.branchId and t0.BookID = t1.BookID
	where t0.BookID = @IdBooking

end try

begin catch

	declare @ErrorSeverity INT;
	declare @ErrorState INT;

	select @ErrCode = ERROR_NUMBER();

	select @ErrMsg = ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE();

	raiserror (@ErrMsg, @ErrorSeverity, @ErrorState);

end catch;


