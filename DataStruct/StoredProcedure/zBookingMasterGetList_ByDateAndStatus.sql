USE [qidjefjs_ausNail]
GO
/****** Object:  StoredProcedure [dbo].[zBillMasterGetList_AllComplete]    Script Date: 6/16/2021 3:10:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROC [dbo].[zBookingMasterGetList_ByDateAndStatus]
(
@statusBook as nvarchar(50),
@dateBook as datetime,
@timeBook as int
)
AS

-- Author: Auto winfred
-- Created: 16 May 2021
-- Function: select a zBillMaster table record

-- Modifications:

	Select ROW_NUMBER() OVER (ORDER BY t1.created_at) AS No
	   ,t1.BookID
      ,concat(t2.BillCode, ' - ', t1.CustomerPhone) as BillNumber
      ,format(t1.[BookingDate], 'HH:mm:ss tt') as TimeBooking
      ,t1.[TotalEstimateTime] as TimeService
 FROM  [dbo].[zBookingMaster] t1 with(nolock)
	left join [dbo].[zBillMaster] t2 with(nolock) on t1.[BookID] = t2.[BookID]
 where t1.[Status] = @statusBook
	and cast(t1.[BookingDate] as date) = cast(@dateBook as date)
	and datepart(hour,t1.BookingDate) = @timeBook
 order by t1.[created_at]