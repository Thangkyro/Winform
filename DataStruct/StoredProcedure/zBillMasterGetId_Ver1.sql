USE [qidjefjs_ausNail]
GO
/****** Object:  StoredProcedure [dbo].[zBillInsert]    Script Date: 6/5/2021 5:33:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[zBillMasterGetId_Ver1]
(
	@branchId as int,
	@BillCode as varchar(100),
	@ErrCode INT = 0 OUTPUT,
	@ErrMsg NVARCHAR(200) = '' OUTPUT
)
AS

-- Author: Auto Kyro
-- Created: 31 May 2021
-- Function: Inserts a dbo.zBillMaster, zBillDetail table record by Booking infor.

-- Modifications:

begin try
	
	SELECT BillId FROM [dbo].[zBillMaster] with(nolock) WHERE BranchId = @branchId And BillCode = @BillCode

end try

begin catch

	declare @ErrorSeverity INT;
	declare @ErrorState INT;

	select @ErrCode = ERROR_NUMBER();

	select @ErrMsg = ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE();

	raiserror (@ErrMsg, @ErrorSeverity, @ErrorState);

end catch;


