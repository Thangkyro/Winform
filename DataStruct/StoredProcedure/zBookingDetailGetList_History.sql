USE [qidjefjs_ausNail]
GO
/****** Object:  StoredProcedure [dbo].[zBookingDetailGetList]    Script Date: 23/05/2021 3:40:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROC [dbo].[zBookingDetailGetList_History]
(
@BookID as int,
@branchId as int
)
AS

-- Author: Kyro
-- Created: 22 May 2021
-- Function: select a zBookingDetail table record

-- Modifications:

 Select 
	t0.BookDTID,
	t0.BookID,
	t0.OrderNumber,
	t0.branchId,
	t0.ServiceID,
	t1.Title as ServiceName,
	ISNULL(t1.Price,0) as Price,
	t0.Quantity * ISNULL(t1.Price,0) as Amout,
	t0.Quantity,
	t0.EstimatePrice,
	t0.EstimateTime,
	t0.Note,
	t0.StaffId,
	t0.created_by,
	t0.created_at
 FROM  [dbo].[zBookingDetail] t0 with(nolock)
	Join [dbo].[zService] t1 with(nolock) on t0.branchId = t1.branchId and t0.ServiceID = t1.ServiceID
 where (t0.BookID  = @BookID  AND  t0.branchId  = @branchId)


