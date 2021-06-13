USE [qidjefjs_ausNail]
GO
/****** Object:  StoredProcedure [dbo].[zVoucherUpdate]    Script Date: 6/13/2021 5:13:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[zVoucherUpdateByBill]
(
@VoucherCode as varchar(30),
@AvailableAmount as varchar(50),
@modified_by as int
, @ErrCode INT = 0		OUTPUT
, @ErrMsg NVARCHAR(200) = ''		OUTPUT
)
AS

-- Author: Kyro
-- Created: 13 June 2021
-- Function: Update AvailableAmount for dbo.zVoucher table record

-- Modifications:

begin try

-- update
update [dbo].[zVoucher]
set
		AvailableAmount = AvailableAmount - @AvailableAmount,
		modified_by = coalesce(@modified_by, modified_by),
		modified_at = coalesce(Getdate(), modified_at)
where VoucherCode  = @VoucherCode

end try

begin catch

	declare @ErrorSeverity INT;
	declare @ErrorState INT;

	select @ErrCode = ERROR_NUMBER();

	select @ErrMsg = ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE();

	raiserror (@ErrMsg, @ErrorSeverity, @ErrorState);

end catch;


