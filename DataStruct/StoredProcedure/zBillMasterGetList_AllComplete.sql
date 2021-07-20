
/****** Object:  StoredProcedure [dbo].[zBillMasterGetList_AllComplete]    Script Date: 6/13/2021 5:47:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROC [dbo].[zBillMasterGetList_AllComplete]
(
@branchId as int
)
AS

-- Author: Auto winfred
-- Created: 16 May 2021
-- Function: select a zBillMaster table record

-- Modifications:

	Select 
	BillID,
	branchId,
	BillDate,
	BillCode,
	CustId,
	CustomerPhone,
	TotalEstimatePrice,
	TotalEstimateTime,
	StaffRequire,
	Status,
	Timefinish,
	TotalDiscount,
	PaymentCash,
	PaymentCard,
	PaymentVoucher,
	BookID,
	VoucherID,
	Decriptions,
	created_by,
	created_at,
	modified_by,
	modified_at,
	NumberBill
 FROM  [dbo].[zBillMaster] with(nolock)
 where branchId  = @branchId
		AND Status = 'Complete'


		exec [zBillMasterGetList_AllComplete] 2