USE [qidjefjs_ausNail]
GO
/****** Object:  StoredProcedure [dbo].[zBillMasterGetList_AllComplete]    Script Date: 6/16/2021 3:10:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROC [dbo].[zBookingMasterGetList_GroupByDate]
(
@dateBook as datetime,
@branchID as int
)
AS

	select
		[Status]
		, case when OneAM = '0B - '			then null else OneAM  end as OneAM
		, case when TwoAM = '0B - '			then null else TwoAM  end as TwoAM
		, case when ThreeAM = '0B - '		then null else ThreeAM  end as ThreeAM
		, case when FourAM = '0B - '		then null else FourAM  end as FourAM
		, case when FiveAM = '0B - '		then null else FiveAM  end as FiveAM
		, case when SixAM = '0B - '			then null else SixAM  end as SixAM
		, case when SevenAM = '0B - '		then null else SevenAM  end as SevenAM
		, case when EightAM = '0B - '		then null else EightAM  end as EightAM
		, case when NineAM = '0B - '		then null else NineAM  end as NineAM
		, case when TenAM = '0B - '			then null else TenAM  end as TenAM
		, case when ElevenAM = '0B - '		then null else ElevenAM  end as ElevenAM
		, case when TwelvePM = '0B - '		then null else TwelvePM  end as TwelvePM
		, case when ThirteenPM = '0B - '	then null else ThirteenPM  end as ThirteenPM
		, case when FourteenPM = '0B - '	then null else FourteenPM  end as FourteenPM
		, case when FifteenPM = '0B - '		then null else FifteenPM  end as FifteenPM
		, case when SixteenPM = '0B - '		then null else SixteenPM  end as SixteenPM
		, case when SeventeenPM = '0B - '	then null else SeventeenPM  end as SeventeenPM
		, case when EighteenPM = '0B - '	then null else EighteenPM  end as EighteenPM
		, case when NineteenPM = '0B - '	then null else NineteenPM  end as NineteenPM
		, case when TwentyPM = '0B - '		then null else TwentyPM  end as TwentyPM
		, case when TwentyOnePM = '0B - '	then null else TwentyOnePM  end as TwentyOnePM
		, case when TwentyTwoPM = '0B - '	then null else TwentyTwoPM  end as TwentyTwoPM
		, case when TwentyThreePM = '0B - ' then null else TwentyThreePM  end as TwentyThreePM
		, case when TwentyFourPM = '0B - '	then null else TwentyFourPM  end as TwentyFourPM
	from (
			Select 
			   [Status]
			  ,concat(sum(case when datepart(hour, BookingDate) = 1  then 1 else 0 end) , 'B - ', FORMAT(sum(case when datepart(hour, BookingDate) = 1 then TotalEstimatePrice else 0 end),'#,#')) as  OneAM
			  ,concat(sum(case when datepart(hour, BookingDate) = 2  then 1 else 0 end) , 'B - ', FORMAT(sum(case when datepart(hour, BookingDate) = 2 then TotalEstimatePrice else 0 end),'#,#')) as  TwoAM
			  ,concat(sum(case when datepart(hour, BookingDate) = 3  then 1 else 0 end) , 'B - ', FORMAT(sum(case when datepart(hour, BookingDate) = 3 then TotalEstimatePrice else 0 end),'#,#')) as  ThreeAM
			  ,concat(sum(case when datepart(hour, BookingDate) = 4  then 1 else 0 end) , 'B - ', FORMAT(sum(case when datepart(hour, BookingDate) = 4 then TotalEstimatePrice else 0 end),'#,#')) as  FourAM
			  ,concat(sum(case when datepart(hour, BookingDate) = 5  then 1 else 0 end) , 'B - ', FORMAT(sum(case when datepart(hour, BookingDate) = 5 then TotalEstimatePrice else 0 end),'#,#')) as  FiveAM
			  ,concat(sum(case when datepart(hour, BookingDate) = 6  then 1 else 0 end) , 'B - ', FORMAT(sum(case when datepart(hour, BookingDate) = 6 then TotalEstimatePrice else 0 end),'#,#')) as  SixAM
			  ,concat(sum(case when datepart(hour, BookingDate) = 7  then 1 else 0 end) , 'B - ', FORMAT(sum(case when datepart(hour, BookingDate) = 7 then TotalEstimatePrice else 0 end),'#,#')) as  SevenAM
			  ,concat(sum(case when datepart(hour, BookingDate) = 8  then 1 else 0 end) , 'B - ', FORMAT(sum(case when datepart(hour, BookingDate) = 8 then TotalEstimatePrice else 0 end),'#,#')) as  EightAM
			  ,concat(sum(case when datepart(hour, BookingDate) = 9  then 1 else 0 end) , 'B - ', FORMAT(sum(case when datepart(hour, BookingDate) = 9 then TotalEstimatePrice else 0 end),'#,#')) as  NineAM
			  ,concat(sum(case when datepart(hour, BookingDate) = 10 then 1 else 0 end) , 'B - ', FORMAT(sum(case when datepart(hour, BookingDate) = 10 then TotalEstimatePrice else 0 end),'#,#')) as TenAM
			  ,concat(sum(case when datepart(hour, BookingDate) = 11 then 1 else 0 end) , 'B - ', FORMAT(sum(case when datepart(hour, BookingDate) = 11 then TotalEstimatePrice else 0 end),'#,#')) as ElevenAM
			  ,concat(sum(case when datepart(hour, BookingDate) = 12 then 1 else 0 end) , 'B - ', FORMAT(sum(case when datepart(hour, BookingDate) = 12 then TotalEstimatePrice else 0 end),'#,#')) as TwelvePM
			  ,concat(sum(case when datepart(hour, BookingDate) = 13 then 1 else 0 end) , 'B - ', FORMAT(sum(case when datepart(hour, BookingDate) = 13 then TotalEstimatePrice else 0 end),'#,#')) as ThirteenPM
			  ,concat(sum(case when datepart(hour, BookingDate) = 14 then 1 else 0 end) , 'B - ', FORMAT(sum(case when datepart(hour, BookingDate) = 14 then TotalEstimatePrice else 0 end),'#,#')) as FourteenPM
			  ,concat(sum(case when datepart(hour, BookingDate) = 15 then 1 else 0 end) , 'B - ', FORMAT(sum(case when datepart(hour, BookingDate) = 15 then TotalEstimatePrice else 0 end),'#,#')) as FifteenPM
			  ,concat(sum(case when datepart(hour, BookingDate) = 16 then 1 else 0 end) , 'B - ', FORMAT(sum(case when datepart(hour, BookingDate) = 16 then TotalEstimatePrice else 0 end),'#,#')) as SixteenPM
			  ,concat(sum(case when datepart(hour, BookingDate) = 17 then 1 else 0 end) , 'B - ', FORMAT(sum(case when datepart(hour, BookingDate) = 17 then TotalEstimatePrice else 0 end),'#,#')) as SeventeenPM
			  ,concat(sum(case when datepart(hour, BookingDate) = 18 then 1 else 0 end) , 'B - ', FORMAT(sum(case when datepart(hour, BookingDate) = 18 then TotalEstimatePrice else 0 end),'#,#')) as EighteenPM
			  ,concat(sum(case when datepart(hour, BookingDate) = 19 then 1 else 0 end) , 'B - ', FORMAT(sum(case when datepart(hour, BookingDate) = 19 then TotalEstimatePrice else 0 end),'#,#')) as NineteenPM
			  ,concat(sum(case when datepart(hour, BookingDate) = 20 then 1 else 0 end) , 'B - ', FORMAT(sum(case when datepart(hour, BookingDate) = 20 then TotalEstimatePrice else 0 end),'#,#')) as TwentyPM
			  ,concat(sum(case when datepart(hour, BookingDate) = 21 then 1 else 0 end) , 'B - ', FORMAT(sum(case when datepart(hour, BookingDate) = 21 then TotalEstimatePrice else 0 end),'#,#')) as TwentyOnePM
			  ,concat(sum(case when datepart(hour, BookingDate) = 22 then 1 else 0 end) , 'B - ', FORMAT(sum(case when datepart(hour, BookingDate) = 22 then TotalEstimatePrice else 0 end),'#,#')) as TwentyTwoPM
			  ,concat(sum(case when datepart(hour, BookingDate) = 23 then 1 else 0 end) , 'B - ', FORMAT(sum(case when datepart(hour, BookingDate) = 23 then TotalEstimatePrice else 0 end),'#,#')) as TwentyThreePM
			  ,concat(sum(case when datepart(hour, BookingDate) = 0  then 1 else 0 end) , 'B - ', FORMAT(sum(case when datepart(hour, BookingDate) = 0 then TotalEstimatePrice else 0 end),'#,#')) as TwentyFourPM

		 from  [dbo].[zBookingMaster] with(nolock)
		 where cast([BookingDate] as date) = cast(@dateBook as date)
			and branchId = @branchID
		 group by [Status]
		 ) t
