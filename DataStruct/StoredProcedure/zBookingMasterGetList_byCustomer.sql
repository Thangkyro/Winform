USE [qidjefjs_ausNail]
GO
/****** Object:  StoredProcedure [dbo].[zBookingMasterGetList]    Script Date: 23/05/2021 10:57:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[zBookingMasterGetList_byCustomer]
(
@CustId as int
)
AS

-- Author: Kyro
-- Created: 22 May 2021
-- Function: select a zBookingMaster table record by Customer

-- Modifications:

	Select 
		t0.BookID,
		t0.branchId,
		t1.BranchName,
		t0.BookingDate,
		t0.CustId,
		t0.CustomerPhone,
		t0.TotalEstimatePrice,
		t0.TotalEstimateTime,
		t0.StaffRequire,
		t0.Status,
		t0.Decriptions,
		t0.created_by,
		t0.created_at,
		t0.modified_by,
		t0.modified_at
	FROM  [dbo].[zBookingMaster] t0 with(nolock)
		Join [dbo].[zBranch] t1 with(nolock) on t0.branchId = t1.branchId
	where CustId  = @CustId


