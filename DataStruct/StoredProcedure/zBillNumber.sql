USE [qidjefjs_ausNail]
GO
/****** Object:  StoredProcedure [dbo].[zBillNumber]    Script Date: 10/29/2021 9:09:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROC [dbo].[zBillNumber]
(
	@branchId as int,
	@billDate as date
)
AS

-- Author: Dev
-- Created: 17 July 2021
-- Function: Get bill number by branch

-- Modifications:
	
	-- Check datebill of branch
	if cast(GETDATE() as date) = @billDate
	begin
		if not exists (select 1 from zbranch with(nolock) where branchId = @branchId  and cast(DateBill as date) = cast(getdate() as date))
		begin
			update zbranch set NumberBill = 1, DateBill = getdate() where branchId = @branchId
		end
		select NumberBill from zbranch with(nolock) where branchId = @branchId
	end
	else
	begin
		select ISNULL(Max(NumberBill),0) + 1 from [zBillMaster] with(nolock) where branchId = @branchId and cast(billDate as date) = @billDate
	end
	