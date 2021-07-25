
GO
/****** Object:  StoredProcedure [dbo].[zBranchCheckUse]    Script Date: 7/25/2021 1:18:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[zUserCheckUse]
(
@userID as int
)
AS

begin 

	if exists(
				select TOP 1 1 from [dbo].[zBillMaster] with(nolock)
				where created_by = @userID
				union all
				select TOP 1 1 from [dbo].[zBookingMaster] with(nolock)
				where created_by = @userID
				)
		begin
			select 1
		end



end




