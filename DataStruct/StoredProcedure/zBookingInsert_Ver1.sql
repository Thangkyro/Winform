ALTER PROC [dbo].[zBookingInsert_Ver1]
(
@bookID as int,
@BillDate as datetime,
@branchId as int,
@CustomerPhone as varchar(100),
@Num as int,
@ServiceID as int,
@Quantity as Decimal(19,4),
@Price as Decimal(19,4),
@Note as varchar(1000),
@UserId as int,
@IsCheck as int,
@Description as nvarchar(2000),
@ShortDescription as nvarchar(500),
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
	SET @CustId =  (select top 1 CustId FROM [dbo].[zCustomer] with(nolock) WHERE (ISNULL(PhoneNumber1, '') = @CustomerPhone Or ISNULL(PhoneNumber2, '') = @CustomerPhone ) ORDER BY CustId DESC)

	if @CustId is null
	begin
		select @ErrCode = -260597;
		select @ErrMsg = N'Customer not exists.';
	end
-- Check exists bill.
	if (@bookID = 0 and @IsCheck = 0)
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
           ,[created_by]
           ,[created_at]
           ,[modified_by]
           ,[modified_at]
		   ,[Decriptions] 
		   ,[ShortDecriptions]
		   )
		 VALUES
           (@branchId
           ,@BillDate
           ,@CustId
           ,@CustomerPhone
           ,0 -- TotalEstimatePrice
           ,0 -- TotalEstimateTime
           ,0 -- StaffRequire
           ,'Temporary'
           ,@UserId
           ,@DateZone
           ,@UserId
           ,@DateZone
		   ,@Description
		   ,@ShortDescription
		   );
	end
	else if (@bookID <> 0 )
	begin
		 update  [dbo].[zBookingMaster]
		  set BookingDate = @BillDate
				, Decriptions = @Description
				, ShortDecriptions = @ShortDescription
		  where BookID = @bookID
	end

	-- Get the ID Booking
	Declare @IdBooking as int
	if @bookID <> 0
		begin
			set @IdBooking = @bookID;
		end
	else
		begin
			set @IdBooking = ( select MAX(BookID)
								FROM [dbo].[zBookingMaster] with(nolock)
								WHERE [branchId] =  @branchId 
									and [BookingDate]  = @BillDate
									and [CustId] = @CustId 
									and [Status] = 'Temporary')
		end
		

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
			   ,@Price
			   ,@EstimateTime
			   ,@Note
			   ,0
			   ,@UserId
			   ,@DateZone)

		-- update master value
		Update t0
		Set t0.TotalEstimatePrice = t1.TotalEstimatePrice,
			t0.TotalEstimateTime = t1.TotalEstimateTime
		From [dbo].[zBookingMaster] t0
			join ( Select SUM(Quantity * EstimatePrice) as TotalEstimatePrice,SUM(Quantity * EstimateTime) as TotalEstimateTime, branchId, BookID
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
