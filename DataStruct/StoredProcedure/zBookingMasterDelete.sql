USE [qidjefjs_ausNail]
GO
/****** Object:  StoredProcedure [dbo].[zBookingMasterDelete]    Script Date: 6/20/2022 10:40:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROC [dbo].[zBookingMasterDelete]
(
 @BookID as int
, @branchId as int
, @ErrCode INT = 0 OUTPUT
, @ErrMsg NVARCHAR(200) = '' OUTPUT
)
AS

-- Author: Auto winfred
-- Created: 16 May 2021
-- Function: Delete a zBookingMaster table record

-- Modifications:

begin try

	-- delete
	delete [dbo].[zBookingMaster] with(rowlock)
	where branchId = @branchId and BookID = @BookID 

	delete [dbo].[zBookingDetail] with(rowlock)
	where branchId = @branchId and BookID = @BookID 

end try

begin catch

	declare @ErrorSeverity INT;
	declare @ErrorState INT;

	select @ErrCode = ERROR_NUMBER();

	select @ErrMsg = ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE();

	raiserror (@ErrMsg, @ErrorSeverity, @ErrorState);

end catch;


