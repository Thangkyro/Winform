USE [qidjefjs_ausNail]
GO
/****** Object:  StoredProcedure [dbo].[zBookingMasterGetList_byCustomer]    Script Date: 6/17/2021 9:13:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROC [dbo].[zBookingDetail_byBookID]
(
@BookID as int
)
AS

-- Author: Kyro
-- Created: 22 May 2021
-- Function: select a zBookingMaster table record by Customer

-- Modifications:

	Select 
		[BookDTID]
      ,[BookID]
      ,[OrderNumber]
      ,[branchId]
      ,[ServiceID]
      ,[Quantity]
      ,[EstimatePrice]
      ,[EstimateTime]
      ,[Note]
      ,[StaffId]
	FROM  [dbo].[zBookingDetail] t0 with(nolock)
	where t0.BookID  = @BookID


