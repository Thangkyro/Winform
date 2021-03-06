USE [qidjefjs_ausNail]
GO
/****** Object:  StoredProcedure [dbo].[zBranchDelete]    Script Date: 6/14/2021 4:11:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[zBranchCheckUse]
(
@branchId as int
)
AS

begin 

	if exists(
				select TOP 1 1 from [dbo].[zHolidays] with(nolock)
				where branchId = @branchId
				union all
				select TOP 1 1 from [dbo].[zBusinessHour] with(nolock)
				where branchId = @branchId
				union all
				select TOP 1 1 from [dbo].[zService] with(nolock)
				where branchId = @branchId
				union all
				select TOP 1 1 from [dbo].[zCustomer] with(nolock)
				where branchId = @branchId
				union all
				select TOP 1 1 from [dbo].[zStaff] with(nolock)
				where branchId = @branchId
				union all
				select TOP 1 1 from [dbo].[zUser] with(nolock)
				where branchId = @branchId
				)
		begin
			select 1
		end

end




