USE [qidjefjs_ausNail]
GO
/****** Object:  StoredProcedure [dbo].[zBookingDetailGetList_History]    Script Date: 4/24/2022 11:00:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROC [dbo].[zBookingTop1]
(
@branchId as int,
@PhoneNumber as varchar(50)
)
AS

-- Author: Kyro
-- Created: 24 April 2022
-- Function: select top 1 booking infomation => Show add serrvice form.

-- Modifications:
Declare @BookId Int

set @BookId =
(
Select top 1 BookID 
from [dbo].[zBookingMaster] 
Where branchId = @branchId and CustomerPhone = @PhoneNumber and [Status] <> 'ToBill'
order by modified_at desc
)

if @BookId is null
	set @BookId = -1

select 
	@BookId BookId,
	t1.EstimatePrice Price,
	t1.OrderNumber STT,
	t1.ServiceID ServiceID,
	t2.Title ServiceName,
	t1.Quantity Quantity
from [dbo].[zBookingDetail] t1 with(nolock) 
	Join [dbo].[zService] t2 with(nolock) on t1.branchId = t2.branchId and t1.ServiceID = t2.ServiceID
where t1.branchId = @branchId
	and t1.BookID = @BookId


