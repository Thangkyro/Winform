
ALTER PROC [dbo].[zBillPrintNew]
(
	@BillId int,
	@BranchID int
)
AS

-- Author: Auto winfred
-- Created: 16 May 2021
-- Function: select a zVoucher table record

-- Modifications:

	SELECT 
		t0.BillDate,
		t0.BillCode,
		t2.[Name] as CustomerName,
		t0.CustomerPhone,
		t1.OrderNumber,
		t3.Title as ServiceName,
		t1.Quantity,
		t1.Price,
		t1.Quantity * t1.Price as Amount,
		ISNULL(t4.[Name],'') as StaffName ,
		t1.Note,
		t3.EstimateTime,
		CASE WHEN t0.[Status] <> 'Complete' THEN 'Temporary bill' ELSE t0.[Status] END As [Status],
		t0.TotalDiscount,
		t0.PaymentCash,
		t0.PaymentCard,
		t0.PaymentVoucher,
		t0.NumberBill
	FROM dbo.[zBillMaster] t0 with(nolock)
		join dbo.[zBillDetail] t1 with(nolock) on t0.branchId = t1.branchId and t0.BillID = t1.BillID
		join dbo.[zCustomer] t2 with(nolock) on  t0.CustId = t2.CustId
		join dbo.[zService] t3 with(nolock) on t1.branchId = t3.branchId and t1.ServiceID = t3.ServiceID
		Left join dbo.[zStaff] t4 with(nolock) on t1.StaffId = t4.StaffId
	WHERE t0.branchId = @BranchID
		And t0.BillID = @BillId


