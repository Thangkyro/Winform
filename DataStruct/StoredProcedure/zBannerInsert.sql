USE [qidjefjs_ausNail]
GO
/****** Object:  StoredProcedure [dbo].[zHolidaysInsert]    Script Date: 09/19/2021 21:21:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROC [dbo].[zBannerInsert]
(
@branchId as int,
@BannerText as nvarchar(max),
@NumberOrder as int,
@Decriptions as varchar(2000),
@is_inactive as bit,
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
-- Function: Inserts a dbo.zHolidays table record

-- Modifications:

begin try

-- insert
insert 	[dbo].[zBanner] (branchId,BannerText,NumberOrder,Decriptions,is_inactive,created_by,created_at,modified_by,modified_at)
values	(@branchId,@BannerText,@NumberOrder,@Decriptions,@is_inactive,@created_by,@created_at,@modified_by,@modified_at)


-- Return the new ID
end try

begin catch

	declare @ErrorSeverity INT;
	declare @ErrorState INT;

	select @ErrCode = ERROR_NUMBER();

	select @ErrMsg = ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE();

	raiserror (@ErrMsg, @ErrorSeverity, @ErrorState);

end catch;


