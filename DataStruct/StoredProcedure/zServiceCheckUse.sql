USE [qidjefjs_ausNail]
GO
/****** Object:  StoredProcedure [dbo].[zBranchDelete]    Script Date: 6/14/2021 4:11:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[zServiceCheckUse]
(
@serviceId as int
)
AS

begin 

	if exists(
				select TOP 1 1 from [dbo].[zBookingDetail] with(nolock)
				where ServiceID = @serviceId
				union all
				select TOP 1 1 from [dbo].[zRevenueDetail] with(nolock)
				where ServiceID = @serviceId
				union all
				select TOP 1 1 from [dbo].[zBillDetail] with(nolock)
				where ServiceID = @serviceId
				)
		begin
			select 1
		end

end




