
/****** Object:  StoredProcedure [dbo].[zBookingMasterGetList_byCustomer]    Script Date: 6/17/2021 9:13:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROC [dbo].[zBookingMaster_byBookID]
(
@BookID as int
)
AS

-- Author: Kyro
-- Created: 22 May 2021
-- Function: select a zBookingMaster table record by Customer

-- Modifications:

	Select 
		t0.BookID,
		t1.Name,
		t0.BookingDate,
		t0.CustId,
		t0.CustomerPhone,
		t0.TotalEstimatePrice,
        t0.TotalEstimateTime,
		t0.Decriptions,
		t0.ShortDecriptions
	FROM  [dbo].[zBookingMaster] t0 with(nolock)
		Join [dbo].[zCustomer] t1 with(nolock) on t0.CustId = t1.CustId
	where t0.BookID  = @BookID
		--And t0.Status = 'Temporary'


