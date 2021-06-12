USE [qidjefjs_ausNail]
GO
/****** Object:  StoredProcedure [dbo].[zVoucherGetList]    Script Date: 6/12/2021 10:56:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[zVoucherGetListAvailable]
AS

-- Author: Kyro
-- Created: 30 May 2021
-- Function: select a zVoucher table record

-- Modifications:

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
			And (CAST(Getdate() as Date) between CAST(VoucherFrom as date) and CAST(VoucherTo as date))


