
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
		t0.[BookDTID]
      ,t0.[BookID]
      ,t0.[OrderNumber]
      ,t0.[branchId]
      ,t0.[ServiceID]
      ,CAST(t0.[Quantity] AS INT) AS Quantity
      ,t0.[EstimatePrice]
      ,t0.[EstimateTime]
      ,t0.[Note]
      ,t0.[StaffId]
	  , t1.Title
	  , ISNULL(t1.ShortDecriptions,'') AS ShortDecriptions
	FROM  [dbo].[zBookingDetail] t0 with(nolock)
		join [dbo].[zService] t1 with(nolock) ON t0.[ServiceID] = t1.[ServiceID]
	where t0.BookID  = @BookID



