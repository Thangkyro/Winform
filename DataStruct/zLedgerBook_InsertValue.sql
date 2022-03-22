USE [qidjefjs_ausNail]
GO

ALTER PROC [zLedgerBook_InsertValue]
	@branchId AS int,
    @LedgerDate AS datetime,
    @CashIn AS decimal(19,4),
    @RevenueCash AS decimal(19,4),
    @RevenueBank AS decimal(19,4),
    @RenenueVoucher AS decimal(19,4),
    @ExpenseCash AS decimal(19,4),
    @CashOut AS decimal(19,4),
    @CheckedCash AS decimal(19,4),
    @Locked AS bit,
	@UserID AS INT
AS
BEGIN

IF NOT EXISTS (SELECT 1 FROM [dbo].[zLedgerBook] WHERE [branchId] = @branchId  AND CAST([LedgerDate] AS DATE) = CAST(@LedgerDate AS DATE))
BEGIN
	INSERT INTO [dbo].[zLedgerBook]
	           ([branchId]
	           ,[LedgerDate]
	           ,[CashIn]
	           ,[RevenueCash]
	           ,[RevenueBank]
	           ,[RenenueVoucher]
	           ,[ExpenseCash]
	           ,[CashOut]
	           ,[CheckedCash]
	           ,[Locked]  
			   ,[Decriptions]         
	           ,[created_by]
	           ,[created_at]
	           ,[modified_by]
	           ,[modified_at])
	     VALUES
	           (
	            @branchId
	           ,@LedgerDate
	           ,@CashIn
	           ,@RevenueCash
	           ,@RevenueBank
	           ,@RenenueVoucher
	           ,@ExpenseCash
	           ,@CashOut
	           ,@CheckedCash
	           ,@Locked
			   ,''
	           ,@UserID
	           ,GETUTCDATE()
	            ,@UserID
	           ,GETUTCDATE())
	END
END

