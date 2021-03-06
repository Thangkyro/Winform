USE [qidjefjs_ausNail]
GO
/****** Object:  StoredProcedure [dbo].[zVoucherCheckAvailable]    Script Date: 6/26/2021 9:19:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROC [dbo].[zVoucherCheckAvailable]
(
@VoucherCode as nvarchar(50),
@DateCheck as datetime
)
AS

-- Author: Kyro
-- Created: 30 May 2021
-- Function: Check vouchercode

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
		where (VoucherCode  = @VoucherCode
			--And is_inactive = 0 
			--And AvailableAmount > 0
			--And (CAST(@DateCheck as Date) between CAST(VoucherFrom as date) and CAST(VoucherTo as date))
			)
	


