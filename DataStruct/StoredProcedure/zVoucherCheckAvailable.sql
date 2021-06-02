USE [qidjefjs_ausNail]
GO
/****** Object:  StoredProcedure [dbo].[zVoucherGetList]    Script Date: 30/05/2021 5:47:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[zVoucherCheckAvailable]
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
			And is_inactive = 0 
			And Amount > 0
			And (CAST(@DateCheck as Date) between CAST(VoucherFrom as date) and CAST(VoucherTo as date))
			)
	


