USE [qidjefjs_ausNail]
GO
/****** Object:  StoredProcedure [dbo].[zBillUpdate]    Script Date: 6/26/2021 1:52:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[zBillUnPaidUpdate]
(
@BillID as int,
@branchId as int,
@modified_by as int
, @ErrCode INT = 0		OUTPUT
, @ErrMsg NVARCHAR(200) = ''		OUTPUT
)
AS

-- Author: Kyro
-- Created: 13 June 2021
-- Function: Update bill master

-- Modifications:

begin try

-- update
update [dbo].[zBillMaster] WITH(ROWLOCK) 
	set
		BillDate = coalesce(Getdate(), BillDate),
		Status = 'New',
		Timefinish = Getdate(),
		PaymentCash = 0,
		PaymentCard = 0,
		PaymentVoucher = 0,
		modified_by = coalesce(@modified_by, modified_by),
		modified_at = coalesce(Getdate(), modified_at)
where BillID  = @BillID  AND  branchId  = @branchId

end try

begin catch

	declare @ErrorSeverity INT;
	declare @ErrorState INT;

	select @ErrCode = ERROR_NUMBER();

	select @ErrMsg = ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE();

	raiserror (@ErrMsg, @ErrorSeverity, @ErrorState);

end catch;


