USE [qidjefjs_ausNail]
GO
/****** Object:  StoredProcedure [dbo].[zBookingMasterGetList]    Script Date: 30/05/2021 4:50:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROC [dbo].[zBookingMasterGetId]
(
@CustomerPhone as nvarchar(50),
@BookingDate as datetime,
@branchId as int
)
AS

-- Author: Kyro
-- Created: 30 May 2021
-- Function: select a zBookingMaster by customer and current date.

-- Modifications:
	
	Declare @CustId as int
	SELECT @CustId = CustId FROM [dbo].[zCustomer] with(nolock) WHERE (ISNULL(PhoneNumber1, '') = @CustomerPhone Or ISNULL(PhoneNumber2, '') = @CustomerPhone ) ORDER BY CustId DESC

	
	SELECT 
		BookID
	FROM  [dbo].[zBookingMaster] with(nolock)
	WHERE [branchId] =  @branchId 
			and CAST([BookingDate] as date) = CAST(@BookingDate as date)
			and [CustId] = @CustId and [Status] = 'Temporary'


