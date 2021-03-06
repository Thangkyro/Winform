USE [qidjefjs_ausNail]
GO
/****** Object:  StoredProcedure [dbo].[zBookingDetailDelete]    Script Date: 6/17/2021 11:33:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[zBookingDetailDeleteByBookID]
(
 @BookID   as int = 0 
, @branchId as int  = 0 
, @ErrCode INT = 0 OUTPUT
, @ErrMsg NVARCHAR(200) = '' OUTPUT
)
AS

-- Author: Auto winfred
-- Created: 16 May 2021
-- Function: Delete a zBookingDetail table record

-- Modifications:

begin try

	-- delete
	delete [dbo].[zBookingDetail]  with(rowlock)
	where branchId = @branchId and  BookID = @BookID
end try

begin catch

	declare @ErrorSeverity INT;
	declare @ErrorState INT;

	select @ErrCode = ERROR_NUMBER();

	select @ErrMsg = ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE();

	raiserror (@ErrMsg, @ErrorSeverity, @ErrorState);

end catch;


