
/****** Object:  StoredProcedure [dbo].[zBookingMasterGetList_GroupByDate_New]    Script Date: 6/20/2022 10:42:06 PM ******/
--USE [qidjefjs_ausNail]
--GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--[zBookingMasterGetList_GroupByDate_NewWeb] '20220101','20220701',2
Create PROC [dbo].[zBookingMasterGetList_GroupByDate_NewWeb]
(
@FromdateBook as datetime,
@TodateBook as datetime,
@branchID as int
)
AS


declare @zCountBooking INT = 10
-- update
SELECT @zCountBooking = zCountBooking FROM zBranch WITH(nolock) where   branchId  = @branchId

IF ISNULL(@zCountBooking,10) >=10 SET @zCountBooking = 10

	select *
	from (
		select  
				t1.[BookID]
			   ,t1.[Status]
			   ,[BookingDate]
			   ,cast([BookingDate] as date) AS date
			   ,(CONVERT(VARCHAR(5),t1.BookingDate,108)) AS TimeBook
			   , CONCAT(' - ', t1.CustomerPhone, ' - ', t2.Name) AS Short 
			   ,ISNULL(t1.ShortDecriptions,'') AS ShortDecriptions
			   ,ISNULL(t1.Decriptions, '') AS Decriptions
			   , datepart(hour, t1.BookingDate) AS HourBook
			   , ROW_NUMBER() OVER(PARTITION BY cast([BookingDate] as date),datepart(hour, t1.BookingDate) ORDER BY cast([BookingDate] as date),datepart(hour, t1.BookingDate) DESC) AS Slot
		 from  [dbo].[zBookingMaster] t1 with(nolock)
			join [dbo].[zCustomer] t2 with(nolock) on t1.CustId = t2.CustId
		where cast([BookingDate] as date) >= cast(@FromdateBook as date)
			AND cast([BookingDate] as date) <= cast(@TodateBook as date)
			and t1.branchId = @branchID
		 ) t
		 where t.Slot <= @zCountBooking
			order by date,HourBook, slot


