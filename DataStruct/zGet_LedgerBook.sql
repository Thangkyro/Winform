USE [qidjefjs_ausNail]
GO
/****** Object:  StoredProcedure [dbo].[zBillDetailList_GetByGroup]    Script Date: 20/03/2022 10:37:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[zGet_LedgerBook]
(
@BranchID as Varchar(50),
@FromDate as datetime,
@ToDate as datetime
)
AS
BEGIN
	SELECT 
		[LedgerDate],
		[CashIn],
		[RevenueCash],
		[RevenueBank],
		[RenenueVoucher],
		[ExpenseCash],
		[CashOut],
		[CheckedCash],
		[Locked]
	FROM [dbo].[zLedgerBook]
	WHERE (CAST([LedgerDate] as DATE) BETWEEN CAST(@FromDate as DATE) AND CAST(@ToDate as DATE))
		AND [branchId] = @BranchID
END


