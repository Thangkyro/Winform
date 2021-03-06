
/****** Object:  StoredProcedure [dbo].[zStaffImagesInsert]    Script Date: 7/9/2021 11:05:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROC [dbo].[zStaffImagesInsert]
(
@StaffId as int,
@Image as varbinary(max) = Null,
@Image_small as varbinary(max) = Null,
@created_by as int,
@created_at as datetime,
@modified_by as int,
@modified_at as datetime
, @ErrCode INT = 0		OUTPUT
, @ErrMsg NVARCHAR(200) = ''		OUTPUT
)
AS

-- Author: Auto winfred
-- Created: 16 May 2021
-- Function: Inserts a dbo.zStaffImages table record

-- Modifications:

begin try

delete [dbo].[zStaffImages]  where StaffId = @StaffId

-- insert
insert 	[dbo].[zStaffImages] (StaffId,Image,Image_small,created_by,created_at,modified_by,modified_at)
values	(@StaffId,@Image,@Image_small,@created_by,@created_at,@modified_by,@modified_at)


-- Return the new ID
end try

begin catch

	declare @ErrorSeverity INT;
	declare @ErrorState INT;

	select @ErrCode = ERROR_NUMBER();

	select @ErrMsg = ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE();

	raiserror (@ErrMsg, @ErrorSeverity, @ErrorState);

end catch;


