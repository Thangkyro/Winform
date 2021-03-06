CREATE PROC [dbo].[zStaffCheckFreeTime]
(
@branchId as int,
@staffId as int,
@serviceId as int
)
AS

-- Author: Kyro
-- Created: 24 May 2021
-- Function: select a zStaff table record

-- Modifications:
	declare @DateZone Datetime 
	set @DateZone = ISNULL((select top 1 DATEADD(HOUR, CAST(ISNULL(Value,'0') AS INT), GETDATE()) from dbo.[zConfig] where ConfigCode = 'TimeZoneUse' ), GETDATE())

	Declare @Totaltime as Decimal(19,4) = 0
	Declare @Esttime as Decimal(19,4) = 0
	Declare @flag as char(1) = '0'

	-- Get time total from current booking.
	select @Totaltime = sum(t1.EstimateTime) 
	from dbo.[zBookingMaster] t0 with (nolock)
		Join dbo.[zBookingDetail] t1 with (nolock) on t0.BookID = t1.BookID
	where t0.BookingDate = @DateZone
		and t1.StaffId = @staffId 
		and t0.branchId = @branchId
		and t0.Status = 'Temporary'

	if( @Totaltime is null)
	begin
		set @Totaltime = 0
	end

	-- Get estimate time of service
	select @Esttime = EstimateTime
	from dbo.[zService] with (nolock)
	where branchId = @branchId and ServiceID = @serviceId

	if (@Esttime is null)
	begin
		set @Esttime = 0
	end

	-- Check time work (default 8h) -> miss case working in shifts
	if(@Totaltime + @Esttime > 8)
	begin
		set @flag = '1'
	end

	---- Check time of day.
	--if(@Esttime > (SELECT DATEDIFF(hour, Getdate(), (select CONVERT(NVARCHAR(64),GETDATE(),101) + ' 18:00:00'))) And (SELECT DATEDIFF(hour, Getdate(), (select CONVERT(NVARCHAR(64),GETDATE(),101) + ' 18:00:00'))) > 0)
	--begin
	--	set @flag = '1'
	--end

	
	select @flag

