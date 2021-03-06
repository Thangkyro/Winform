/****** Object:  StoredProcedure [dbo].[zBillList_GetAll]    Script Date: 11/6/2021 9:00:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--[zBillList_GetAll] '20211106','20211106','','All',2
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
	CAST(t1.NumberBill AS INT) AS NumberBill,
	t2.Name as CustomerName,
	t1.CustomerPhone,
	t1.Decriptions,
	CAST(SUM(t3.Quantity * t3.Price) as numeric(19,2)) as TotalAmount,
	CAST((SUM(t3.Quantity * t3.Price) - t1.PaymentCash - t1.PaymentCard - t1.PaymentVoucher) as numeric(19,2)) as TotalDiscount,
	CAST(t1.PaymentCash as numeric(19,2)) AS PaymentCash,
	CAST(t1.PaymentCard as numeric(19,2)) AS PaymentCard,
	CAST(t1.PaymentVoucher as numeric(19,2)) AS PaymentVoucher ,
	t1.BillID
	From  [dbo].[zBillMaster] t1 with(nolock)
		join [dbo].[zCustomer] t2 with(nolock) on t1.CustId = t2.CustId
		join [dbo].[zBillDetail] t3 with(nolock) on t1.billID = t3.billID
	
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
	GROUP BY t1.BillDate, t1.NumberBill,t2.Name, t1.CustomerPhone,t1.Decriptions,t1.TotalDiscount,t1.PaymentCash,t1.PaymentCard,t1.PaymentVoucher,t1.BillID
	Order by t1.BillDate, t1.NumberBill



