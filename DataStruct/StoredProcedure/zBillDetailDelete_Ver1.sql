USE [qidjefjs_ausNail]
GO
/****** Object:  StoredProcedure [dbo].[zBillDetailDelete]    Script Date: 6/5/2021 10:51:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[zBillDetailDelete_Ver1]
(
 @BillID   as int = 0 
, @branchId as int  = 0 
, @ErrCode INT = 0 OUTPUT
, @ErrMsg NVARCHAR(200) = '' OUTPUT
)
AS

-- Author: Auto winfred
-- Created: 16 May 2021
-- Function: Delete a zBillDetail table record

-- Modifications:

begin try

	-- delete
	delete [dbo].[zBillDetail]
	where branchId = @branchId   and BillID = @BillID
	
	--delete [dbo].zRevenueDetail
	--where branchId = @branchId and BillDtID = @BillDtID and
	--		OrderNumber = @OrderNumber  and BillID = @BillID AND Code = 'BLL'

end try

begin catch

	declare @ErrorSeverity INT;
	declare @ErrorState INT;

	select @ErrCode = ERROR_NUMBER();

	select @ErrMsg = ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE();

	raiserror (@ErrMsg, @ErrorSeverity, @ErrorState);

end catch;


