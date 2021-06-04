USE [qidjefjs_ausNail]
GO
/****** Object:  StoredProcedure [dbo].[zBookingMasterGetList_byCustomer]    Script Date: 6/4/2021 11:25:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[zBillMasterGetList_byCustomer]
(
@CustId as int
)
AS

-- Author: Kyro
-- Created: 22 May 2021
-- Function: select a zBookingMaster table record by Customer

-- Modifications:

	Select 
		t0.BillID,
		t0.branchId,
		t1.BranchName,
		t0.BillDate,
		t0.CustId,
		t0.CustomerPhone,
		t0.TotalEstimatePrice,
		t0.TotalEstimateTime,
		t0.StaffRequire,
		t0.Status,
		t0.Timefinish,
		t0.TotalDiscount,
		t0.PaymentCash,
		t0.PaymentCard,
		t0.PaymentVoucher,
		t0.BookID,
		t0.VoucherID,
		t0.Decriptions,
		t0.created_by,
		t0.created_at,
		t0.modified_by,
		t0.modified_at
	FROM  [dbo].[zBillMaster] t0 with(nolock)
		Join [dbo].[zBranch] t1 with(nolock) on t0.branchId = t1.branchId
	where CustId  = @CustId
