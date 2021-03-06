CREATE PROC [dbo].[zBookingInsert]
(
@BookingDate as datetime,
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
	 declare @DateZone Datetime 
	set @DateZone = ISNULL((select top 1 DATEADD(HOUR, CAST(ISNULL(Value,'0') AS INT), GETDATE()) from dbo.[zConfig] where ConfigCode = 'TimeZoneUse' ), GETDATE())

	Declare @CustId as int
	SELECT @CustId = CustId FROM [dbo].[zCustomer] with(nolock) WHERE (ISNULL(PhoneNumber1, '') = @CustomerPhone Or ISNULL(PhoneNumber2, '') = @CustomerPhone ) ORDER BY CustId DESC

	if @CustId is null
	begin
		select @ErrCode = -260597;
		select @ErrMsg = N'Customer not exists.';
	end
-- Check exists Booking.
	if not exists (
		Select 1 
		from [dbo].[zBookingMaster]  with(nolock)
		where [branchId] =  @branchId and CAST([BookingDate] as date) = CAST(@BookingDate as date)
			and [CustId] = @CustId and [Status] = 'Temporary' )
	begin
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
           ,@BookingDate
           ,@CustId
           ,@CustomerPhone
           ,0 -- TotalEstimatePrice
           ,0 -- TotalEstimateTime
           ,0 -- StaffRequire
           ,'Temporary'
           ,null
           ,@UserId
           ,@DateZone
           ,@UserId
           ,@DateZone);
	end

	-- Get the ID Booking
		Declare @IdBooking as int
		SELECT @IdBooking = BookID 
		FROM [dbo].[zBookingMaster] with(nolock)
		WHERE [branchId] =  @branchId 
			and CAST([BookingDate] as date) = CAST(@BookingDate as date)
			and [CustId] = @CustId and [Status] = 'Temporary'

	-- Get service infor
		Declare @EstimateTime as decimal(19,4)
		SELECT @EstimateTime = EstimateTime FROM dbo.[zService] with(nolock) Where ServiceID = @ServiceID
		Delete [dbo].[zBookingDetail] Where branchId = @branchId AND BookID = @IdBooking And [OrderNumber] + 1 > @Num
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
			   ,@DateZone)
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


