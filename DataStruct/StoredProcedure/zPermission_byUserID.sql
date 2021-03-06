
/****** Object:  StoredProcedure [dbo].[zUserGetList]    Script Date: 7/24/2021 8:07:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[zPermission_byUserID]
(
@Userid as int
)
AS
begin
	declare @permission nvarchar(max);

	set @permission = (select permission from  [dbo].[zUser] with(nolock) where Userid = @Userid);
	
	if (ISNULL(@permission, '') = '')
		begin
			 select [cmd_key]
				  ,[parent_key]
				  ,[is_group]
				  ,[ordinal]
				  ,[text]
				  ,[description]
				  ,[is_inactive]
				  ,[is_dev]
				  , 0 as allow
			  from [dbo].[zPermission] t1 with(nolock) 
			  where is_inactive = 0;
		end
	else
		begin
			select [cmd_key]
				  ,[parent_key]
				  ,[is_group]
				  ,[ordinal]
				  ,[text]
				  ,[description]
				  ,[is_inactive]
				  ,[is_dev]
				  , case when ISNULL(t2.splitdata,'') = '' then 0 else 1 end as allow
			  from [dbo].[zPermission] t1 with(nolock)
					left join dbo.ufn_SeperateStringByDelimiter(@permission,',') t2 on t2.splitdata = t1.cmd_key
			  where is_inactive = 0

		end

end
