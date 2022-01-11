/****** Object:  StoredProcedure [dbo].[zBillMasterGetList]    Script Date: 6/12/2021 6:17:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROC [dbo].[zBillMasterGetInfor]
(
@BillID as int,
@branchId as int
)
AS

-- Author: Auto winfred
-- Created: 16 May 2021
-- Function: select a zBillMaster table record

-- Modifications:

 Select 
	t0.BillID,
	t0.branchId,
	t0.BillDate,
	t0.BillCode,
	t0.CustId,
	t1.Name as Cusstomername,
	t1.Gender,
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
	join [dbo].[zCustomer] t1 with(nolock) on t0.CustId = t1.CustId
 where (t0.BillID  = @BillID  AND  t0.branchId  = @branchId)
