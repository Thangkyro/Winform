USE [qidjefjs_ausNail]
GO
/****** Object:  StoredProcedure [dbo].[zBillMasterUpdate]    Script Date: 08/28/2021 3:32:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[zBillMasterUpdate_Ver1]
(
@BillID as int,
@branchId as int,
@Decriptions as varchar(2000)
, @ErrCode INT = 0		OUTPUT
, @ErrMsg NVARCHAR(200) = ''		OUTPUT
)
AS
-- Modifications:

begin try

-- update
update [dbo].[zBillMaster] set
		Decriptions = coalesce(@Decriptions, Decriptions)
where BillID  = @BillID  AND  branchId  = @branchId

end try

begin catch

	declare @ErrorSeverity INT;
	declare @ErrorState INT;

	select @ErrCode = ERROR_NUMBER();

	select @ErrMsg = ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE();

	raiserror (@ErrMsg, @ErrorSeverity, @ErrorState);

end catch;


