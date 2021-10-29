CREATE PROC [dbo].[zBillNumber]
(
	@branchId as int,
	@billDate as date
)
AS

-- Author: Dev
-- Created: 17 July 2021
-- Function: Get bill number by branch

-- Modifications:
	 declare @DateZone Datetime 
	set @DateZone = ISNULL((select top 1 DATEADD(HOUR, CAST(ISNULL(Value,'0') AS INT), GETDATE()) from dbo.[zConfig] where ConfigCode = 'TimeZoneUse' ), GETDATE())

	-- Check datebill of branch
	if cast(@DateZone as date) = @billDate
	begin
		if not exists (select 1 from zbranch with(nolock) where branchId = @branchId  and cast(DateBill as date) = cast(@DateZone as date))
		begin
			update zbranch set NumberBill = 1, DateBill = @DateZone where branchId = @branchId
		end
		select NumberBill from zbranch with(nolock) where branchId = @branchId
	end
	else
	begin
		select ISNULL(Max(NumberBill),0) + 1 from [zBillMaster] with(nolock) where branchId = @branchId and cast(billDate as date) = @billDate
	end
	