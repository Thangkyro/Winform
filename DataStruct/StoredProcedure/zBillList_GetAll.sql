USE [qidjefjs_ausNail]
GO
/****** Object:  StoredProcedure [dbo].[zBillList_GetAll]    Script Date: 10/23/2021 12:19:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--[zBillList_GetAll] '20211004','20211025','','Compare',2
ALTER PROC [dbo].[zBillList_GetAll]
(
@FromDate as datetime,
@ToDate as datetime,
@CustomerPhone as varchar(100),
@PaymentMethod as varchar(20),
@BranchID as int
)
AS

-- Author: Auto winfred
-- Created: 16 May 2021
-- Function: select a zBillMaster table record

-- Modifications:

	Select 
	 ROW_NUMBER() OVER(ORDER BY t1.BillDate, t1.NumberBill ASC) AS No,
	--CAST(t1.BillDate as DATE) as BillDate,
	FORMAT(t1.BillDate,'dd/MM/yyyy') as BillDate,
	t1.NumberBill,
	t2.Name as CustomerName,
	t1.CustomerPhone,
	t1.Decriptions,
	t1.TotalEstimatePrice as TotalAmount,
	t1.TotalDiscount,
	t1.PaymentCash,
	t1.PaymentCard,
	t1.PaymentVoucher,
	t1.BillID
	From  [dbo].[zBillMaster] t1 with(nolock)
		join [dbo].[zCustomer] t2 with(nolock) on t1.CustId = t2.CustId
	
	Where (ISNULL(@CustomerPhone,'') = '' OR  t1.CustomerPhone  = @CustomerPhone)  
			AND  (t1.branchId  = @branchId)
			AND (CAST(t1.BillDate as DATE) BETWEEN CAST(@FromDate as DATE) AND CAST(@ToDate as DATE))
			AND (
					(@PaymentMethod = 'Card' AND t1.PaymentCard > 0 )
				OR (@PaymentMethod = 'Cash' AND t1.PaymentCash > 0 )
				OR (@PaymentMethod = 'Compare' AND t1.PaymentVoucher > 0 )
				OR (@PaymentMethod = 'All' AND 1 = 1)
			)
			AND Status = 'Complete'  
	Order by t1.BillDate, t1.NumberBill



