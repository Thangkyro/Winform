
/****** Object:  StoredProcedure [dbo].[zBillMasterGetList_AllComplete]    Script Date: 6/16/2021 3:10:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--[zBookingMasterGetList_GroupByDate_New] '20211007',2
ALTER PROC [dbo].[zBookingMasterGetList_GroupByDate_New]
(
@dateBook as datetime,
@branchID as int
)
AS

	select *
	from (
					
		select  
				t1.[BookID]
			   ,t1.[Status]
			   --, CONCAT((CONVERT(VARCHAR(5),t1.BookingDate,108)),' - ', t1.CustomerPhone, ' - ', t2.Name) AS Short 
			   ,(CONVERT(VARCHAR(5),t1.BookingDate,108)) AS TimeBook
			   , CONCAT(' - ', t1.CustomerPhone, ' - ', t2.Name) AS Short 
			   ,ISNULL(t1.ShortDecriptions,'') AS ShortDecriptions
			   ,ISNULL(t1.Decriptions, '') AS Decriptions
			   --,case when datepart(hour, t1.BookingDate) = 9  then 1 else 0 end as '9'
			   --,case when datepart(hour, t1.BookingDate) = 10 then 1 else 0 end	as '10'
			   --,case when datepart(hour, t1.BookingDate) = 11 then 1 else 0 end	as '11'
			   --,case when datepart(hour, t1.BookingDate) = 12 then 1 else 0 end	as '12'
			   --,case when datepart(hour, t1.BookingDate) = 13 then 1 else 0 end	as '13'
			   --,case when datepart(hour, t1.BookingDate) = 14 then 1 else 0 end	as '14'
			   --,case when datepart(hour, t1.BookingDate) = 15 then 1 else 0 end	as '15'
			   --,case when datepart(hour, t1.BookingDate) = 16 then 1 else 0 end	as '16'
			   --,case when datepart(hour, t1.BookingDate) = 17 then 1 else 0 end	as '17'
			   --,case when datepart(hour, t1.BookingDate) = 18 then 1 else 0 end	as '18'
			   --,case when datepart(hour, t1.BookingDate) = 19 then 1 else 0 end	as '19'
			   , datepart(hour, t1.BookingDate) AS HourBook
			   , ROW_NUMBER() OVER(PARTITION BY datepart(hour, t1.BookingDate) ORDER BY datepart(hour, t1.BookingDate) DESC) AS Slot
		 from  [dbo].[zBookingMaster] t1 with(nolock)
			join [dbo].[zCustomer] t2 with(nolock) on t1.CustId = t2.CustId
		where cast([BookingDate] as date) = cast(@dateBook as date)
			and t1.branchId = @branchID
		 ) t
		 where t.Slot <= 10


