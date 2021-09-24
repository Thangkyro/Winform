/****** Object:  StoredProcedure [dbo].[zHolidaysGetList]    Script Date: 09/19/2021 21:21:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROC [dbo].[zBannerGetList]
(
@BannerID as int
)
AS

-- Author: Auto winfred
-- Created: 16 May 2021
-- Function: select a zHolidays table record

-- Modifications:

	Select 
	BannerID
	branchId,
	BannerText,
	NumberOrder,
	Decriptions,
	is_inactive,
	created_by,
	created_at,
	modified_by,
	modified_at
 FROM  [dbo].[zBanner] with(nolock)
	where (BannerID = @BannerID OR @BannerID = 0 )


