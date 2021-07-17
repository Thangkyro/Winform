USE [qidjefjs_ausNail]
GO
/****** Object:  StoredProcedure [dbo].[zBillMasterGetList]    Script Date: 07/17/2021 9:58:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[zBillNumber]
(
	@branchId as int
)
AS

-- Author: Dev
-- Created: 17 July 2021
-- Function: Get bill number by branch

-- Modifications:
	
	-- Check datebill of branch
	if not exists (select 1 from zbranch with(nolock) where branchId = @branchId  and cast(DateBill as date) = cast(getdate() as date))
	begin
		update zbranch set NumberBill = 1, DateBill = getdate() where branchId = @branchId
	end

	select NumberBill from zbranch with(nolock) where branchId = @branchId
	