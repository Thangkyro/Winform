USE [qidjefjs_ausNail]
GO
/****** Object:  StoredProcedure [dbo].[zLedgerBook_GetBill]    Script Date: 22/03/2022 10:05:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- [zLedgerBook_GetBill] '20210925',2

ALTER PROC [dbo].[zLedgerBook_GetBill]
(
@Date as datetime,
@BranchID as int
)
AS

-- Modifications:
	-- Get Locked of LedgerBook in date.
	DECLARE @IsLock INT
	SELECT @IsLock = 1 FROM zLedgerBook WHERE CAST(LedgerDate AS DATE) = CAST(@Date as DATE) AND Locked = 1
	IF @IsLock IS NULL
	BEGIN
		SET @IsLock = 0
	END
	-- Get cash out in LedgerBook
	DECLARE @CashOut Decimal(19,4)
	DECLARE @MaxLedgerDate Datetime
	SELECT @MaxLedgerDate = MAX(LedgerDate) FROM zLedgerBook WHERE CAST(LedgerDate AS DATE) < CAST(@Date as DATE)
	IF @MaxLedgerDate IS NULL
	BEGIN
		SET @CashOut = 0
	END
	ELSE
	BEGIN 
		SELECT @CashOut = CashOut FROM zLedgerBook WHERE CAST(LedgerDate AS DATE) = CAST(@MaxLedgerDate as DATE)
	END

	-- Get data result 
	SELECT 
		CAST(BillDate AS date) AS BillDate,
		@CashOut AS CashOut,
		@IsLock AS IsLock,
		SUM(T.TotalAmount) AS TotalAmount,
		SUM(T.PaymentCash) AS PaymentCash,
		SUM(T.PaymentCard) AS PaymentCard,
		SUM(T.TotalDiscount) AS TotalDiscount,
		SUM(T.PaymentVoucher) AS PaymentVoucher
	FROM
	(
	SELECT 
		t1.BillDate,
		SUM(t3.Quantity * t3.Price) AS TotalAmount,
		SUM(t3.Quantity * t3.Price) - t1.PaymentCash - t1.PaymentCard - t1.PaymentVoucher AS TotalDiscount,
		t1.PaymentCash AS PaymentCash,
		t1.PaymentCard AS PaymentCard,
		t1.PaymentVoucher AS PaymentVoucher 
	FROM  [dbo].[zBillMaster] t1 with(nolock)
		join [dbo].[zBillDetail] t3 with(nolock) on t1.billID = t3.billID
	WHERE   t1.branchId  = @branchId
			AND CAST(t1.BillDate as DATE) = CAST(@Date as DATE) 
			AND [Status] = 'Complete'  
	GROUP BY t1.BillDate,t1.PaymentCash,t1.PaymentCard,t1.PaymentVoucher
	) T  GROUP BY CAST(BillDate AS date)


