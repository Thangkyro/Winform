CREATE PROC [dbo].[zVoucherGetListAvailable]
AS

-- Author: Kyro
-- Created: 30 May 2021
-- Function: select a zVoucher table record

-- Modifications:
	declare @DateZone Datetime 
	set @DateZone = ISNULL((select top 1 DATEADD(HOUR, CAST(ISNULL(Value,'0') AS INT), GETDATE()) from dbo.[zConfig] where ConfigCode = 'TimeZoneUse' ), GETDATE())

	Select 
	VoucherID,
	VoucherCode,
	Amount,
	AvailableAmount,
	IssueDate,
	IssueBy,
	VoucherFrom,
	VoucherTo,
	zPrintname,
	Decriptions,
	is_inactive,
	created_by,
	created_at,
	modified_by,
	modified_at
 FROM  [dbo].[zVoucher] with(nolock)
	where AvailableAmount > 0
			And (CAST(@DateZone as Date) between CAST(VoucherFrom as date) and CAST(VoucherTo as date))


