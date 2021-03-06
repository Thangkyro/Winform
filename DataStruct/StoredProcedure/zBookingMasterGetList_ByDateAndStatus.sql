
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
      ,case when isnull(t2.BillCode,'') <> ''
			then concat(t2.BillCode, ' - ', t3.Name, ' - ', t1.CustomerPhone)
			else concat(t3.Name, ' - ', t1.CustomerPhone) end as BillNumber
	  , t1.Decriptions
      ,format(t1.[BookingDate], 'HH:mm:ss tt') as TimeBooking
      ,t1.[TotalEstimateTime] as TimeService
 FROM  [dbo].[zBookingMaster] t1 with(nolock)
	join [dbo].[zCustomer] t3 with(nolock) on t1.[CustId] = t3.[CustId]
	left join [dbo].[zBillMaster] t2 with(nolock) on t1.[BookID] = t2.[BookID]

 where t1.[Status] = @statusBook
	and cast(t1.[BookingDate] as date) = cast(@dateBook as date)
	and datepart(hour,t1.BookingDate) = @timeBook
 order by t1.[created_at]