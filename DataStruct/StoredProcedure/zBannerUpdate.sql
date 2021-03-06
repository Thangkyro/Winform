/****** Object:  StoredProcedure [dbo].[zHolidaysUpdate]    Script Date: 09/19/2021 21:21:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROC [dbo].[zBannerUpdate]
(
@BannerID as int,
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
-- Function: Create or update a dbo.zHolidays table record

-- Modifications:

begin try

-- update
update [dbo].[zBanner] WITH(ROWLOCK) set
		branchId = coalesce(@branchId, branchId),
		BannerText = coalesce(@BannerText, BannerText),
		NumberOrder = coalesce(@NumberOrder, NumberOrder),
		Decriptions = coalesce(@Decriptions, Decriptions),
		is_inactive = coalesce(@is_inactive, is_inactive),
		created_by = coalesce(@created_by, created_by),
		created_at = coalesce(@created_at, created_at),
		modified_by = coalesce(@modified_by, modified_by),
		modified_at = coalesce(@modified_at, modified_at)
where BannerID = @BannerID

end try

begin catch

	declare @ErrorSeverity INT;
	declare @ErrorState INT;

	select @ErrCode = ERROR_NUMBER();

	select @ErrMsg = ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE();

	raiserror (@ErrMsg, @ErrorSeverity, @ErrorState);

end catch;


