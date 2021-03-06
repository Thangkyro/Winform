/****** Object:  StoredProcedure [dbo].[zBillDetailGetList_History]    Script Date: 6/29/2021 4:28:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROC [dbo].[zBillDetailGetList_History]
(
@BillID as int,
@branchId as int
)
AS

-- Author: Kyro
-- Created: 22 May 2021
-- Function: select a zBookingDetail table record

-- Modifications:

 Select 
	t0.BillDTID,
	t0.BillID,
	t0.OrderNumber,
	t0.branchId,
	t0.ServiceID,
	t1.Title as ServiceName,
	ISNULL(t0.Price,t1.Price) as Price,
	t0.Payment as Amout,
	t0.Quantity,
	t1.EstimateTime,
	t0.Note,
	t0.StaffId,
	t0.Discount,
	ISNULL(t2.Name,'') as StaffName,
	t0.created_by,
	t0.created_at
 FROM  [dbo].[zBillDetail] t0 with(nolock)
	Join [dbo].[zService] t1 with(nolock) on t0.branchId = t1.branchId and t0.ServiceID = t1.ServiceID
	Left Join [dbo].[zStaff] t2  with(nolock) on t0.StaffId = t2.StaffId
 where (t0.BillID  = @BillID  AND  t0.branchId  = @branchId)


