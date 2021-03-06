/****** Object:  StoredProcedure [qidjefjs_Dev].[zBillTempoary]    Script Date: 04/06/2021 12:11:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Kyro 
-- Create date: 03/06/2021
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [qidjefjs_Dev].[zBillTempoary]
	@BookingId int,
	@BranchID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT 
		t0.BookingDate,
		t2.[Name] as CustomerName,
		t0.CustomerPhone,
		t1.OrderNumber,
		t3.Title as ServiceName,
		t1.Quantity,
		t1.EstimatePrice,
		t1.Quantity * t1.EstimatePrice as Amount,
		t4.[Name] as StaffName ,
		t1.Note,
		t1.EstimateTime
	FROM dbo.[zBookingMaster] t0 with(nolock)
		join dbo.[zBookingDetail] t1 with(nolock) on t0.branchId = t1.branchId and t0.BookID = t1.BookID
		join dbo.[zCustomer] t2 with(nolock) on t0.CustId = t2.CustId
		join dbo.[zService] t3 with(nolock) on t1.branchId = t3.branchId and t1.ServiceID = t3.ServiceID
		join dbo.[zStaff] t4 with(nolock) on t1.StaffId = t4.StaffId
	WHERE t0.branchId = @BranchID
		And t0.BookID = @BookingId
END
