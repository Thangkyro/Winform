USE [qidjefjs_ausNail]
GO
/****** Object:  StoredProcedure [qidjefjs_Dev].[zBillTempoary]    Script Date: 6/13/2021 7:04:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Kyro 
-- Create date: 03/06/2021
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [zBillPrint]
	@BillId int,
	@BranchID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
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
		t4.[Name] as StaffName ,
		t1.Note,
		t3.EstimateTime,
		t0.[Status],
		t0.TotalDiscount,
		t0.PaymentCash,
		t0.PaymentCard,
		t0.PaymentVoucher
	FROM dbo.[zBillMaster] t0 with(nolock)
		join dbo.[zBillDetail] t1 with(nolock) on t0.branchId = t1.branchId and t0.BillID = t1.BillID
		join dbo.[zCustomer] t2 with(nolock) on t0.branchId = t2.branchId and t0.CustId = t2.CustId
		join dbo.[zService] t3 with(nolock) on t1.branchId = t3.branchId and t1.ServiceID = t3.ServiceID
		join dbo.[zStaff] t4 with(nolock) on t1.branchId = t4.branchId and t1.StaffId = t4.StaffId
	WHERE t0.branchId = @BranchID
		And t0.BillID = @BillId
END
